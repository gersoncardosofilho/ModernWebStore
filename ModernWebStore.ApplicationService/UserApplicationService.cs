using ModerWebStore.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModerWebStore.Domain.Commands.UserCommands;
using ModerWebStore.Domain.Repositories;
using ModernWebStore.Infra.Persistence;
using ModerWebStore.Domain.Entities;

namespace ModernWebStore.ApplicationService
{
    public class UserApplicationService : ApplicationServiceBase, IUserApplicationService
    {
        private IUserRepository _repository;

        public UserApplicationService(IUserRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }

        public User Authenticate(string email, string password)
        {
            return _repository.Authenticate(email, password);
        }

        public User Register(RegisterUserCommands command)
        {
            var user = new User(command.Email, command.Password, command.IsAdmin);
            user.Register();
            _repository.Register(user);

            if (Commit())
                return user;

            return null;
        }
    }
}
