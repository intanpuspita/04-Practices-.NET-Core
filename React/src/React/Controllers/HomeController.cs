using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using React.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace React.Controllers
{
    public class HomeController : Controller
    {
        private static readonly IList<Comment> _commentList;

        static HomeController()
        {
            _commentList = new List<Comment> {
                new Comment
                {
                    ID = 1,
                    Author = "Daniel Lo Nigro",
                    Text = "Hello ReactJS.NET World!"
                },
                new Comment
                {
                    ID = 2,
                    Author = "Pete Hunt",
                    Text = "This is one comment"
                },
                new Comment
                {
                    ID = 3,
                    Author = "Jordan Walke",
                    Text = "This is *another* comment"
                }
            };
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [Route("comments")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult GetAllComments()
        {
            return Json(_commentList);
        }

        [Route("comments/new")]
        [HttpPost]
        public ActionResult AddComment(Comment comment)
        {
            // Create a fake ID for this comment
            comment.ID = _commentList.Count + 1;
            _commentList.Add(comment);
            return Content("Success :)");
        }
    }
}
