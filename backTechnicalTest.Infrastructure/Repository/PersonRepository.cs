using BackTechnicalTest.Domain.Entities;

namespace BackTechnicalTest.Infrastructure.Repository
{
    public class PersonRepository
    {
        private readonly DataBaseContext _context;

        public PersonRepository(DataBaseContext context)
        {
            _context = context;
        }

        public List<Persons> GetAllPersons()
        {
            return _context.Persons.ToList();
        }
    }
}
