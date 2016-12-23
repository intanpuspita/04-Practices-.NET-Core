using Microsoft.AspNetCore.Mvc;
using ReduxstagramAPI.Data;
using ReduxstagramAPI.Models;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ReduxstagramAPI.Controllers
{
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        private readonly DbAppContext _context;

        public PostController(DbAppContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult like(string id)
        {
            var post = _context.Posts.Find(id);

            if (post == null)
            {
                return NotFound();
            }

            post.Likes = post.Likes + 1;

            //try
            //{
                _context.Update(post);
                _context.SaveChanges();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!EmployeeExists(employee.ID))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return new ObjectResult(post);
        }
        
        // GET: api/post
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return _context.Posts;
        }
    }
}
