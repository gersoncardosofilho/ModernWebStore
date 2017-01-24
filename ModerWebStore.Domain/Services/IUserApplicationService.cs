using ModerWebStore.Domain.Commands.UserCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModerWebStore.Domain.Services
{
    public interface IUserApplicationService
    {
        IUserApplicationService Register(RegisterUserCommands command);
        IUserApplicationService Authenticate(string email, string password);
    }
}
