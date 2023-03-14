using Microsoft.EntityFrameworkCore;
using System.Windows.Controls;
using WpfApp1.Models;

namespace WpfApp1
{
    public interface IDbContext
    {
        public DbSet<FileName> FileNames { get; set; }
        public DbSet<ViewXaml> ViewXamls { get; set; }
        // ... other entities
        int SaveChanges();
    }
}