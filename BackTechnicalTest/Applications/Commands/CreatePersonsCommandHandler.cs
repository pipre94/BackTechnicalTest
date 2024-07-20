using BackTechnicalTest.Domain.Entities;
using BackTechnicalTest.Domain.IRepositories;
using BackTechnicalTest.Domain.Models;
using MediatR;

namespace BackTechnicalTest.Applications.Commands
{
    public class CreatePersonsCommandHandler : IRequestHandler<CreatePersonsCommand, Persons>
    {
        private readonly ILogger<CreatePersonsCommandHandler> _logger;
        private IPersonRepository _personRepository;

        public CreatePersonsCommandHandler(ILogger<CreatePersonsCommandHandler> logger, IPersonRepository personRepository)
        { 
            _logger = logger;
            _personRepository = personRepository;
        }


        public async Task<Persons> Handle(CreatePersonsCommand command, CancellationToken cancellationToken)        
        { 

            Persons persons = new Persons();

            if(command.persons == null) 
            {
                _logger.LogInformation("If the information of the model for persons is null, return empty.");
                return persons;
            }
            persons = command.persons;
            //await _personRepository.AddPersons(persons);


            return persons;
        }


    }
}
