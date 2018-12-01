using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Codility
    {
        public int hours, minutes, seconds;

        public string solution(int a, int b, int c, int d, int e, int f)
        {
            List<int> numberCollection = new List<int> { a, b, c, d, e, f };
            numberCollection.Sort();

            hours = int.Parse(numberCollection[0].ToString() + numberCollection[1].ToString());
            minutes = int.Parse(numberCollection[2].ToString() + numberCollection[3].ToString());
            seconds = int.Parse(numberCollection[4].ToString() + numberCollection[5].ToString());

            if (hours > 23 || hours < 00)
            {   //I like to add \n at the end of return strings for neatness of console output
                return "Unable to create time from inputs\n";    
            }
            else if (minutes > 59 || minutes < 00)
            {
                return "Unable to create time from inputs\n";
            }
            else if (seconds > 59 || seconds < 00)
            {
                return "Unable to create time from inputs\n";
            } else
            {
                return "The shortest time possible is: " + hours.ToString("D2") + ":" 
                    + minutes.ToString("D2") + ":" + seconds.ToString("D2") + "\n";
            }
        }
    }

    class Test
    {
        static void Main()
        {
            Codility c1 = new Codility();

            //Test happy route
            Console.WriteLine(c1.solution(0, 1, 2, 3, 4, 5));
            
            //Testing sad route
            Console.WriteLine(c1.solution(9, 9, 9, 9, 9, 9));

            //Test sorting
            Console.WriteLine(c1.solution(3, 5, 3, 4, 1, 6));

            //Question specs
            Console.WriteLine(c1.solution(0, 0, 0, 0, 0, 0));
            Console.WriteLine(c1.solution(0, 0, 0, 7, 8, 9));    //COME BACK TO THIS AT THE END
            Console.WriteLine(c1.solution(2, 4, 5, 9, 5, 9));

            //Testing outputs of class vars
            //Console.WriteLine(c1.hours);
            //Console.WriteLine(c1.minutes);
            //Console.WriteLine(c1.seconds);
        }
    }
}
