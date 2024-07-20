using BackTechnicalTest.Domain.Entities;
using BackTechnicalTest.Domain.IRepositories;
using BackTechnicalTest.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BackTechnicalTest.Infrastructure.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DataBaseContext _context;

        public PersonRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task AddPersons(Persons persons)
        {
            if (persons == null) 
            { 
                throw new ArgumentNullException(nameof(persons));
            }

            persons.FullName = string.Concat(persons.FirstName,' ',persons.LastName);
            persons.FullIdentification = string.Concat(persons.IdentificationType, '-', persons.IdentificationNumber);

            await _context.AddAsync(persons);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Persons>> GetAllPersonsAsync() => await _context.Persons.ToListAsync();

        public async Task<Persons> GetPersonsByIdAsync(int? id) => await _context.Persons.FindAsync(id);
    }
}
