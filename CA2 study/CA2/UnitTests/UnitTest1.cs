using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServerProgram;
using System.Net;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddMethodAlphanumericyConstraint()  //server creation
        {
            IPAddress ip1 = new IPAddress(new byte[] { 192, 168, 20, 11 });

            //check non alphanumeric doesn't work
            Assert.ThrowsException<Exception>(() => {
               LinuxServer s1 = new LinuxServer("N@me with non alphanumeric", ip1, Distro.RedHat);
            });

            //Check alphanumeric works
            LinuxServer s2 = new LinuxServer("Alphanumeric1", ip1, Distro.RedHat);
        }

        [TestMethod]
        public void AddToServerFarmIPConstraint()   //serverfarm ip constraint
        {
            IPAddress ip1 = new IPAddress(new byte[] { 192, 168, 20, 11 });
            LinuxServer s1 = new LinuxServer("DanielsServer", ip1, Distro.RedHat);
            WindowsServer s2 = new WindowsServer("A1Server", ip1);

            ServerFarm sf1 = new ServerFarm();

            sf1.AddServer(s1);
            Assert.ThrowsException<Exception>(() => { sf1.AddServer(s2); });
        }


    }
}
