using BackTechnicalTest.Applications.Commands;
using BackTechnicalTest.Domain.Entities;
using BackTechnicalTest.Domain.Models;
using BackTechnicalTest.Infrastructure.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BackTechnicalTest.Applications.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonsController
    {

        private readonly ILogger<PersonsController> _logger;
        private readonly PersonRepository _personRepository;
        //private readonly IMediator _mediator;
        public PersonsController(ILogger<PersonsController> logger, PersonRepository personRepository)
        {
            _logger = logger;
            _personRepository = personRepository;
            //_mediator = mediator;
        }

        [HttpPost("CreatePerson")]
        public async Task<ActionResult<Persons>> CreatePersons(Persons persons)
        {
            //var createPersons = await _mediator.Send(new CreatePersonsCommand(persons));

            if (persons == null)
            {
                _logger.LogInformation("If the information of the model for persons is null, return empty.");
                return null;
            }
            await _personRepository.AddPersons(persons);

            return persons;
        }

        [HttpGet("GetPersonById/{id}")]
        public async Task<ActionResult<Persons>> GetPersonById(int? id)
        {
            Persons persons = new Persons();
            if (id == null) 
            {
                _logger.LogInformation("If the information of the model for persons is null, return empty.");
                return null;
            }

           persons = await _personRepository.GetPersonsByIdAsync(id);

            return persons;

        }

        [HttpGet("GetAllPersons")]
        public async Task<ActionResult<List<Persons>>> GetAllPersons()
        {
            List<Persons> persons = await _personRepository.GetAllPersonsAsync();
            return persons;
        }
    }
}
