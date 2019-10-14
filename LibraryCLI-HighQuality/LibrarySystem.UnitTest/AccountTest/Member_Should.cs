using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LibrarySystem.UnitTest.AccountTest
{
    [TestClass]
    public class Member_Should
    {
        [TestMethod]
        public void ValidateUsernameMember_Test()
        {
            var userName = "test name";

            var sut = new Member(userName);

            Assert.AreEqual("test name", sut.UserName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckMinimumUsernameLength_Test()
        {
            var userName = "tn";

            var sut = new Member(userName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckMaximumUsernameLength_Test()
        {
            var userName = new String('t', 13);

            var sut = new Member(userName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CheckIfUsernameIsNull_Test()
        {
            string userName = null;

            var sut = new Member(userName);
        }
    }
}