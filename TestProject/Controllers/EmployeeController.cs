using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestProject.Entity.Entity;
using TestProject.Repository.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly IGenericRepository<Employee> _employee;
        public EmployeeController(IGenericRepository<Employee> employee)
        {
            _employee = employee;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _employee.GetAll();
            if (!result.Any())
            {
                return NotFound("Result Not Found");
            }
            return Ok(result);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
