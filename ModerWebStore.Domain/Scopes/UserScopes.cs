using DomainNotificationHelper.Validation;
using ModerWebStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModerWebStore.Domain.Scopes
{
    public static class UserScopes
    {
        public static bool RegisterUserScopeIsValid(this User user)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertNotEmpty(user.Email, "Email obrigatório"),
                    AssertionConcern.AssertNotEmpty(user.Password, "Senha obrigatória")
                );
        }

        public static bool AuthenticatedUserScopeIsValid(this User user, string email, string encryptedPassword)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertNotEmpty(email, "O usuário é obrigatório"),
                    AssertionConcern.AssertNotEmpty(encryptedPassword, "A senha é obrigatória"),
                    AssertionConcern.AssertAreEquals(user.Email, email, "Usuário ou senha inválidos"),
                    AssertionConcern.AssertAreEquals(user.Password, encryptedPassword, "O usuário é obrigatório")
                );
        }
    }
}
