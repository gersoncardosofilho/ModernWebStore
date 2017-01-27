using ModerWebStore.Domain.Repositories;
using System.Linq;
using ModerWebStore.Domain.Entities;
using ModernWebStore.Infra.DataContext;
using ModerWebStore.Domain.Specs;

namespace ModernWebStore.Infra.Repositories
{
    class UserRepository : IUserRepository
    {
        StoreDataContext _context;

        public UserRepository(StoreDataContext context)
        {
            this._context = context;
        }

        public User Authenticate(string email, string password)
        {
            return _context.Users.Where(UserSpecs.AuthenticateUser(email, password)).FirstOrDefault();
        }

        public User GetByEmail(string email)
        {
            return _context.Users.Where(UserSpecs.GetByEmail(email)).FirstOrDefault();
        }

        public void Register(User user)
        {
            _context.Users.Add(user);
        }
    }
}
