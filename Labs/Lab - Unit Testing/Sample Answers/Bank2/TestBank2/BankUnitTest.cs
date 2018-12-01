using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using Bank;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBank2
{
    [TestClass]
    public class BankUnitTest
    {
        [TestMethod]                                            
        public void TestDeposit1()
        {
            BankAccount acc = new BankAccount("903509", "12345");                    // 0 overdraft limit
            acc.Deposit(100);
            acc.Deposit(200);
            Assert.AreEqual(acc.Balance, 300);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]                                     
        public void CreateBankAccountWithInvalidOverdraftLimit()
        {
            BankAccount acc = new BankAccount("903509", "12345", -5000);             // -5000 overdraft limit
        }

        [TestMethod]
        public void TestDepositAndWithdrawal1()
        {
            BankAccount acc = new BankAccount("903509", "12345");
            acc.Deposit(100);
            acc.Withdraw(50);
            acc.Deposit(150);
            Assert.AreEqual(acc.Balance, 200);
        }

        [TestMethod]
        public void TestDepositAndWithdrawal2()                 // overdraw the account
        {
            BankAccount acc = new BankAccount("903509", "12345", 1000);
            acc.Deposit(100);
            acc.Withdraw(1000);
            Assert.AreEqual(acc.Balance, -900);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDepositAndWithdrawal3()
        {
            BankAccount acc = new BankAccount("903509", "12345", 1000);
            acc.Withdraw(2000);                                 // overdraft limit exceeded
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDepositAndWithdrawal4()
        {
            BankAccount acc = new BankAccount("903509", "12345", 0);
            acc.Deposit(-100);                                  // must be positive
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDepositAndWithdrawal5()
        {
            BankAccount acc = new BankAccount("903509", "12345");
            acc.Deposit(100);
            acc.Withdraw(0);                                    // must be positive
        }

        [TestMethod]
        public void TestTransactionHistory1()
        {
            BankAccount acc = new BankAccount("903509", "12345");
            acc.Deposit(100);
            acc.Withdraw(50);
            acc.Withdraw(10);
            acc.Deposit(100);
            Assert.AreEqual(acc.Balance, 140);
            CollectionAssert.AreEqual(acc.TransactionHistory, new List<double>() {100, -50, -10, 100} );       
        }

        [TestMethod]
        public void TestTransactionHistory2()
        {
            BankAccount acc = new BankAccount("903509", "12345");
            Assert.AreEqual(acc.Balance, 0);
            CollectionAssert.AreEqual(acc.TransactionHistory, new List<double>() {});
        }

    }
}
