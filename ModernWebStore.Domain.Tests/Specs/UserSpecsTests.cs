using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModerWebStore.Domain.Entities;
using ModernWebStore.SharedKernel.Helpers;
using ModerWebStore.Domain.Specs;
using System.Linq;

namespace ModernWebStore.Domain.Tests.Specs
{
    /// <summary>
    /// Summary description for UserSpecsTest
    /// </summary>
    [TestClass]
    public class UserSpecsTests
    {
       private List<User> _users;

        public UserSpecsTests()
        {
            this._users = new List<User>();
            _users.Add(new User("gersoncfilho@mac.com", StringHelper.Encrypt("123456"), true));
        }

        [TestMethod]
        [TestCategory("User Specs")]
        public void ShouldAuthenticate()
        {
            var exp = UserSpecs.AuthenticateUser("gersoncfilho@mac.com", "123456");
            var user = _users.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, user);
        }

        [TestMethod]
        [TestCategory("User Specs")]
        public void ShouldNotAuthenticateWhenEmailIsWrong()
        {
            var exp = UserSpecs.AuthenticateUser("gersoncfilho@gmail.com", "123456");
            var user = _users.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, user);
        }

        [TestMethod]
        [TestCategory("User Specs")]
        public void ShouldNotAuthenticateWhenPasswordIsWrong()
        {
            var exp = UserSpecs.AuthenticateUser("gersoncfilho@mac.com", "12345678");
            var user = _users.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, user);
        }
    }
}
