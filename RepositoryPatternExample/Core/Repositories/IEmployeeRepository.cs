using RepositoryPatternExample.Core.Domain;

namespace RepositoryPatternExample.Core.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        IEnumerable<Employee> GetOldestEmployees(int count);
    }
}