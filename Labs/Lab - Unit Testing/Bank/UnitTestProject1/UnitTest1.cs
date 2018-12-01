using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;



namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        BankAccount b1 = new BankAccount(123456, 11112222);

        [TestMethod]
        public void TestDeposit1()
        {
            b1.Deposit(100);


            Assert.AreEqual(b1.Balance, 100);
        }

        [TestMethod]
        public void TestDeposit2()
        {
            b1.Deposit(100);

            Assert.AreEqual(200, b1.Balance);
        }


        [TestMethod]
        public void TestWithdraw1()
        {

        }
    }
}
