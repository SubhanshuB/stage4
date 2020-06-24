using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPiCoreCrudOperation.Models;

namespace WebAPiCoreCrudOperation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {


        /*private Employee[] employees = new Employee[]
        {
             new Employee{Id=1,Name="John",Salary=50000,Permanent=true,Department=new Department{Id=1,Name="Finance"},Skills=new List<Skill>{new Skill{Id=1,Name="Communication"},new Skill { Id = 2, Name = "Translator" } },DateOfBirth=DateTime.Parse("02/12/1994") },
             new Employee{Id=2,Name="Paul",Salary=40000,Permanent=true,Department=new Department{Id=2,Name="IT"},Skills=new List<Skill>{new Skill{Id=1,Name="Communication"},new Skill { Id = 2, Name = "Developer" } },DateOfBirth=DateTime.Parse("02/12/1996") }
        };
        private IEnumerable<Employee> GetStandardEmployeeList()
        {
            var employees = new List<Employee>
            {
                new Employee{Id=1,Name="John",Salary=50000,Permanent=true,Department=new Department{Id=1,Name="Finance"},Skills=new List<Skill>{new Skill{Id=1,Name="Communication"},new Skill { Id = 2, Name = "Translator" } },DateOfBirth=DateTime.Parse("02/12/1994") },
                new Employee{Id=2,Name="Paul",Salary=40000,Permanent=true,Department=new Department{Id=2,Name="IT"},Skills=new List<Skill>{new Skill{Id=1,Name="Communication"},new Skill { Id = 2, Name = "Developer" } },DateOfBirth=DateTime.Parse("02/12/1996") }
            };
            return employees;
        }*/

        // GET: api/Employee
        private EmpContext _context;
        public EmployeeController(EmpContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            //return new string[] { "value1", "value2" };

            return _context.Employees.ToList();
        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get(int id)
        {

            var employee = _context.Employees.SingleOrDefault(p => p.Id == id);
            if (employee == null)
                return NotFound();
           
            return Ok(employee);
        }

        // POST: api/Employee
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Employee employee)
        {
            var employee1 = _context.Employees.SingleOrDefault(p => p.Id == id);

            if (id <= 0)
                return BadRequest("Invalid employee id");
            else if (employee1 == null)
                return BadRequest("Invalid employee id");
            else
            {   employee1.Name = employee.Name;
                employee1.Salary = employee.Salary;
                employee1.Permanent = employee.Permanent;
                employee1.Salary = employee.Salary;
                employee1.Department = employee.Department;
                employee1.Skills = employee.Skills;
                employee1.DateOfBirth = employee.DateOfBirth;

                _context.SaveChanges();
                return Ok(employee1);

            }
        }
           

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
