using BackTechnicalTest.Applications.Commands;
using BackTechnicalTest.Domain.Entities;
using BackTechnicalTest.Domain.Models;
using BackTechnicalTest.Infrastructure.Repository;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BackTechnicalTest.Applications.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController
    {
        private readonly ILogger<UsersController> _logger;
        //private readonly IMediator _mediator;
        private readonly UserRepository _userRepository;


        public UsersController(ILogger<UsersController> logger, UserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
            //_mediator = mediator;   
        }

        [HttpPost("CreateUsers")]
        public async Task<ActionResult<Users>> CreateUsers(Users createUsers)
        {
            //var createUsers = await _mediator.Send(command);

            if (createUsers == null)
            {
                _logger.LogInformation("If the information of the model for users is null, return empty.");
                return null;
            }

            await _userRepository.AddUsers(createUsers);

            return createUsers;
        }

        [HttpGet("GetUserByName/{name}")]
        public async Task<ActionResult<Users>> GetUserByNameAsync(string name)
        {
            Users users = new Users();
            if (string.IsNullOrEmpty(name))
            {
                _logger.LogInformation("If the information of the model for users is null, return empty.");
                return null;
            }

            users = await _userRepository.GetUsersByIdOrName(name);
            return users;
            
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<Users>>> GetAllUserAsync()
        {
            List<Users> users = new List<Users>();

            users = await _userRepository.GetAllUsers();

            return users;

        }

        [HttpPost("Login")]
        public async Task<ActionResult<List<Persons>>> Login(LoginModel loginModel)
        {
            List<Persons> persons = new List<Persons>();

            if (loginModel == null)
            {
                return null;
            }

            persons = await _userRepository.LoginAuthenticateUserAsync(loginModel);

            return persons;
        }
    }
}
