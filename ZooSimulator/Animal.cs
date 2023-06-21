using System;
using System.Collections.Generic;
using System.Text;

namespace ZooSimulator
{
    public enum AnimalType
    {
        Monkey,
        Giraffe,
        Elephant
    }

    public class Animal
    {
        private static int monkeyCount;
        private static int giraffeCount;
        private static int elephantCount;

        public int Id { get; }
        public AnimalType Type { get; }
        public float Health { get; private set; }

        public Animal(AnimalType type)
        {
            Type = type;
            Health = 100f;

            switch (Type)
            {
                case AnimalType.Monkey:
                    monkeyCount++;
                    Id = monkeyCount;
                    break;
                case AnimalType.Giraffe:
                    giraffeCount++;
                    Id = giraffeCount;
                    break;
                case AnimalType.Elephant:
                    elephantCount++;
                    Id = elephantCount;
                    break;
            }
        }

        public void ReduceHealth(float percentage)
        {
            Health -= Health * (percentage / 100f);
            if (Health < 0)
                Health = 0;
        }

        public void IncreaseHealth(float percentage)
        {
            Health += Health * (percentage / 100f);
            if (Health > 100)
                Health = 100;
        }

        public bool IsDead()
        {
            switch (Type)
            {
                case AnimalType.Monkey:
                    return Health < 30f;
                case AnimalType.Giraffe:
                    return Health < 50f;
                case AnimalType.Elephant:
                    return Health < 70f;
                default:
                    return false;
            }
        }
    }
}
