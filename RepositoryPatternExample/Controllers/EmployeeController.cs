using Microsoft.AspNetCore.Mvc;
using RepositoryPatternExample.Core.Domain;
using RepositoryPatternExample.Persistence;

namespace RepositoryPatternExample.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly EmployeeDBContext context;

        public EmployeeController(EmployeeDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public Task Index()
        {
            using (var unitOfWork = new UnitOfWork(context))
            {
                unitOfWork.Employees.Add(new Employee() { lName = "yooo"  });

                // Example1
                var course = unitOfWork.Employees.Get(1);

                // Example2
                var employee = unitOfWork.Employees.GetOldestEmployees(1).First();
                unitOfWork.Employees.Remove(employee);
                unitOfWork.Save();

                var yo = 0;
            }

            return null;
        }
    }
}
