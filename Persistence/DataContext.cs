using domain;
using Microsoft.EntityFrameworkCore;

namespace persistence
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DbContext> options):base(options)
        {
            
        }

       private DbSet<Employee> Employees {get;set;}

        private DbSet<Stay> Stays { get; set; }
    }
}