using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BackTechnicalTest.Applications.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController
    {
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<bool> CreateUser()
        {

            return true;
        }

        [HttpGet("{id}")]
        public ActionResult<bool> GetUserById(int id)
        {
               
                return true;
            
        }

        [HttpGet]
        public ActionResult<bool> GetUser(int id)
        {

            return true;

        }
    }
}
