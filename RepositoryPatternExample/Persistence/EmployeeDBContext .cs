using Microsoft.EntityFrameworkCore;
using RepositoryPatternExample.Core.Domain;

namespace RepositoryPatternExample.Persistence
{
    public class EmployeeDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options)
            : base(options)
        {

        }
    }
}
