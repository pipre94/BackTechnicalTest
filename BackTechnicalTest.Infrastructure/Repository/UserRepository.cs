using BackTechnicalTest.Domain.Entities;
using BackTechnicalTest.Domain.IRepositories;
using BackTechnicalTest.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BackTechnicalTest.Infrastructure.Repository
{
    public class UserRepository : IUsersRepository
    {
        private readonly DataBaseContext _context;

        public UserRepository(DataBaseContext context)
        { 
            _context = context;
        }

        public async Task AddUsers(Users users)
        {
            if (users == null) 
            {
                throw new ArgumentNullException(nameof(users));
            }

            await _context.AddAsync(users);
            await _context.SaveChangesAsync();

        }

        public async Task<List<Users>> GetAllUsers() => await _context.Users.ToListAsync();

        public async Task<Users> GetUsersByIdOrName(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("Name the user is null");
            }
            
            return await _context.Users.FirstOrDefaultAsync(u => u.UsersName == username);

        }


        public async Task<List<Persons>> LoginAuthenticateUserAsync(LoginModel loginModel)        
        {
            List<Persons> response = new List<Persons>();
            var result = await _context.Users.FirstOrDefaultAsync(p => p.UsersName == loginModel.UserName && p.Password == loginModel.Password);
            if(result == null) 
            {
                throw new ArgumentNullException("Name the username and password is incorrect");

            }
            response = await _context.Persons.ToListAsync();
            return response;
        }
    }
}
