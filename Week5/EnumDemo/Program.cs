using System;
using System.Collections.Generic;
namespace EnumDemo
{
    // Enums are types very similar to bool. We have only a few possiblities for values. It's a list of options.
    enum  Instrument
    {
        Piano,
        AccousticGuitar,
        Djembe,
        Harmonica
    }

    // You can optionally specify what value is used behind the scenes
    //enum Instrument
    //{
    //    Piano,
    //    AccousticGuitar,
    //    Djembe,
    //    Harmonica
    //}

    class Program
    {
        static void Main(string[] args)
        {
            bool b1;  // Can hold ONE of TWO possible values (true and false)
            b1 = false;

            int n1;  // Can hold ONE of Millions if possible values
            n1 = 3;

            Instrument ins1;  // Can hold ONE of FOUR possible values (Piano, AcousticGuitar, Djembe, Harmonica)
            ins1 = Instrument.Harmonica;

            Console.WriteLine(ins1);

            List<Instrument> myinst = new List<Instrument>();
            myinst.Add(Instrument.Piano);
            myinst.Add(Instrument.Djembe);


            // Compare it to booleans
            // Booleans have two choices
            // Instruments have four choices

            List<bool> mybools = new List<bool>();
            mybools.Add(true);
            mybools.Add(true);
            mybools.Add(false);
            

        }
    }
}
