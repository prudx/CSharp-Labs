// CA1 Sample Solution - GC

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SportsClub;

// test program
class Test
{
    static void Main()
    {
        try
        {
            // create 2 players
            SoccerPlayer rooney = new SoccerPlayer { Name = "Wayne Rooney", Age = 26, Gender = Gender.Male, Position = SoccerPosition.Striker };
            SoccerPlayer rio = new SoccerPlayer { Name = "Rio Ferdinand", Age = 33, Gender = Gender.Male, Position = SoccerPosition.Defender };

            // create a team
            SoccerTeam manu = new SoccerTeam("Manchester United 1st Team", Gender.Male, SoccerTeam.NoAgeLimit);

            // add players
            manu.AddPlayer(rooney);
            manu.AddPlayer(rio);

            // print details of team
            Console.WriteLine("Team: " + manu.TeamName);
            foreach (SoccerPlayer player in manu)               // use iterator
            {
                Console.WriteLine(player);
            }

            // try to find a player
            Console.WriteLine("Found:");
            SoccerPlayer p = manu["Wayne rooney"];              // use indexer
            Console.WriteLine(p);

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}