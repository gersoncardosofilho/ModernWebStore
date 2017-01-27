using ModerWebStore.Domain.Commands.UserCommands;
using ModerWebStore.Domain.Entities;

namespace ModerWebStore.Domain.Services
{
    public interface IUserApplicationService
    {
        User Register(RegisterUserCommands command);
        User Authenticate(string email, string password);
    }
}
