using ModernWebStore.SharedKernel.Helpers;
using ModerWebStore.Domain.Scopes;

namespace ModerWebStore.Domain.Entities
{
    public class User
    {
        public User(string email, string password, bool isAdmin)
        {
            this.Email = email;
            this.IsAdmin = isAdmin;
            this.Password = StringHelper.Encrypt(password);
        }

        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool IsAdmin { get; private set; }

        public void Register()
        {
            this.RegisterUserScopeIsValid();
        }

        public void Authenticate(string email, string password)
        {
            this.AuthenticatedUserScopeIsValid(email, password);
        }

        public void GrantAdmin()
        {
            this.IsAdmin = true;
        }

        public void RevokeAdmin()
        {
            this.IsAdmin = false;
        }

    }
}
