using System;
using System.Collections.Generic;
using System.Threading;

namespace ZooSimulator
{
    public class Program
    {
        private static Timer timer;
        private static readonly Zoo zoo = new Zoo();
        public static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                zoo.AddAnimal(new Animal(AnimalType.Monkey));
                zoo.AddAnimal(new Animal(AnimalType.Giraffe));
                zoo.AddAnimal(new Animal(AnimalType.Elephant));
            }

            timer = new Timer(TimerCallback, null, TimeSpan.FromSeconds(20), TimeSpan.FromSeconds(20));

            while (true)
            {
                zoo.DisplayStatus(null);              

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        zoo.FeedAnimals();
                        break;
                    case "2":
                        zoo.AddAnimal(new Animal(AnimalType.Monkey));
                        break;
                    case "3":
                        zoo.AddAnimal(new Animal(AnimalType.Giraffe));
                        break;
                    case "4":
                        zoo.AddAnimal(new Animal(AnimalType.Elephant));
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option! Please try again.");
                        break;
                }
            }
        }
        private static void TimerCallback(object state)
        {
            var deceasedAnimals = zoo.SimulateTimePassing();
            zoo.DisplayStatus(deceasedAnimals);
        }
    }
}