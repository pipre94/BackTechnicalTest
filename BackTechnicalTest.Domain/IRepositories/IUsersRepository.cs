using BackTechnicalTest.Domain.Entities;
using BackTechnicalTest.Domain.Models;

namespace BackTechnicalTest.Domain.IRepositories
{
    public interface IUsersRepository
    {
        Task AddUsers(Users users);

        Task<List<Users>> GetAllUsers();

        Task<Users> GetUsersByIdOrName(string userName);

        Task<List<Persons>> LoginAuthenticateUserAsync(LoginModel loginModel);
    }
}
