using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Xml;
using WpfApp1.DBContext;
using WpfApp1.Helper;
using WpfApp1.Services;
using static WpfApp1.Helper.Library;

namespace WpfApp1.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IDbContext _dbContext;

        private readonly ControlServices _controlServices;
        public MainViewModel()
        {
            // _controlServices = controlServices;
            controls = new ObservableCollection<Type>(Library.GetWpfControlsList());
            assembly = new ObservableCollection<Namespace>(Library.GetLibrary());
            controls= new ObservableCollection<Type>(controls.Where(c => mycontrols.ToList().Any(myc => myc.Key == c.Name)));
        }
        Dictionary<string, string> mycontrols = new Dictionary<string, string>() { { "Button", "MyButton" }, { "TextBox", "MyTextBox" }, { "TextBlock", "MyTextBlock" },{ "ComboBox", "MyComboBox" }, {"CheckBox","MyCheckBox" }};
        private const string V = "Button Text";
        [ObservableProperty]
        private ObservableCollection<string>? items= new ObservableCollection<string>();
        [ObservableProperty]
        private ObservableCollection<string>? xmls = new ObservableCollection<string>();

        [ObservableProperty]
        private ObservableCollection<Type>? controls= new ObservableCollection<Type>();
        [ObservableProperty]
        private string button1  = V;
        [ObservableProperty]
        private string selectedItem = string.Empty;
        
        [ObservableProperty]
        private string xmlText = "XML";
        //[ObservableProperty]
        //private string selectedClassName = string.Empty;
        //[ObservableProperty]
        //private string selectedFunctionName = string.Empty;
        [ObservableProperty]
        private ObservableCollection<Namespace> assembly;
        [RelayCommand]
        public void  Add()
        {
            button1 = "Test Button";
           // controls = new ObservableCollection<Type>(Library.GetWpfControlsList());
            //items = new ObservableCollection<string>(Library.GetWpfControlsList().Select(t=>t.Name).ToList());
            assembly = new ObservableCollection<Namespace>(Library.GetLibrary());
            var resourceDict = new ResourceDictionary();
            resourceDict.Source = new Uri("Dictionary1.xaml", UriKind.RelativeOrAbsolute);
            object resource=resourceDict["MyButton"];
            string xaml = XamlWriter.Save(resource);
            xmls.Add(xaml);
            FrameworkElement rootElement = (FrameworkElement)Application.Current.MainWindow.Content;
            Grid grid = (Grid)rootElement.FindName("myGrid2");
            UIElement element = (UIElement)XamlReader.Parse(xaml);
            // Add the object to the Grid's Children collection
            grid.Children.Add(element);

            RichTextBox myRichTextBox = (RichTextBox)rootElement.FindName("myRichTextBox");
            myRichTextBox.Document.Blocks.Clear();
            StringBuilder stringBuilder = new StringBuilder();
            using (XmlTextWriter xmlTextWriter = new (new StringWriter(stringBuilder)) { })
            {
                xmlTextWriter.Formatting = Formatting.Indented;
                XamlWriter.Save(grid, xmlTextWriter);
            }
            string gridxaml = stringBuilder.ToString();
            myRichTextBox.Document.Blocks.Add(new Paragraph(new Run(gridxaml)));
            //_dbContext.ViewXamls.Add(new Models.ViewXaml() {Controls=gridxaml });

            OnPropertyChanged("xmls");
            OnPropertyChanged("controls");
            OnPropertyChanged("label1");
            OnPropertyChanged("items");
            OnPropertyChanged("assembly");
        }
        [RelayCommand]
        public void SelectedItemChanged(string selectedObject)
        {
            string control = selectedObject.Replace("System.Windows.Controls.", string.Empty);
            var resourceDict = new ResourceDictionary();
            resourceDict.Source = new Uri("Dictionary1.xaml", UriKind.RelativeOrAbsolute);
            object resource = resourceDict[$"My{control}"];
            string xaml = XamlWriter.Save(resource);
            xmls.Clear();
            xmls.Add(xaml);
            FrameworkElement rootElement = (FrameworkElement)Application.Current.MainWindow.Content;
            Grid grid = (Grid)rootElement.FindName("myGrid2");
            UIElement element = (UIElement)XamlReader.Parse(xaml);
            // Add the object to the Grid's Children collection
            grid.Children.Clear();
            grid.Children.Add(element);
            grid.VerticalAlignment = VerticalAlignment.Top;
            grid.HorizontalAlignment = HorizontalAlignment.Left;
        }
        [RelayCommand]
        public void FunctionNameChanged()
        {

        }

    }
}
