using BackTechnicalTest.Domain.Entities;
using MediatR;

namespace BackTechnicalTest.Applications.Commands
{
    public class CreateUsersCommand : IRequest<Users>
    {
        public Users User { get; set; } 
        public CreateUsersCommand() { }
    }
}
