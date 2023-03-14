using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WpfApp1.DBContext;
using WpfApp1.Models;

namespace WpfApp1.Services
{
    public class ControlServices
    {
        private readonly AppDbContext _dbContext;
        public ControlServices(AppDbContext dbContext) { 
            _dbContext = dbContext;
        }
        public List<ViewXaml> GetXamls()
        {
            return _dbContext.ViewXamls.ToList();
        }
        public ViewXaml? GetXaml(int Id)
        {
            return _dbContext.ViewXamls.FirstOrDefault(x => x.Id == Id);
        }
        //public async Task<ViewXaml?> UpdateXamlAsync(ViewXaml viewXaml)
        //{
        //    _dbContext.ViewXamls.Remove(viewXaml);
        //    await _dbContext.SaveChangesAsync();
        //    return viewXaml;
        //}
        //public async Task<ViewXaml> RemoveAsync(ViewXaml viewXaml)
        //{
        //    _dbContext.ViewXamls.Remove(viewXaml);
        //    await _dbContext.SaveChangesAsync();
        //    return viewXaml;
        //}
        //public async Task<List<ViewXaml>> RemoveRangeAsync(List<ViewXaml> viewXamls)
        //{
        //    _dbContext.ViewXamls.RemoveRange(viewXamls);
        //    await _dbContext.SaveChangesAsync();
        //    return viewXamls;
        //}
    }
}
