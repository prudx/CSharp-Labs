using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleet
{
    class Car
    {
        public string Make { get; internal set; }
        public string Model { get; internal set; }
        public string Registration { get; internal set; }
        public int EngineSize { get; internal set; }


        public override string ToString()
        {
            return "Make: "+Make
                +"\nModel: "+Model
                +"\nRegistration: "+Registration
                +"\nEngine Size: "+EngineSize
                +"\n";
        }
    }

    class Fleet
    {
        static void Main()
        {
            List<Car> fleet = new List<Car>
            {
                new Car() { Make = "Mazda", Model = "MX5", Registration = "12 D 12", EngineSize = 2000 },
                new Car() { Make = "Mazda", Model = "3", Registration = "12 D 13", EngineSize = 1600 },
                new Car() { Make = "BMW", Model = "5 Series", Registration = "12 D 14", EngineSize = 2000 },
                new Car() { Make = "Toyota", Model = "Yaris", Registration = "12 D 16", EngineSize = 1100 },
                new Car() { Make = "Renault", Model = "Scenic", Registration = "12 D 17", EngineSize = 1400 },
                new Car() { Make = "Ford", Model = "Focus", Registration = "12 D 15", EngineSize = 1400 }
            };

            Console.WriteLine("-------------Query 1-------------");

            //query 1
            var allCars = fleet.OrderBy(car => car.Registration);
            foreach(var car in allCars)
            {
                Console.WriteLine(car);
            }

            Console.WriteLine("-------------Query 2-------------");

            //query 2
            var mazdaModels = fleet.Where(car => car.Make == "Mazda").Select(car => car.Model);
            foreach (var car in mazdaModels)
            {
                Console.WriteLine(car);
            }

            Console.WriteLine("-------------Query 3-------------");

            //query 3
            var allCarsDescendingEngine = fleet.OrderByDescending(car => car.EngineSize).Select(car => car);
            foreach (var car in allCarsDescendingEngine)
            {
                Console.WriteLine(car);
            }

            Console.WriteLine("-------------Query 4-------------");

            //query 4
            var allCarEngine1600 = fleet.Where(car => car.EngineSize == 1600).Select(car => new { car.Make, car.Model });
            foreach (var car in allCarEngine1600)
            {
                Console.WriteLine(car.Make +" " +car.Model);
            }


            
            Console.WriteLine("-------------Query 5-------------");

            //query 5
            var countEngine1600OrLess = fleet.Where(car => car.EngineSize <= 1600).Count();
            Console.WriteLine(countEngine1600OrLess);
            
            
        }
    }
}
