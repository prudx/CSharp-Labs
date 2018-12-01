using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

//Daniel Maguire - X00127907 - 18th October 2018

namespace CA1
{
    class LotteryDraw
    {
        public List<int> NumbersDrawn { get; }
        public int MaxNumber { get; private set; } //privately settable

        public LotteryDraw(int maxNum)
        {
            MaxNumber = maxNum;
            NumbersDrawn = new List<int>();        //constructor initializes list 
        }

        public void Draw(int amtDraws)
        {
            /*
            using a for loop instead of foreach as i want to manipulate the
            index easily if there is a duplicate */
            for (int i = 0; i < amtDraws; i++)
            {
                Random rn = new Random();
                int draw = rn.Next(1, MaxNumber);
                if (NumbersDrawn.Contains(draw))
                {
                    i--;
                }
                else
                {
                    NumbersDrawn.Add(draw);
                }
            }
            NumbersDrawn.Sort();
        }

        //formatted console output displaying info
        public override string ToString()
        {
            Console.WriteLine("Draws for this evening: ");
            foreach (var n in NumbersDrawn)
            {
                Console.WriteLine(n);
            }
            return "\nThe maximum draw is: " + MaxNumber +"\n";
        }
    }

    class LotteryDrawHistory
    {
        public List<LotteryDraw> DrawHistory { get; }

        
        public LotteryDrawHistory()
        {
            DrawHistory = new List<LotteryDraw>();
        }

        public void AddLotteryDraw(LotteryDraw l)
        {
            //will come back to add the complexity of restrictions
            DrawHistory.Add(l);
        }

        public void FrequentNum(List<LotteryDraw> d)
        {
            //going to collect all the ints in this collection
            List<int> collection = new List<int>();

            //nested for loop to iterate on NumbersDrawn then to iterate on the ints
            //in NumbersDrawn and add them all to the collection 
            for (int i = 0; i < d.Count; i++)
            {
                for (int j = 0; j < d[i].NumbersDrawn.Count; j++)
                {
                    collection.Add(d[i].NumbersDrawn[j]);
                }
            }
            collection.Sort();

            //output
            foreach (var c in collection)
            {
                Console.WriteLine(c);
            }
            //return collection;
        }

        public override string ToString()
        {
            foreach (var d in DrawHistory)
            {
                Console.WriteLine(d);
            }
            return "";
        }
    }

    class Test
    {
        public static void Main()
        {
            try
            {
                LotteryDraw l1 = new LotteryDraw(47);
                LotteryDraw l2 = new LotteryDraw(47);
                LotteryDraw l3 = new LotteryDraw(47);

                //Console.WriteLine(l1.MaxNumber);
                //validated input is as expected

                //l1.Draw(6);
                //Console.WriteLine(l1.ToString());


                //Console.WriteLine(l1.NumbersDrawn.Count());
                //validated list is of correct size (dependent on draw parm)

                //drawing numbers
                l1.Draw(6);
                l2.Draw(6);
                l3.Draw(6);

                LotteryDrawHistory ldh1 = new LotteryDrawHistory();
                
                ldh1.AddLotteryDraw(l1);
                ldh1.AddLotteryDraw(l2);
                ldh1.AddLotteryDraw(l3);

                Console.WriteLine(ldh1.ToString());

                //Console.WriteLine(ldh1.DrawHistory[0]);

                //frequency outputs sorted collection of int, can currently only
                //scan with eyes to see duplicates
                ldh1.FrequentNum(ldh1.DrawHistory);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
