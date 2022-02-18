using RepositoryPatternExample.Core.Domain;
using RepositoryPatternExample.Core.Repositories;

namespace RepositoryPatternExample.Persistence.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeDBContext context) 
            : base(context)
        {
        }

        public IEnumerable<Employee> GetOldestEmployees(int count)
        {
            return EmployeeDBContext.Employees.OrderByDescending(c => c.Age).Take(count).ToList();
        }

        public EmployeeDBContext EmployeeDBContext
        {
            get { return Context as EmployeeDBContext; }
        }
    }
}