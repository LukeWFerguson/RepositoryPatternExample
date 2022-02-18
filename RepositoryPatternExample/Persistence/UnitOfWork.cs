using RepositoryPatternExample.Core.Repositories;
using RepositoryPatternExample.Persistence.Repositories;

namespace RepositoryPatternExample.Persistence
{
    public class UnitOfWork : IDisposable
    {
        private EmployeeDBContext _context;
        private IEmployeeRepository employees;

        public UnitOfWork(EmployeeDBContext employeeDBContext)
        {
            _context = employeeDBContext;
        }

        public IEmployeeRepository Employees
        {
            get
            {

                if (this.employees == null)
                {
                    this.employees = new EmployeeRepository(_context);
                }

                return employees;
            }
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}