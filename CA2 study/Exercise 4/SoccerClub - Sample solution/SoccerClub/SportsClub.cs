// CA1 Sample Solution - GC
// A soccer team contains soccer players who are special types of sports players

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SportsClub
{
    public enum Gender { Male, Female }

    public abstract class SportsPlayer                                      // a player of sports, cannot be instantiated
    {
        // auto-implemented properties

        public String Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }

        // constructor
        protected SportsPlayer(String name, int age, Gender gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        // inherited member from Object
        public override string ToString()
        {
            return "Name: " + Name + " Age: " + Age + " Gender: " + Gender;
        }
    }

    // valid positions for a soccer player
    public enum SoccerPosition { Goalkeeper, Defender, Midfielder, Striker }

    public class SoccerPlayer : SportsPlayer                            // "isa SportsPlayer"
    {
        public SoccerPosition Position { get; set; }


        // default constructor
        public SoccerPlayer() : this ("", 0, Gender.Male, SoccerPosition.Defender)          // chain
        {
        }

        // constructor
        public SoccerPlayer(String name, int age, Gender gender, SoccerPosition position) : base(name, age, gender)
        {
            this.Position = position;
        }


        // custom equality comparison for .Equals, used by Contains() on List<>
        public override bool Equals(Object obj)
        {
            SoccerPlayer player = obj as SoccerPlayer;

            if (player == null)
            {
                return false;
            }

            // must match all 4 attributes to be equal
            if ((player.Name == this.Name) && (player.Age == this.Age) && (player.Gender == this.Gender) && (player.Position == this.Position))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // needed if overriding Equals
        public override int GetHashCode()
        {
            // return a hash (key) value for this object

            return Name.GetHashCode() + Age.GetHashCode() + Gender.GetHashCode() + Position.GetHashCode();
        }

        // inherited member from Object
        public override string ToString()
        {
            return base.ToString() + " Position: " + Position;
        }
    }

    // a whole soccer team ("foreign game") :-)
    public class SoccerTeam : IEnumerable                           // SoccerTeam is an enumerable type i.e. supports foreach
    {
        public const int MinAge = 5;                                // minimum age limit for a team
        public const int NoAgeLimit = Int32.MaxValue;               // a team with no minimum age - sentinel value

        public String TeamName { get; set; }                        // name of the team
        public Gender TeamGender { get; set; }                      // male or female team, no mixed gender teams allowed

        private int ageLimit;                                       // age limit for players on the team

        // player collection
        private List<SoccerPlayer> players;

        // constructor
        public SoccerTeam(String teamName, Gender teamGender, int ageLimit)
        {
            this.TeamName = teamName;
            this.TeamGender = teamGender;
            this.AgeLimit = ageLimit;

            this.players = new List<SoccerPlayer>();
        }

        // read only property to get players collection
        public Collection<SoccerPlayer> Players
        {
            get
            {
                return new Collection<SoccerPlayer> (players);
            }
        }

        // read/write property for ageLimit for a team
        public int AgeLimit
        {
            get
            {
                return ageLimit;
            }
            set
            {
                if (value >= MinAge)
                {
                    this.ageLimit = value;
                }
                else
                {
                    throw new ArgumentException("Exception: Age Limit for a Team must be >= " + MinAge);
                }
            }
        }

        // indexer property, return a player with specified name
        public SoccerPlayer this[String playerName]
        {
            get
            {
                SoccerPlayer player = null;
                Boolean found = false;

                for (int i = 0; i < players.Count; i++)
                {
                    if (String.Compare(players[i].Name, playerName, StringComparison.OrdinalIgnoreCase) == 0)             // ignore case in comparison
                    {
                        found = true;
                        player = players[i];
                    }
                }
                if (found)
                {
                    return player;
                }
                else
                {
                    throw new ArgumentException("Exception: Player " + playerName + " is not in the soccer team " + TeamName);
                }
            }
        }

        // iterate over players collection
        public IEnumerator GetEnumerator()
        {
            foreach (SoccerPlayer player in players)
            {
                yield return player;
            }
        }


        // add a player to the team, if not already in the team
        public void AddPlayer(SoccerPlayer player)
        {

            if (players == null)                            // empty
            {
                players.Add(player);
            }
            else
            {
                if (players.Contains(player))               // already in the team, Contains uses Equals for SoccerPlayer to test presence
                {
                    throw new ArgumentException("Exception: player " + player.Name + " is already in the team");
                }
                else
                {
                    // add the plater
                    if (player.Gender == TeamGender)
                    {
                        if (player.Age <= AgeLimit)
                        {
                            players.Add(player);
                        }
                        else
                        {
                            throw new ArgumentException("Exception: player " + player.Name + " is too old for team " + TeamName);
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Exception: player " + player.Name + " is " + player.Gender + " while team is " + TeamGender);
                    }

                }
            }
        }

    }
}
