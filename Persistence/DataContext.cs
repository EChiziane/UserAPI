using domain;
using Microsoft.EntityFrameworkCore;

namespace persistence
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            
        }

      public DbSet<Employee> Employees {get;set;}

        public  DbSet<Stay> Stays { get; set; }
    }
}