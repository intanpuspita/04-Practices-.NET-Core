using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstNetCoreWebApps.Controllers
{
    public class MyNewController : Controller
    {
        // GET: /<controller>/
        public string Index()
        {
            return "This is my index action";
        }

        public string Welcome()
        {
            return "This is my welcome action";
        }

        public string Hello(string name, int numTimes = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, numTimes: {numTimes}");
        }

        public string HelloID(int id = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello number: {id}");
        }
    }
}
