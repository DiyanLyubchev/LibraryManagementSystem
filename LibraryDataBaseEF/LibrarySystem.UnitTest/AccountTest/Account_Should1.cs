using LibrarySystem.Models;
using LibrarySystem.Models.Accounts;
using LibrarySystem.Models.Contracts.Accounts;
using LibrarySystem.Services.Contracts.Accounts;
using LibrarySystem.Services.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace LibrarySystem.UnitTest.AccountTest
{
    [TestClass]
    public class Account_Should1
    {
        [TestMethod]
        public void Account_ToString_Test()
        {
            var username = "Test";
            var accountType = AccountType.Librarian;
            var pass = "12345";

            var expexted = $"Username: {username}{Environment.NewLine}Type: {accountType} ";

            var sut = new Account(username, pass, accountType);
            var result = sut.ToString();

            Assert.AreEqual(expexted, result);
        }

     //  [TestMethod]
     //  public void CreateAccountLibrarian_Test()
     //  {
     //      var username = "Test";
     //      var accountType = AccountType.Librarian;
     //      var password = "12345";
     //
     //      var factoryMock = new Mock<IAccountFactory>();
     //
     //      var sut = new AccountService(factoryMock.Object);
     //      sut.CreateAccount(username, password, accountType);
     //
     //      Assert.IsInstanceOfType(sut, typeof(AccountService));
     //  }
        [TestMethod]
        public void ValidateUsernameMember_Test()
        {
            var userName = "test name";
            var password = "12345";

            var sut = new Member(userName, password);

            Assert.AreEqual("test name", sut.UserName);
        }

     //  [TestMethod]
     //  public void CreateAccountMember_Test()
     //  {
     //      var username = "Test";
     //      var accountType = AccountType.Member;
     //      var password = "12345";
     //
     //      var factoryMock = new Mock<IAccountFactory>();
     //
     //      var sut = new AccountService(factoryMock.Object);
     //      sut.CreateAccount(username, password, accountType);
     //
     //      Assert.IsInstanceOfType(sut, typeof(AccountService));
     //  }
        [TestMethod]
        public void ValidateCorrectUsernameLibrarian_Test()
        {
            var userName = "TestName";
            var password = "12345";

            var sut = new Librarian(userName, password);

            Assert.AreEqual("TestName", sut.UserName);
        }



        [DataTestMethod]
        [DataRow(AccountType.Librarian, true)]
        [DataRow(AccountType.Member, false)]
        public void CanEditBook_Test(AccountType accountType, bool expected)
        {
            var sut = new Mock<Account>("testUser", "12345", accountType).Object;
            Assert.AreEqual(expected, sut.CanEditBook);
        }

        [DataTestMethod]
        [DataRow(AccountType.Librarian, true)]
        [DataRow(AccountType.Member, true)]
        public void CanCheckOutBook_Test(AccountType accountType, bool expected)
        {
            var sut = new Mock<Account>("testUser", "12345", accountType).Object;
            Assert.AreEqual(expected, sut.CanCheckOutBook);
        }

        [DataTestMethod]
        [DataRow(AccountType.Librarian, true)]
        [DataRow(AccountType.Member, false)]
        public void CanEditUsers_Test(AccountType accountType, bool expected)
        {
            var sut = new Mock<Account>("testUser", "12345", accountType).Object;
            Assert.AreEqual(expected, sut.CanEditUsers);
        }

        [DataTestMethod]
        [DataRow(AccountType.Librarian, true)]
        [DataRow(AccountType.Member, false)]
        public void CanRegisterUsers_Test(AccountType accountType, bool expected)
        {
            var sut = new Mock<Account>("testUser", "12345", accountType).Object;
            Assert.AreEqual(expected, sut.CanRegisterUsers);
        }

        [DataTestMethod]
        [DataRow(AccountType.Librarian, true)]
        [DataRow(AccountType.Member, true)]
        public void CanReserveBook_Test(AccountType accountType, bool expected)
        {
            var sut = new Mock<Account>("testUser", "12345", accountType).Object;
            Assert.AreEqual(expected, sut.CanReserveBook);
        }

        [DataTestMethod]
        [DataRow(AccountType.Librarian, true)]
        [DataRow(AccountType.Member, true)]
        public void CanRenewBook_Test(AccountType accountType, bool expected)
        {
            var sut = new Mock<Account>("testUser", "12345", accountType).Object;
            Assert.AreEqual(expected, sut.CanRenewBook);
        }

        [DataTestMethod]
        [DataRow(AccountType.Librarian, true)]
        [DataRow(AccountType.Member, true)]
        public void CanReturnBook_Test(AccountType accountType, bool expected)
        {
            var sut = new Mock<Account>("testUser", "12345", accountType).Object;
            Assert.AreEqual(expected, sut.CanReturnBook);
        }

        [DataTestMethod]
        [DataRow(AccountType.Librarian, true)]
        [DataRow(AccountType.Member, true)]
        public void CanSearchTheCatalogue_Test(AccountType accountType, bool expected)
        {
            var sut = new Mock<Account>("testUser", "12345", accountType).Object;
            Assert.AreEqual(expected, sut.CanSearchTheCatalogue);
        }

        [DataTestMethod]
        [DataRow(AccountType.Librarian, true)]
        [DataRow(AccountType.Member, true)]
        public void CanLogOut_Test(AccountType accountType, bool expected)
        {
            var sut = new Mock<Account>("testUser", "12345", accountType).Object;
            Assert.AreEqual(expected, sut.LoggOut);
        }

        [DataTestMethod]
        [DataRow(AccountType.Librarian, true)]
        [DataRow(AccountType.Member, false)]
        public void CanAddBook_Test(AccountType accountType, bool expected)
        {
            var sut = new Mock<Account>("testUser", "12345", accountType).Object;
            Assert.AreEqual(expected, sut.CanAddBook);
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ThrowInvalidOperationExceptionWhenAccountTypeIsInvalid_Test()
        {
            var username = "Test";
            var accountType = (AccountType)2;
            var password = "12345";

            var factoryMock = new Mock<IAccountFactory>();

            var accountMock = new Mock<IAccount>();
            accountMock.Setup(atype => atype.Type)
                .Returns(accountType);

            var sut = new AccountService(factoryMock.Object);
            sut.CreateAccount(username, password, accountMock.Object.Type);
        }
    }
}