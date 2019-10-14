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
        public void Account_ToString_Test() // kachen v originala
        {
            var username = "Test";
            var accountType = AccountType.Librarian;

            var expexted = $"Username: {username}{Environment.NewLine}Type: {accountType} ";

            var sut = new Account(username, accountType);
            var result = sut.ToString();

            Assert.AreEqual(expexted, result);
        }

        [TestMethod]
        public void CreateAccountLibrarian_Test() 
        {
            var username = "Test";
            var accountType = AccountType.Librarian;

            var sut = new AccountService();
            sut.CreateAccount(username, accountType);

            Assert.IsInstanceOfType(sut, typeof(AccountService));
        }

        [TestMethod]
        public void CreateAccountMember_Test()  
        {
            var username = "Test";
            var accountType = AccountType.Member;

            var sut = new AccountService();
            sut.CreateAccount(username, accountType);

            Assert.IsInstanceOfType(sut, typeof(AccountService));
        }

        [TestMethod]
        public void LoginTestWhenUsernameIsValid_Test()   
        {
            var username = "Test";

            var accountMock = new Mock<IAccount>();
            accountMock.Setup(userName => userName.UserName)
                .Returns(username);

            var accountList = new List<IAccount>();
            accountList.Add(accountMock.Object);

            var sut = new AccountService(accountList);
            var result = sut.Login(username);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LoginTestWhenUsernameIsNull_Test()
        {
            string username = null;
            var accountMock = new Mock<IAccount>();
            accountMock.Setup(account => account.UserName)
                .Returns(username);

            var accountList = new List<IAccount>();
            accountList.Add(accountMock.Object);

            var sut = new AccountService(accountList);
            var result = sut.Login(username);

            Assert.IsTrue(result);
        }

        [DataTestMethod]
        [DataRow(AccountType.Librarian, true)]
        [DataRow(AccountType.Member, false)]
        public void CanEditBook_Test(AccountType accountType, bool expected)
        {
            var sut = new Mock<Account>("testUser", accountType).Object;
            Assert.AreEqual(expected, sut.CanEditBook);
        }

        [DataTestMethod]
        [DataRow(AccountType.Librarian, true)]
        [DataRow(AccountType.Member, true)]
        public void CanCheckOutBook_Test(AccountType accountType, bool expected)
        {
            var sut = new Mock<Account>("testUser", accountType).Object;
            Assert.AreEqual(expected, sut.CanCheckOutBook);
        }

        [DataTestMethod]
        [DataRow(AccountType.Librarian, true)]
        [DataRow(AccountType.Member, false)]
        public void CanEditUsers_Test(AccountType accountType, bool expected)
        {
            var sut = new Mock<Account>("testUser", accountType).Object;
            Assert.AreEqual(expected, sut.CanEditUsers);
        }

        [DataTestMethod]
        [DataRow(AccountType.Librarian, true)]
        [DataRow(AccountType.Member, false)]
        public void CanRegisterUsers_Test(AccountType accountType, bool expected)
        {
            var sut = new Mock<Account>("testUser", accountType).Object;
            Assert.AreEqual(expected, sut.CanRegisterUsers);
        }

        [DataTestMethod]
        [DataRow(AccountType.Librarian, true)]
        [DataRow(AccountType.Member, true)]
        public void CanReserveBook_Test(AccountType accountType, bool expected)
        {
            var sut = new Mock<Account>("testUser", accountType).Object;
            Assert.AreEqual(expected, sut.CanReserveBook);
        }

        [DataTestMethod]
        [DataRow(AccountType.Librarian, true)]
        [DataRow(AccountType.Member, true)]
        public void CanRenewBook_Test(AccountType accountType, bool expected)
        {
            var sut = new Mock<Account>("testUser", accountType).Object;
            Assert.AreEqual(expected, sut.CanRenewBook);
        }

        [DataTestMethod]
        [DataRow(AccountType.Librarian, true)]
        [DataRow(AccountType.Member, true)]
        public void CanReturnBook_Test(AccountType accountType, bool expected)
        {
            var sut = new Mock<Account>("testUser", accountType).Object;
            Assert.AreEqual(expected, sut.CanReturnBook);
        }

        [DataTestMethod]
        [DataRow(AccountType.Librarian, true)]
        [DataRow(AccountType.Member, true)]
        public void CanSearchTheCatalogue_Test(AccountType accountType, bool expected)
        {
            var sut = new Mock<Account>("testUser", accountType).Object;
            Assert.AreEqual(expected, sut.CanSearchTheCatalogue);
        }

        [DataTestMethod]
        [DataRow(AccountType.Librarian, true)]
        [DataRow(AccountType.Member, true)]
        public void CanLogOut_Test(AccountType accountType, bool expected)
        {
            var sut = new Mock<Account>("testUser", accountType).Object;
            Assert.AreEqual(expected, sut.LoggOut);
        }

        [DataTestMethod]
        [DataRow(AccountType.Librarian, true)]
        [DataRow(AccountType.Member, false)]
        public void CanAddBook_Test(AccountType accountType, bool expected)
        {
            var sut = new Mock<Account>("testUser", accountType).Object;
            Assert.AreEqual(expected, sut.CanAddBook);
        }

        [TestMethod]
        public void CurrentAccountTest()
        {
            var username = "Test";

            var accountMock = new Mock<IAccount>();
            accountMock.Setup(userName => userName.UserName)
                .Returns(username);

            var accountList = new List<IAccount>();
            accountList.Add(accountMock.Object);

            var users = new AccountService(accountList);
            var sut = users.Login(username);

            Assert.AreEqual("Test", users.CurrentAccount.UserName);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ThrowInvalidOperationExceptionWhenAccountTypeIsInvalid_Test()
        {
            var username = "Test";
            var accountType = (AccountType)2;

            var accountMock = new Mock<IAccount>();
            accountMock.Setup(atype => atype.Type)
                .Returns(accountType);

            var sut = new AccountService();
            sut.CreateAccount(username, accountMock.Object.Type);
        }
    }
}