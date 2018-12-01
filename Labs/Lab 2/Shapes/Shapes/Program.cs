using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Vertex
    {
        public int X { get; set; }
        public int Y { get; set; }


        public Vertex(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override String ToString()
        {
            return "Coords are ("+X+","+Y+")";
        }

    }

    public enum ShapeColor
    {
        Red, Green, Blue
    }

    public abstract class Shape
    {
        public ShapeColor color { get; set; }

        public Shape(ShapeColor c)
        {
            color = c;
        }    

        public override string ToString()
        {
            return "The color of the Shape is: " + color +"\n";
        }

        public abstract void Translate(Vertex amount);

    }

    public class Line : Shape
    {
        private Vertex v1, v2;
    
        public Line(int x1, int y1, int x2, int y2, ShapeColor colorIn) : base(colorIn)
        {
            v1 = new Vertex(x1, y1);
            v2 = new Vertex(x2, y2);
        }
        
        public int X1
        {
            get
            {
                return v1.X;
            }
            set
            {
                v1.X = value;
            }
        }

        public int Y1
        {
            get
            {
                return v1.Y;
            }
            set
            {
                v1.Y = value;
            }
        }

        public int X2
        {
            get
            {
                return v2.X;
            }
            set
            {
                v2.X = value;
            }
        }

        public int Y2
        {
            get
            {
                return v2.Y;
            }
            set
            {
                v2.Y = value;
            }
        }

        public override void Translate(Vertex amount)
        {
            v1.X += amount.X;
            v1.Y += amount.Y;
            v2.X += amount.X;
            v2.Y += amount.Y;
        }

        public override string ToString()
        {
            return base.ToString()+"Line is from ("+v1.X+","+v1.Y+") to ("+v2.X+","+v2.Y+")";
        }
    }

    public class Circle : Shape
    {
        private Vertex origin;
        private int Radius { get; set; }

        public Circle(int x1, int y1, int radius, ShapeColor c) : base(c)
        {
            origin = new Vertex(x1, y1);
            Radius = radius;
        }

        

        public override void Translate(Vertex amount)
        {
            origin.X += amount.X;
            origin.Y += amount.Y;
        }

        public double Area()
        {
            return Math.PI * (Radius * Radius);
        }

        public override string ToString()
        {
            return base.ToString() + "The origin of the Circle: (" + origin.X + "," + origin.Y + ")\n"+"The radius of the Circle is: "+Radius;
        }
    }

    class Test
    {
        static void Main(string[] args)
        {

            //test vertex class
            Vertex v1 = new Vertex(4, 6);
            Vertex v2 = new Vertex(2, 5);

            Console.WriteLine("");
            Console.WriteLine(v1.ToString());
            Console.WriteLine("");

            Line l1 = new Line(1, 2, 3, 4, ShapeColor.Green);

            //Shape s = new Shape("Yellow");
            Console.WriteLine(l1.ToString());

            l1.Translate(v1);

            Console.WriteLine("\nTranslated by first vertex\n");
            Console.WriteLine(l1.ToString());

            Circle c1 = new Circle(1, 2, 4, ShapeColor.Red);

            Console.WriteLine("");
            Console.WriteLine(c1.ToString());
            Console.WriteLine("");
            Console.WriteLine("---Polymorphic testing---");

            Shape[] shapes = { new Line(2, 2, 3, 3, ShapeColor.Green), new Circle(5, 5, 50, ShapeColor.Blue) };

            foreach (Shape s in shapes)
            {
                Console.WriteLine("before : " + s);             // ToString()
                s.Translate(new Vertex(10, 10));
                Console.WriteLine("after : " + s);              // ToString()
                Console.WriteLine("");
            }


        }
    }
}
