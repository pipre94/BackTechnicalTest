using BackTechnicalTest.Domain.Entities;
using BackTechnicalTest.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BackTechnicalTest.Applications.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonsController
    {

        private readonly ILogger<PersonsController> _logger;
        private readonly PersonRepository _personRepository;

        public PersonsController(ILogger<PersonsController> logger, PersonRepository personRepository)
        {
            _logger = logger;
            _personRepository = personRepository;
        }

        [HttpPost("CreatePerson")]
        public ActionResult<bool> CreatePersons()
        {

            return true;
        }

        [HttpGet("{id}")]
        public ActionResult<bool> GetPersonById(int id)
        {

            return true;

        }

        [HttpGet]
        public IEnumerable<Persons> GetPersons()
        {
            var data = _personRepository.GetAllPersons();

            return data;

        }
    }
}
