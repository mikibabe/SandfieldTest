using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SandfieldTest.Models;
using SandfieldTest.Services;

namespace SandfieldTest.Controllers
{

    public class UserController : Controller
    {
        private string _connectionString = string.Empty;

        public UserController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("sanfield");   
        }

        [HttpGet]
        [Route("User/All")]
        public IActionResult GetUserList()
        {
            return Ok(new UserService(_connectionString).GetUserList()); 
        }

        [HttpPost]
        [Route("User/Add")]
        public IActionResult AddUser([FromBody] User user)
        {
            var id = new UserService(_connectionString).AddUser(user);
            if (id == 0)
                return NotFound();
            else
                return Ok();
        }
         
        [HttpGet]
        [Route("User/GetUserAccessLevelById/{id}")]
        public IActionResult GetUserAccessLevelById(int id)
        {
            var d = new UserService(_connectionString).GetUserAccessLevelById(id);
            return Ok(d);
        }

        [HttpPut]
        [Route("User/Edit")]
        public IActionResult EditUser([FromBody] User user)
        {
            if (new UserService(_connectionString).EditUser(user))
                return Ok();
            else
                return NotFound();
        }


        [HttpGet]
        [Route("User/{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = new UserService(_connectionString).GetUserById(id);
            return Ok(user);
        }

        [HttpDelete]
        [Route("User/{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (new UserService(_connectionString).DeleteUser(id))
                return Ok();
            else
                return NotFound();
        }
    }
}
