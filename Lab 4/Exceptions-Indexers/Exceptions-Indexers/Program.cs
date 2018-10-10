using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions_Indexers
{
    class Calculator
    {
        public static float DivideFloatPointNumbers(float a, float b)
        {
            if (b == 0)
            {
                throw new ArgumentException("Cannot divide by 0");
            }
            else return a / b;
        }
    }

    class ModuleAssessmentResult
    {
        public string StudentName { get; set; }
        public string ModuleName { get; set; }
        public int ModuleCredits { get; set; }


        private const int MAX = 10;
        private double[] results = new double[MAX];
        private int next = 0;

        

        public double this[int i]
        {
            get
            {
                if (i >= 0 && i < results.Length - 1)
                {
                    return results[i];
                }
                else
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
            }
            set
            {
                foreach (double s in results)
                {
                    
                    if (i == next)
                    {
                        next++;
                    }
                    if (results[i - 1] == 0)
                    {
                        results[i - 1] = value;
                    }
                    else if (results[i] == 0)
                    {
                        results[i - 1] = value;
                    }
                }
            }
        }

        public override string ToString()
        {
            string output = "Student name: "+StudentName+"\nModule: "+ModuleName+"\nModule Credits: "+ModuleCredits
                +"\nAssessment Results: \n";
            for (int i = 0; i < results.Length-1; i++)
            {
                output += results[i] + " ";
            }
            return output;
        }
    }
    
    class Test
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter two decimal numbers, pressing enter after each:");

            float f1 = float.Parse(Console.ReadLine());
            float f2 = float.Parse(Console.ReadLine());

            Console.WriteLine(Calculator.DivideFloatPointNumbers(f1, f2));

            try
            {
                ModuleAssessmentResult results = new ModuleAssessmentResult() { StudentName = "Daniel Maguire", ModuleName = "Enterprise App Dev 1", ModuleCredits = 5  };
                results[1] = 20;                    // new result for CA1
                results[2] = 40;
                results[3] = 60;
                results[1] = 25;                    // overwrite
                results[3] = 65;                    // overwrite
                results[4] = 99;

                Console.WriteLine(results);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
