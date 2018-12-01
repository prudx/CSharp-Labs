using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//      HELLO 
//      PLEASE PUT THIS INTO VISUAL STUDIO 2017 AS CODILITY DOESN'T WANT TO COMPILE IT
//      CREATE A CONSOLE APP(.NET FRAMEWORK), PASTE IN MY CODE AND RUN. THANK YOU.
//      -DANIEL MAGUIRE
namespace Q2
{
    class Solution
    {
        List<List<string>> Log { get; set; }
        List<string> Time { get; set; }
        List<string> PhoneNumber { get; set; }
        int bill;
        int hours, minutes, seconds;

        public Solution()
        {
            Log = new List<List<string>>();
            Time = new List<string>();
            PhoneNumber = new List<string>();
        }

        public int solution(string s)
        {
            List<string> Temp = new List<string>();
            Temp = s.Split('\n').ToList<string>();
            Temp = s.Split(',').ToList<string>();

            //add times
            for (int i = 0; i < Temp.Count; i++)
            {
                //make sure we're incrementing by 2 since theres going to be 2 columns in our list
                if (IsOdd(i) == true) { i++; };
                Time.Add(Temp.ElementAt(i));
                PhoneNumber.Add(Temp.ElementAt(i + 1));
            }

            //testing temps values
            Console.WriteLine(Temp.ElementAt(0));
            Console.WriteLine(Temp.ElementAt(1));
            Console.WriteLine(Temp.ElementAt(2));
            Console.WriteLine(Temp.ElementAt(3));

            return 0;
        }


        //Abandoned method below, may return if the above idea doesn't pan out

        /*public void calculateBill()
        {
            List<int> Time = new List<int>();   //time in int format hhmmss
            List<string> Temp = new List<string>();   //maniputlating

            for (int i = 0; i < Log.Count; i++)
            {
                string[] garbage;
                garbage = Log.ElementAt(i).Split(':');

                //hours = Convert.ToInt32(garbage[i]);
                //minutes = int.Parse(garbage[i+1]);
                //seconds = int.Parse(garbage[i+2]);

                Console.WriteLine(garbage[i]);
            }
        }*/

        public override string ToString()
        {
            foreach (List<string> s in Log)
            {
                Console.WriteLine(s);
            }
            return "";
        }

        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }
    }

    class Test
    {
        static void Main()
        {
            Solution s1 = new Solution();

            Console.WriteLine(s1.solution("00:01:07,400-234-090\n" +
                                          "00:05:07,701-080-080\n" +
                                          "00:05:00,400-234-090\n"));

            Console.WriteLine(s1.ToString());
        }
    }
}
