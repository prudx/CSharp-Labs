// "New Project - Class Library" SportsClubTest, added to same solution
// nUnit testing framework
// tests run externally to VS using uUnit GUI tool

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SportsClub;                       // add a reference to SportsClub project
using NUnit.Framework;                  // add a reference to C:\Program Files\NUnit 2.5.9\bin\net-2.0\framework\nunit.framework.dll

namespace SportsClubTest
{
    [TestFixture]                       // a class containing a group of unit tests, must have a public default constructor
    public class SportsTest
    {
        // a test fixture can have a [Setup] part, will have [Test] parts, and can have a [TearDown] part

        private SoccerPlayer rooney, rio, berbatov;

        [SetUp]
        public void Setup()
        {
            // create some players
            rooney = new SoccerPlayer { Name = "Wayne Rooney", Age = 26, Gender = Gender.Male, Position = SoccerPosition.Striker };
            rio = new SoccerPlayer { Name = "Rio Ferdinand", Age = 33, Gender = Gender.Male, Position = SoccerPosition.Defender };
            berbatov = new SoccerPlayer { Name = "Dimitar Berbatov", Age = 33, Gender = Gender.Male, Position = SoccerPosition.Striker };
        }

        
        // a test is for a unit of functionality i.e. a method
        [Test]
        public void Test1()             // all unit tests must have no args and return void, must have at least 1 assert

        {
            // postcondition assertion for test to pass
            Assert.AreNotEqual(rooney, rio);                   
        }

        [Test (Description="Test 2 separate strikers of same age and gender are not equal")]
        public void Test2()             
        {
            Assert.AreNotEqual(rooney, berbatov);
        }

        [Test(Description = "Test 2 separate strikers with same data are equal")]
        public void Test3()            
        {
            SoccerPlayer rooney1 = new SoccerPlayer { Name = "Wayne Rooney", Age = 26, Gender = Gender.Male, Position = SoccerPosition.Striker };
            SoccerPlayer rooney2 = new SoccerPlayer { Name = "Wayne Rooney", Age = 26, Gender = Gender.Male, Position = SoccerPosition.Striker };
            Assert.AreEqual(rooney1, rooney2);
        }

        [Test]
        public void Test4()            
        {
            SoccerPlayer rooney2 = rooney;
            Assert.AreEqual(rooney2, rooney);
        }

        [Test(Description = "Test age limit for a team")]
        [ExpectedException(typeof(ArgumentException))]
        public void Test5()
        {
            SoccerTeam boys = new SoccerTeam("Manchester United Boys", Gender.Male, 14);
            boys.AddPlayer(rooney);                 // too old
        }

        [Test(Description = "Test gender for a team")]
        [ExpectedException(typeof(ArgumentException))]
        public void Test6()
        {
            SoccerTeam girls = new SoccerTeam("Manchester United Girls", Gender.Female, 14);
            girls.AddPlayer(rooney);                // not female
        }

        [Test(Description = "Test player can be only in a team once")]
        [ExpectedException(typeof(ArgumentException))]
        public void Test7()
        {
            SoccerTeam manu = new SoccerTeam("Manchester United", Gender.Male, SoccerTeam.NoAgeLimit);
            manu.AddPlayer(rooney);
            manu.AddPlayer(rooney);              // already in team
        }

        [Test(Description = "Test add works for valid player, and player can be retrieved using indexer")]
        public void Test8()
        {
            // add 2 players, test they were added to the collection, and test indexer based on name (case insensitive)
            SoccerTeam manu = new SoccerTeam("Manchester United", Gender.Male, SoccerTeam.NoAgeLimit);
            manu.AddPlayer(rooney);
            manu.AddPlayer(rio);
            CollectionAssert.Contains(manu.Players, rooney);
            CollectionAssert.Contains(manu.Players, rio);
            Assert.AreEqual(rooney, manu[rooney.Name]);
            Assert.AreEqual(rooney, manu[rooney.Name.ToUpper()]);
        }

        // should check code coverage for test using a tool like NCover
    }
}
