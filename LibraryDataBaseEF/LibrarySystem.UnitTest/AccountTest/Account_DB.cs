using LibrarySystem.Models;
using LibrarySystem.Models.Accounts;
using LibrarySystem.Services.Contracts.Accounts;
using LibrarySystem.Services.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibrarySystem.UnitTest.AccountTest
{
    [TestClass]
    public class Account_DB
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ThrowInvalidOperationException_WhenTypeIsNotCorrect()
        {
            var testUsername = "TestName";
            var testPasword = "12345";
            var accountType = (AccountType)2;

            var mockFactory = new Mock<IAccountFactory>();

            var options = TestUtilities.GetOptions(nameof(ThrowInvalidOperationException_WhenTypeIsNotCorrect));

            using (var assertContext = new LibrarySystemContext(options))
            {
                var sut = new AccountService(mockFactory.Object)
                    .CreateAccount(testUsername, testPasword, accountType);

            }
        }

        [TestMethod]
        public void Create_UserMember()
        {
            //Arrange
            var testUsername = "TestName";
            var testPassword = "12345";

            var options = TestUtilities.GetOptions(nameof(Create_UserMember));

            //Act
            using (var context = new LibrarySystemContext(options))
            {
                context.AccountsOldData.Add(new Member(testUsername, testPassword));
                context.SaveChanges();
            }

            //Assert
            using (var assertContext = new LibrarySystemContext(options))
            {
                Assert.AreEqual(1, assertContext.AccountsOldData.Count());
            }
        }
        [TestMethod]
        public void Create_CorrectMemberUserName()
        {
            //Arrange
            var testUsername = "TestName";
            var testPassword = "12345";

            var options = TestUtilities.GetOptions(nameof(Create_CorrectMemberUserName));


            //Act
            using (var context = new LibrarySystemContext(options))
            {
                context.AccountsOldData.Add(new Member(testUsername, testPassword));
                context.SaveChanges();
            }

            //Assert
            using (var assertContext = new LibrarySystemContext(options))
            {
                var user = assertContext.AccountsOldData.FirstOrDefault(u => u.UserName == testUsername);
                Assert.IsNotNull(user);
            }
        }
        [TestMethod]
        public void Create_CorrectMemberPasword()
        {
            //Arrange
            var testUsername = "TestName";
            var testPassword = "12345";

            var options = TestUtilities.GetOptions(nameof(Create_CorrectMemberPasword));

            //Act
            using (var context = new LibrarySystemContext(options))
            {
                context.AccountsOldData.Add(new Member(testUsername, testPassword));
                context.SaveChanges();
            }

            //Assert
            using (var assertContext = new LibrarySystemContext(options))
            {
                var user = assertContext.AccountsOldData.FirstOrDefault(u => u.UserName == testUsername);
                Assert.AreEqual(testPassword, user.Password);
            }
        }

        [TestMethod]
        public void Create_UserLibrarian()
        {
            //Arrange
            var testUsername = "TestName";
            var testPassword = "12345";

            var options = TestUtilities.GetOptions(nameof(Create_UserLibrarian));

            //Act
            using (var context = new LibrarySystemContext(options))
            {
                context.AccountsOldData.Add(new Librarian(testUsername, testPassword));
                context.SaveChanges();
            }
            //Assert
            using (var assertContext = new LibrarySystemContext(options))
            {
                Assert.AreEqual(1, assertContext.AccountsOldData.Count());
            }
        }
        [TestMethod]
        public void Create_CorrectLIbrarianUserName()
        {
            //Arrange
            var testUserName = "TestName";
            var testPassword = "12345";

            var options = TestUtilities.GetOptions(nameof(Create_CorrectLIbrarianUserName));

            //Act
            using (var context = new LibrarySystemContext(options))
            {
                context.AccountsOldData.Add(new Librarian(testUserName, testPassword));
                context.SaveChanges();
            }

            //Assert
            using (var asserstContext = new LibrarySystemContext(options))
            {
                var user = asserstContext.AccountsOldData.FirstOrDefault(librarian => librarian.UserName == testUserName);
                Assert.AreEqual(testUserName, user.UserName);
            }

        }
        [TestMethod]
        public void Create_CorrectLibrarianPasword()
        {
            //Arrange
            var testUsername = "TestName";
            var testPassword = "12345";

            var options = TestUtilities.GetOptions(nameof(Create_CorrectLibrarianPasword));

            //Act
            using (var context = new LibrarySystemContext(options))
            {
                context.AccountsOldData.Add(new Member(testUsername, testPassword));
                context.SaveChanges();
            }

            //Assert
            using (var assertContext = new LibrarySystemContext(options))
            {
                var user = assertContext.AccountsOldData.FirstOrDefault(u => u.UserName == testUsername);
                Assert.AreEqual(testPassword, user.Password);
            }

        }
    }
}

