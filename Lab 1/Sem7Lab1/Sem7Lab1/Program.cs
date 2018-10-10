using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem7Lab1
{
    public abstract class ThreeDShape
    {

        string shapeType;
        //readonly public string shapeTypeRead;

        public String Shape
        {
            get
            {
                return shapeType;
            }
        }

        public ThreeDShape (string shape)
        {
            this.shapeType = shape;
        }
        ~ThreeDShape() { }

        public abstract Double CalculateVolume();

        public override String ToString()
        {
            return "a "+ Shape +" shape";
        }
    }

    public class Sphere : ThreeDShape
    {
        private double radius;

        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                if (value > 0)
                {
                    radius = value;
                }
                else
                {
                    throw new ApplicationException("Radius must be positive");
                }
            }
        }


        public Sphere(double radius) : base("Sphere")
        {
            this.radius = radius;
        }

        public Sphere() : this(0) { }

        public override Double CalculateVolume()
        {
            return ((Math.PI) * (Radius * Radius * Radius) * 4 / 3);
        }

        /*      Shorter method of above ^
      
         public override double CalculateVolume() 
         {	
			return Math.PI * radius * radius * radius;
         }
         */

        public override String ToString()
        {
            return Shape.ToString() +" of radius: " +Radius.ToString();
        }
    }

    class Test
    {
        public static void Main()
        {
            Sem7Lab1.ThreeDShape[] collection = { new Sem7Lab1.Sphere(), new Sem7Lab1.Sphere(10) };

            foreach (Sem7Lab1.ThreeDShape s in collection)
            {
                Console.WriteLine(s + " volume: " + s.CalculateVolume());
            }
            
        }
    }
    
}
