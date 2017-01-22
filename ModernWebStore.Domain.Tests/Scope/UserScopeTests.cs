using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernWebStore.SharedKernel.Helpers;
using ModerWebStore.Domain.Entities;
using ModerWebStore.Domain.Scopes;

namespace ModernWebStore.Domain.Tests.Scope
{
    /// <summary>
    /// Summary description for UserScopeTests
    /// </summary>
    [TestClass]
    public class UserScopeTests
    {
        private User _validUser = new User("gersoncfilho@mac.com", "123456", true);
        private User _invalidPasswordUser = new User("gersoncfilho@mac.com", "", true);
        private User _invalidEmailUser = new User("", "123456", true);


        [TestMethod]
        [TestCategory("User")]
        public void ShouldRegisterUser()
        {
            Assert.AreEqual(true, UserScopes.RegisterUserScopeIsValid(_validUser));
        }

        [TestMethod]
        [TestCategory("User")]
        public void ShouldNotRegisterUserWithInvalidPassword()
        {
            Assert.AreEqual(false, UserScopes.RegisterUserScopeIsValid(_invalidPasswordUser));            
        }

        [TestMethod]
        [TestCategory("User")]
        public void ShouldNotRegisterUserWithInvalidEmail()
        {
            Assert.AreEqual(false, UserScopes.RegisterUserScopeIsValid(_invalidEmailUser));
        }

        [TestMethod]
        [TestCategory("User")]
        public void ShouldAuthenticateUser()
        {
            var isValid = UserScopes.AuthenticatedUserScopeIsValid(_validUser, "gersoncfilho@mac.com", StringHelper.Encrypt("123456"));
            Assert.AreEqual(true, isValid);
        }

        [TestMethod]
        [TestCategory("User")]
        public void ShouldNotAuthenticateUser()
        {
            Assert.AreEqual(false, UserScopes.AuthenticatedUserScopeIsValid(_validUser, "gersoncfilho@mac.com", "123456"));
        }
    }
}
