using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SandfieldTest.Models;
using SandfieldTest.Services;

namespace SandfieldTest.Controllers
{

    public class PartController : Controller
    {
        private string _connectionString = string.Empty;

        public PartController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("sanfield");   
        }

        [HttpGet]
        [Route("Part/All")]
        public IActionResult GetPartList()
        {
            return Ok(new PartService(_connectionString).GetPartList()); 
        } 
    }
}
