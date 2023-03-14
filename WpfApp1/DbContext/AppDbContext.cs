using Microsoft.EntityFrameworkCore;
using WpfApp1.Models;

namespace WpfApp1.DBContext
{
    public class AppDbContext:DbContext,IDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<FileName> FileNames { get; set; }
        public DbSet<ViewXaml> ViewXamls { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=mydb.sqlite");
            optionsBuilder.UseInMemoryDatabase("Server=(localdb)\\mssqllocaldb;Database=MyDatabase;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileName>()
                .HasKey(e => e.Id);
            // Define other entity properties and relationships.
                modelBuilder.HasSequence<int>("Id")
                .StartsAt(1)
                .IncrementsBy(1);
        }
    }
}
