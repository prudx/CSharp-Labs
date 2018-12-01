using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net;
using System.Collections;

namespace ServerProgram
{
    public abstract class Server : IComparable<IPAddress>
    {
        string serverName;
        IPAddress ip;

        public string ServerName
        {
            get
            {
                return serverName;
            }
            private set
            {
                if (Regex.IsMatch(value, @"^[a-zA-Z0-9]+$")) //&& 0 < value.Count < 16
                {
                    serverName = value;
                }
                else
                {
                    throw new Exception("Name must be alphanumeric");
                }
            }
        }

        public IPAddress IP
        {
            get
            {
                return ip;
            }
            private set
            {
                if (value != null) //test this
                {
                    ip = value;
                }
            }
        }

        public Server(string name, IPAddress ip)
        {
            ServerName = name;
            IP = ip;
        }

        public abstract string Restart();

        public override string ToString()
        {
            return "Sever Name: " + ServerName + "\nIP Address: " + IP;
        }

        public int CompareTo(IPAddress other)
        {
            byte[] first = IP.GetAddressBytes();
            byte[] second = other.GetAddressBytes();
            return first.Zip(second, (a, b) => a.CompareTo(b))
                        .FirstOrDefault(c => c != 0);
        }
    }

    public enum Distro { Debian, Ubuntu, SUSE, RedHat, CentOS, Fedora }

    public class LinuxServer : Server
    {
        private Distro LinuxType { get; } //maybe come back if cant set

        public LinuxServer(string serverN, IPAddress ip, Distro d) : base(serverN, ip)
        {
            LinuxType = d;
        }

        public override string ToString()
        {
            return base.ToString() + "\nLinux Distro: " + LinuxType; //overide base aswell
        }

        public override string Restart()
        {
            return "Restarting Linux ["+ServerName+"] "+IP+" "+LinuxType+"with / sbin / shutdown -r now";
        }
    }

    public class WindowsServer : Server
    {
        public WindowsServer(string name, IPAddress ip) : base(name, ip)
        {

        }

        public override string ToString()
        {
            return base.ToString()+"\nWindows Server";
        }

        public override string Restart()
        {
            return "Restarting Windows [" + ServerName + "] " + IP +" with rundll32.exe,shell32.dll,SHExitWindowsEx 2";
        }
    }

    public class ServerFarm : IEnumerable
    {
        List<Server> mainframe;

        public ServerFarm()
        {
            mainframe = new List<Server>();
        }

        public void AddServer(Server s)
        {
            var ipLookup = mainframe.Where(m => m.IP == s.IP); //query for filter

            if (!mainframe.Any())
            {
                mainframe.Add(s);
            }
            else if (!ipLookup.Any())
            {
                mainframe.Add(s);
            }
            else
            {
                throw new Exception("Unknown Error");
            }
   
        }

        public IEnumerator GetEnumerator()
        {
            foreach(Server i in mainframe)
            {
                yield return i;
            }
        }

        public string Restart()
        {
            //ran out of time
            var allIPAddressOrdered = mainframe.Select(mf => mf.IP).OrderBy(ip => ip);  
            foreach(IPAddress i in allIPAddressOrdered)
            {
                Console.WriteLine(i);
            }
            return "";
        }


    }

    public class Test
    {
        public static void Main()
        {
            IPAddress ip1 = new IPAddress(new byte[] { 192, 168, 20, 11 });
            IPAddress ip2 = new IPAddress(new byte[] { 192, 168, 20, 12 });
            IPAddress ip3 = new IPAddress(new byte[] { 192, 168, 20, 13 });
            IPAddress ip4 = new IPAddress(new byte[] { 192, 168, 20, 14 });



            LinuxServer s1 = new LinuxServer("DanielsServer", ip2, Distro.RedHat);
            WindowsServer s2 = new WindowsServer("A1Server", ip1);
            LinuxServer s3 = new LinuxServer("DanielsServer", ip4, Distro.CentOS);
            WindowsServer s4 = new WindowsServer("A1Server", ip3);


            ServerFarm sf1 = new ServerFarm();

            sf1.AddServer(s1);
            sf1.AddServer(s2);
            sf1.AddServer(s3);
            sf1.AddServer(s4);

            foreach(Server i in sf1)
            {
                Console.WriteLine(i);
            }

            //sf1.Restart();
        }
    }


}

    
