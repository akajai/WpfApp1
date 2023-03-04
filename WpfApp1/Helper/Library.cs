using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Xml;

namespace WpfApp1.Helper
{
    public static class Library
    {
        public class Namespace
        {
            public string ClassName { get; set; }
            public string FunctionName { get; set; }
        }
        public static List<Namespace> GetLibrary()
        {
            List<Namespace> namespaces= new List<Namespace>();
            // Load the assembly
            Assembly assembly = Assembly.LoadFile(Directory.GetCurrentDirectory()+ "\\ClassLibrary2.dll");

            // Get all public types in the assembly
            Type[] types = assembly.GetExportedTypes();

            foreach (Type type in types)
            {
                MethodInfo[] methods = type.GetMethods(BindingFlags.Public| BindingFlags.Instance);
                var methodnames = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static).Where(m => m.IsPublic && m.DeclaringType.Namespace != "System").Select(s=>s.Name).ToList();
                // Loop through each method and print its name
                methodnames.ForEach(name => {
                    namespaces.Add(new Namespace() { ClassName = type.Name, FunctionName = name });
                });
            }
            
            return namespaces;
        }
        public static List<Type> GetWpfControlsList()
        {
            return Assembly.GetAssembly(typeof(Control))
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(Control)))
                .OrderBy(t => t.Name).
                ToList();
        }
        public static List<string> GetWpfControlsXml()
        {
            List<string> xmls= new List<string>();
            var types = Assembly.GetExecutingAssembly().GetTypes()./*Where(t => t.Namespace == "System.Windows.Controls").*/ToList(); ;

            foreach (var type in types)
            {
                string typeXml = XamlWriter.Save(Activator.CreateInstance(type));
                xmls.Add(typeXml);
            }
             return xmls;
        }
        public static string GetXamlFromControls(Type control)
        {
            StringWriter stringWriter = new StringWriter();
            //XamlWriter xamlWriter = XamlWriter.Save(control);
            //xamlWriter.Save(stringWriter);
            //return stringWriter.ToString();
            string xaml= XamlWriter.Save(control);
            return xaml;
        }
        public static List<string> GetXamlOfAllControls()
        {
            List<string> strings= new List<string>();
            var controlTypes = Assembly.GetAssembly(typeof(Control))
                                        .GetTypes()
                                        .Where(t => t.IsSubclassOf(typeof(Control)))
                                        .ToList();

            var test1 = controlTypes.Count(a => a.IsPublic);

            foreach (Type controlType in controlTypes)
            {
                try
                {
                    if (controlType.IsPublic) { 
                        var control = Activator.CreateInstance(controlType);
                        var test=XamlWriter.Save(controlType);
                        strings.Add(test);
                    }
                }
                catch (Exception ex)
                {
                    // handle exception when creating control instance
                }
            }
            return strings;
        }
            
    }
}
