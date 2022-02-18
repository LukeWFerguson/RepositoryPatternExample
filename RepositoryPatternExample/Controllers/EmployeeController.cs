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

        [HttpGet("DataPopulation")]
        public async Task<IActionResult> DataPopulation()
        {
            List<Employee> employees = new List<Employee>() { new Employee() { Id = 1, Name = "Luke", Age = 30 }, new Employee() { Id = 2, Name = "Brittany", Age = 30 }, new Employee() { Id = 3, Name = "Matthew", Age = 6 }, new Employee() { Id = 4, Name = "Andrew", Age = 5 } };

            using (var unitOfWork = new UnitOfWork(context))
            {
                unitOfWork.Employees.AddRange(employees);
                unitOfWork.Save();
                return Ok();
            }
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Employee>>> GetAll()
        {
            using (var unitOfWork = new UnitOfWork(context))
            {
                IEnumerable<Employee> employees = unitOfWork.Employees.GetAll();
                return Ok(employees);
            }
        }

        [HttpGet("GetOldestEmployee")]
        public async Task<ActionResult<Employee>> GetOldestEmployee()
        {
            using (var unitOfWork = new UnitOfWork(context))
            {
                Employee employee = unitOfWork.Employees.GetOldestEmployees(1).FirstOrDefault();
                return Ok(employee);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            using (var unitOfWork = new UnitOfWork(context))
            {
                Employee employee = unitOfWork.Employees.SingleOrDefault(x => x.Id == id);

                if (employee == null)
                {
                    return BadRequest("Employee not found.");
                }

                return Ok(employee);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            using (var unitOfWork = new UnitOfWork(context))
            {
                unitOfWork.Employees.Add(employee);
                unitOfWork.Save();
                return Ok();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(Employee request)
        {
            using (var unitOfWork = new UnitOfWork(context))
            {
                Employee employee = unitOfWork.Employees.SingleOrDefault(x => x.Id == request.Id);

                if (employee == null)
                {
                    return BadRequest("Employee not found.");
                }

                // Making the changes...
                employee.Name = request.Name;
                employee.Age = request.Age;
                unitOfWork.Save();

                return Ok(employee);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            using (var unitOfWork = new UnitOfWork(context))
            {
                Employee employee = unitOfWork.Employees.SingleOrDefault(x => x.Id == id);

                if (employee == null)
                {
                    return BadRequest("Employee not found.");
                }

                unitOfWork.Employees.Remove(employee);
                unitOfWork.Save();
                return Ok();
            }
        }
    }
}
