using System;
using System.Collections.Generic;
namespace PetDemo
{
    class Pet
    {
        public string Color;
        public double Weight;
        public string Name;

        public virtual void Talk()
        {
            Console.WriteLine("Hello");
        }
    }

    class Dog : Pet
    {
        public int HoursofPlaytime;
        public override void Talk()
        {
            Console.WriteLine($"Bark! I Played {HoursofPlaytime} hours today! My name is {Name}.");
        }
    }

    class Cat : Pet
    {
        public int HoursOfSleep;
        public override void Talk()
        {
            Console.WriteLine($"Meow! I slept {HoursOfSleep} hours today!");
        }
    }

    class SledDog : Dog
    {
        public int MaximumWeight;

        public override void Talk()
        {
            Console.Write($"I'm a sled dog pulling {MaximumWeight} pounds and too busy to talk.");
            base.Talk(); //concatenates the two Talk()'s/ - Override first then the base Talk above.
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dog d1 = new Dog();
            d1.Name = "Molly";
            d1.Weight = 60.0;
            d1.Color = "Tan";
            d1.HoursofPlaytime = 3;
            //Console.WriteLine(d1.Name);
            d1.Talk();

            Dog d2 = new Dog();
            d2.Name = "Missy";
            d2.Weight = 100.0;
            d2.Color = "Black";
            d2.HoursofPlaytime = 1;
            d2.Talk();

            Cat c1 = new Cat();
            c1.Name = "Donald Duck";
            c1.Weight = 12.0;
            c1.Color = "Orange";
            c1.HoursOfSleep = 16;
            c1.Talk();

            SledDog sd1 = new SledDog();
            sd1.Name = "Henry";
            sd1.Weight = 75.0;
            sd1.Color = "White";
            sd1.HoursofPlaytime = 2;
            sd1.MaximumWeight = 1000;
            sd1.Talk();

            List<Pet> allpets = new List<Pet>();
            allpets.Add(d1);
            allpets.Add(d2);
            allpets.Add(c1);
            allpets.Add(sd1);

            Console.WriteLine("\nLet's loop through all pets:");
            foreach (Pet mypet in allpets)
            {
                mypet.Talk();
            }

        }
    }
}
