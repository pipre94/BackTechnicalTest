using BackTechnicalTest.Domain.Entities;
using BackTechnicalTest.Domain.IRepositories;
using MediatR;

namespace BackTechnicalTest.Applications.Commands
{
    public class CreateUsersCommandHandler : IRequestHandler<CreateUsersCommand, Users>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ILogger<CreateUsersCommandHandler> _logger;

        public CreateUsersCommandHandler( IUsersRepository usersRepository, ILogger<CreateUsersCommandHandler> logger) 
        {
           _usersRepository = usersRepository;
           _logger = logger;
        }

        public async Task<Users> Handle(CreateUsersCommand command, CancellationToken cancellationToken)
        {
            Users users = new Users();

            if(command.User == null)
            {
                _logger.LogInformation("If the information of the model for users is null, return empty.");
                return users;
            }

            users = command.User;
            await _usersRepository.AddUsers(users);

            return users;
        }
    }
}
