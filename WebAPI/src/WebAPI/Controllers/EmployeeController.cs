using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        public IEmployeeRepository repo { get; set; }

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            repo = employeeRepository;
        }

        // GET api/Employee
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return repo.GetAll();
        }

        // GET api/Employee/5
        [HttpGet("{id}", Name = "GetEmployee")]
        public IActionResult Get(string id)
        {
            var employee = repo.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return new ObjectResult(employee);
        }

        // PUT api/Employee/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]Employee employee)
        {
            if (employee == null || employee.ID == id)
            {
                return BadRequest();
            }

            Employee dataEmployee = repo.Find(id);
            if (dataEmployee == null)
            {
                return NotFound();
            }

            repo.Update(employee);
            return new NoContentResult();
        }

        // DELETE api/Employee/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var employee = repo.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            repo.Remove(id);
            return new NoContentResult();
        }
    }
}
