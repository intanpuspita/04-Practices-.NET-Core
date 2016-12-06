using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly DbAppContext _context;

        public StudentController(DbAppContext context)
        {
            _context = context;
        }

        // GET api/Student
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _context.Students;
        }

        // GET api/Student/5
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var student = _context.Students.Where(x => x.ID.Contains(id));
            if (student == null)
            {
                return NotFound();
            }
            return new ObjectResult(student);
        }

        // GET api/Student
        [HttpDelete("{id}")]
        public IActionResult DeleteById(string id)
        {
            Student student = _context.Students.FirstOrDefault(x => x.ID.Contains(id));
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove((Student)student);
            _context.SaveChanges();
            return NotFound();
        }

        // PUT api/Employee/5
        [HttpPut]
        public IActionResult Put([FromBody]Student student)
        {
            if (_context.Students.Any(x => x.ID == student.ID))
            {
                return BadRequest();
            }

            _context.Students.Add(student);
            return new NoContentResult();
        }
    }
}
