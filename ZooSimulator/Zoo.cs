using System;
using System.Collections.Generic;
using System.Text;

namespace ZooSimulator
{
    public class Zoo
    {
        private readonly List<Animal> animals;
        private readonly Random random;
        private DateTime dateTime;
        private string deceasedAnimals;

        public Zoo()
        {
            animals = new List<Animal>();
            random = new Random();
            dateTime = DateTime.Now;
        }

        public void AddAnimal(Animal animal)
        {
            animals.Add(animal);
        }

        public void FeedAnimals()
        {
            float monkeyHealthIncrease = random.Next(10, 26);
            float giraffeHealthIncrease = random.Next(10, 26);
            float elephantHealthIncrease = random.Next(10, 26);

            foreach (var animal in animals)
            {
                switch (animal.Type)
                {
                    case AnimalType.Monkey:
                        animal.IncreaseHealth(monkeyHealthIncrease);
                        break;
                    case AnimalType.Giraffe:
                        animal.IncreaseHealth(giraffeHealthIncrease);
                        break;
                    case AnimalType.Elephant:
                        animal.IncreaseHealth(elephantHealthIncrease);
                        break;
                }
            }
        }

        public string SimulateTimePassing()
        {
            dateTime = dateTime.AddHours(1);

            foreach (var animal in animals)
            {
                float healthReduction = random.Next(0, 21);
                animal.ReduceHealth(healthReduction);

                if (animal.IsDead())
                {
                    deceasedAnimals += $"[{dateTime.ToString("dd/MM/yyyy h:mm tt")}] {animal.Type} #{animal.Id} died.\r\n";
                    animals.Remove(animal);
                    break;
                }
            }
            return deceasedAnimals;
        }

        public void DisplayStatus(string deceasedAnimals)
        {
            Console.Clear();

            Console.WriteLine("Welcome to the Zoo Simulator!");
            Console.WriteLine("========== Zoo Status ==========");
            Console.WriteLine($"Current Date & Time: {dateTime.ToString("dd/MM/yyyy h:mm tt")}");
            Console.WriteLine("Animals:");

            foreach (var animal in animals)
            {
                Console.WriteLine($"{animal.Type} #{animal.Id} - Health: {animal.Health}%");
            }

            if (deceasedAnimals != null)
                Console.WriteLine(deceasedAnimals);

            Console.WriteLine("===============================");

            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Feed the animals");
            Console.WriteLine("2. Add Monkey to Zoo");
            Console.WriteLine("3. Add Giraffe to Zoo");
            Console.WriteLine("4. Add Elephant to Zoo");
            Console.WriteLine("5. Quit");
        }
    }
}
