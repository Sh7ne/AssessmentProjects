using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimplePostAPI.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimplePostAPI.Controllers
{   
    // api/greeting
    [Route("api/[controller]")]
    public class GreetingController : Controller
    {
        private IHelloWorld _helloWorld;

        public GreetingController(IHelloWorld helloWorld)
        {
            _helloWorld = helloWorld;
        }

        // GET: api/greeting
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Hello", "World" };
        }


        // POST api/greeting
        [HttpPost]
        public ActionResult Post([FromBody]NameModel name)
        {
            var nameString = _helloWorld.Greetings(name.firstName, name.lastName);
            return Ok(new { result = nameString });

        }
    }
}
