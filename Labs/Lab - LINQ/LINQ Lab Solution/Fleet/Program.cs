// Sample solution to Task 1 LINQ & EF Lab
// a fleet of cars and some queries...

using System;
using System.Collections.Generic;
using System.Linq;                              // LINQ queries
using System.Text;

namespace Fleet
{
    // a simple Car class
    public class Car
    {
        public String Make { get; set; }
        public String Model { get; set; }
        public String Registration { get; set; }
        public int EngineSize { get; set; }

        public override string ToString()
        {
            return Make + " " + Model + " " + Registration + " " + EngineSize;
        }
    }
    class Fleet
    {
        static void Main(string[] args)
        {
            List<Car> fleet = new List<Car>();
            fleet.Add(new Car() {Make="Mazda", Model="MX5", Registration="12 D 12", EngineSize=2000});
            fleet.Add(new Car() { Make = "Mazda", Model = "3", Registration = "12 D 13", EngineSize = 1600 });
            fleet.Add(new Car() { Make = "BMW", Model = "5 Series", Registration = "12 D 14", EngineSize = 2000 });
            fleet.Add(new Car() { Make = "Toyota", Model = "Yaris", Registration = "12 D 16", EngineSize = 1100 });
            fleet.Add(new Car() { Make = "Renault", Model = "Scenic", Registration = "12 D 17", EngineSize = 1400 });
            fleet.Add(new Car() { Make = "Ford", Model = "Focus", Registration = "12 D 15", EngineSize = 1400 });
         

            // run qeries

            // List all cars in registration order
            var allCars = fleet.OrderBy(car => car.Registration);
            foreach (var car in allCars)
            {
                Console.WriteLine(car);
            }

            Console.WriteLine();

            // List the models for all Mazda cars in the fleet
            var mazdaCars = fleet.Where(car => car.Make == "Mazda").Select(car => car.Model);
            foreach (var car in mazdaCars)
            {
                Console.WriteLine(car);
            }

            Console.WriteLine();

            // List all cars in descending engine size order
            var descendingSize = fleet.OrderByDescending(car => car.EngineSize);
            foreach (var car in descendingSize)
            {
                Console.WriteLine(car);
            }

            Console.WriteLine();

            // List just the make and model for cars whose engine size is 1600 cc.
            var makesandmodels = fleet.Select(car => new { car.Make, car.Model });
            foreach (var car in makesandmodels)
            {
                Console.WriteLine(car.Make + " " + car.Model);
            }

            Console.WriteLine();

            // Count the number of cars whose engine size is 1600 cc or less
            var count = fleet.Where(car => car.EngineSize <= 1600).Count();
            Console.WriteLine(count);
        }
    }
}
