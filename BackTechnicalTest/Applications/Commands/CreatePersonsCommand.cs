using Azure.Core;
using BackTechnicalTest.Domain.Entities;
using BackTechnicalTest.Domain.Models;
using MediatR;

namespace BackTechnicalTest.Applications.Commands
{
    public class CreatePersonsCommand : IRequest<Persons>
    {
        public Persons persons { get; set; }
        public CreatePersonsCommand(Persons person)
        {
            persons = person;
        }
    }
}
