// via Test Menu "New Test", select Unit Test and add new Test project

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;         // Microsoft Unit Testing framework

using SportsClub;  

namespace SportsClubTest
{
    /// <summary>
    /// Summary description for Test
    /// </summary>
    [TestClass]
    public class Test
    {
        private SoccerPlayer rooney, rio;

        public Test()
        {
            // create some players
            rooney = new SoccerPlayer { Name = "Wayne Rooney", Age = 26, Gender = Gender.Male, Position = SoccerPosition.Striker };
            rio = new SoccerPlayer { Name = "Rio Ferdinand", Age = 33, Gender = Gender.Male, Position = SoccerPosition.Defender };
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Test1()
        {
            Assert.AreNotEqual(rooney, rio);  
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test2()
        {
            SoccerTeam boys = new SoccerTeam("Manchester United Boys", Gender.Male, 14);
            boys.AddPlayer(rooney);                 // too old
        }
    }
}

// can check code coverage stats within VS 2010 - Ultimate or Premium
// Edit Test Settings for Local(local.testsettings), Data and Diagnostics, and select Code Coverage and Configure .dll for sportsclub project to be checked
// and then Run tests and view results - (Code Coverage Results Window under Test menu) i.e. 35.48% here