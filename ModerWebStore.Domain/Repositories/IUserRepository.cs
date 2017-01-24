using ModerWebStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModerWebStore.Domain.Repositories
{
    public interface IUserRepository
    {
        void Register(User user);
        User Authenticate(string email, string password);
        User GetByEmail(string email);
    }
}
