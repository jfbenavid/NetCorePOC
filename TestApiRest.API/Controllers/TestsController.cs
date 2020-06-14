using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TestApiRest.Repository;

namespace TestApiRest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TestsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public ActionResult Post(User user)
        {
            using (var db = new DBContext(_configuration))
            {
                db.Users.Add(user);
                db.SaveChanges();
            }

            return Ok();
        }

        [HttpGet]
        public ActionResult Get()
        {
            List<User> result = new List<User>();
            using (var db = new DBContext(_configuration))
            {
                result = db.Users.ToList();
            }

            return Ok(result);
        }
    }
}