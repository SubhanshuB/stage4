﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCoreActionExcptionFilter.Filters;
using WebApiCoreActionExcptionFilter.Models;

namespace WebApiCoreActionExcptionFilter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomAuthFilter]
    public class EmployeeController : ControllerBase
    {
        private Employee[] employees = new Employee[]
     {
          new Employee{Id=1,Name="John",Salary=50000,Permanent=true,Department=new Department{Id=1,Name="Finance"},Skills=new List<Skill>{new Skill{Id=1,Name="Communication"},new Skill { Id = 2, Name = "Translator" } },DateOfBirth=DateTime.Parse("02/12/1994") },
          new Employee{Id=2,Name="Paul",Salary=40000,Permanent=true,Department=new Department{Id=2,Name="IT"},Skills=new List<Skill>{new Skill{Id=1,Name="Communication"},new Skill { Id = 2, Name = "Developer" } },DateOfBirth=DateTime.Parse("02/12/1996") }
     };
     private IEnumerable<Employee> GetStandardEmployeeList()
     {
         return employees;
     }




        // GET: api/Employee
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [CustomAuthFilter]
        public IActionResult Get()
        {
            return Ok(GetStandardEmployeeList());
        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
       // [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [CustomExceptionFilter]
        public IActionResult Get(int id)
        {
            if (id <= 0)
                throw new Exception("This is a Exception");
            return Ok("value");
        }

        // POST: api/Employee
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
