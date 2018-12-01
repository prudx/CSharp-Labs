using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports
{
    public enum Gender { m, f }

    public abstract class SportsPlayer
    {
        string Name { get; set; }
        int Age { get; set; }
        Gender Gend { get; set; }

        public SportsPlayer(string name, int age, Gender gender)
        {
            Name = name;
            Age = age;
            Gend = gender;
        }

        public override string ToString()
        {
            return "\nName: " + Name + "\nAge: " + Age + "\nGender: " + Gend;
        }
    }

    public enum Position {goalkeeper, defender, midfielder, striker}

    public class SoccerPlayer : SportsPlayer
    {
        Position PlayingPosition { get; set; }

        public SoccerPlayer (string name, int age, Gender gender, Position p) : base(name, age, gender)
        {
            PlayingPosition = p;
        }
        public SoccerPlayer () : base ("",0,Gender.m) 
        {
            PlayingPosition = Position.defender;
        }

        public override string ToString()
        {
            return base.ToString() +"\nPlaying Position: "+PlayingPosition;
        }
    }

    public class SoccerTeam : IEnumerable
    {
        string TeamName { get; set; }
        Gender TeamGender { get; set; }
        int ageLimit;
        List<SoccerPlayer> TeamRoster;

        int AgeLimit
        {
            get
            {
                return ageLimit;
            }
            set
            {
                if (value < 5)
                {
                    throw new Exception("Below age limit");
                }

            }
        }

        public SoccerTeam(string teamName, Gender teamGender, int aLimit)
        {
            TeamName = teamName;
            TeamGender = teamGender;
            AgeLimit = aLimit;
            TeamRoster = new List<SoccerPlayer>();
        }

        public IEnumerator GetEnumerator()
        {
            foreach (SoccerPlayer p in TeamRoster)
            {
                yield return p;
            }
        }

        public IEnumerable<SoccerPlayer> this[string name]
        {
            get
            {
                var player = TeamRoster.Contains(tr => TeamRoster. == name);           // LINQ query, select the whole music file
                return player;
            }
        }
    }

    public class Test
    {
        static void Main()
        {
        }
    }
}
