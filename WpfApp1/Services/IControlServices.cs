using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Services
{
    public interface IControlServices
    {
        public List<ViewXaml> GetXamls();
        public ViewXaml? GetXaml(int Id);
        //public async Task<ViewXaml?> UpdateXamlAsync(ViewXaml viewXaml);
        //public async Task<ViewXaml> RemoveAsync(ViewXaml viewXaml);
        //public async Task<List<ViewXaml>> RemoveRangeAsync(List<ViewXaml> viewXamls);
     
    }
}
