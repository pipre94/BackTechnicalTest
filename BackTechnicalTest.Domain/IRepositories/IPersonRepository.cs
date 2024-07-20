using BackTechnicalTest.Domain.Entities;
using BackTechnicalTest.Domain.Models;

namespace BackTechnicalTest.Domain.IRepositories
{
    public interface IPersonRepository
    {
        Task AddPersons(Persons persons);
        Task<List<Persons>> GetAllPersonsAsync();
        Task<Persons> GetPersonsByIdAsync(int? id);
    }
}
