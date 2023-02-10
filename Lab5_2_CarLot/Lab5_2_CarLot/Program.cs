using System;
using System.Collections.Generic;
namespace Lab5_2_CarLot
{
    enum CarMake
    {
        Ford,
        Chevrolet,
        Chrysler,
        Honda,
        Toyota
    }

    abstract class Car
    {
        protected CarMake Make;
        protected string Model;
        protected int Year;
        protected decimal Price;

        public Car(CarMake _Make, string _Model, int _Year, decimal _Price)
        {
            SetMake(_Make);
            SetModel(_Model);
            SetYear(_Year);
            SetPrice(_Price);
        }

        public CarMake GetMake()
        {
            return Make;
        }

        public void SetMake(CarMake _Make)
        {
            Make = _Make;
        }

        public string GetModel()
        {
            return Model;
        }

        public void SetModel(string _Model)
        {
            Model = _Model;
        }

        public int GetYear()
        {
            return Year;
        }

        public void SetYear(int _Year)
        {
            Year = _Year;
        }

        public decimal GetPrice()
        {
            return Year;
        }

        public void SetPrice(decimal _Price)
        {
            Price = _Price;
        }
    }

    class NewCar : Car
    {
        public bool ExtendedWarranty;

        public NewCar(bool _ExtendedWarranty, CarMake _nMake, string _nModel, int _nYear, decimal _nPrice) : base(_nMake, _nModel, _nYear, _nPrice)
        {
            ExtendedWarranty = _ExtendedWarranty;
        }

        public override string ToString()
        {
            return $"New car details: \n\tMake: {Make} \n\tModel: {Model} \n\tYear: {Year} \n\tPrice: ${Price} \n\tExtended Warranty: {ExtendedWarranty}\n";
        }
    }

    class UsedCar : Car
    {
        public int NumberOfOwners;
        public int Mileage;

        public UsedCar(int _NumberOfOwners, int _Mileage, CarMake _uMake, string _uModel, int _uYear, decimal _uPrice) : base(_uMake, _uModel, _uYear, _uPrice)
        {
            NumberOfOwners = _NumberOfOwners;
            Mileage = _Mileage;
        }

        public override string ToString()
        {
            return $"Used car details: \n\tMake: {Make} \n\tModel: {Model} \n\tYear: {Year} \n\tPrice: ${Price} \n\tNumber of owners {NumberOfOwners} \n\tMileage: {Mileage} miles\n";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Car> mycarlist = new List<Car>();

            NewCar ncar1 = new NewCar(true, CarMake.Chevrolet, "Suburban", 2021, 65000.00m);
            mycarlist.Add(ncar1);

            //Console.WriteLine(ncar1);   ///test output

            NewCar ncar2 = new NewCar(true, CarMake.Chrysler, "300C", 2020, 35000.00m);
            mycarlist.Add(ncar2);

            NewCar ncar3 = new NewCar(false, CarMake.Ford, "Escape", 2020, 25000.00m);
            mycarlist.Add(ncar3);

            UsedCar ucar1 = new UsedCar(2, 95000, CarMake.Honda, "Accord", 2014, 7500.00m);
            mycarlist.Add(ucar1);

            //Console.WriteLine(ucar1);   ///test output

            UsedCar ucar2 = new UsedCar(5, 210000, CarMake.Toyota, "Land Cruiser", 2008, 5500.00m);
            mycarlist.Add(ucar2);

            UsedCar ucar3 = new UsedCar(3, 155000, CarMake.Chevrolet, "Cruze LT", 2011, 4500.00m);
            mycarlist.Add(ucar3);


            Dictionary<string, string> actions = new Dictionary<string, string>();
            actions.Add("View Inventory", "1");
            actions.Add("Add Car       ", "2");
            actions.Add("Purchase Car  ", "3");
            actions.Add("Quit          ", "4");

            Console.WriteLine("*************************************************************************");
            Console.WriteLine("* Welcome to DevBuild AutoSales - We by and sell new and used vehicles!* ");
            Console.WriteLine("*************************************************************************");

            bool KeepGoing = true;
            while (KeepGoing)
            {
                string choice;
                do
                {
                    Console.WriteLine("\nPlease choose an option from our system menu:");
                    foreach (var pair in actions)
                    {
                        Console.WriteLine($"To {pair.Key} press\t [{pair.Value}]");
                    }
                    Console.Write("\nEnter choice: ");
                    choice = Console.ReadLine().ToLower();
                } while (choice != "1" && choice != "2" && choice != "3" && choice != "4");

                if (choice == "1")
                {
                    Console.WriteLine("\nHere is our updated vehicle inventory:\n");

                    for (int index = 0; index < mycarlist.Count; index++)
                    {
                        Console.WriteLine($"{index + 1}.\t{mycarlist[index]}");
                    }
                }

                if (choice == "2")
                {
                    Console.WriteLine("You chose to add a car to our inventory.");
                    Console.Write("Do you want to add a (N)ew car or (U)sed car to our inventory? ");
                    string CarType = Console.ReadLine();
                    CarType = CarType.ToLower();

                    Console.WriteLine("\nPlease enter the following details for the car:");

                    Console.Write("Make: ");
                    string MakeStr = Console.ReadLine();
                    CarMake _Make = CarMake.Chevrolet;
                    MakeStr = MakeStr.ToUpper();
                    switch (MakeStr)
                    {
                        case "FORD":
                            _Make = CarMake.Ford;
                            break;
                        case "CHEVROLET":
                            _Make = CarMake.Chevrolet;
                            break;
                        case "CHRYSLER":
                            _Make = CarMake.Chrysler;
                            break;
                        case "TOYOTA":
                            _Make = CarMake.Toyota;
                            break;
                        case "HONDA":
                            _Make = CarMake.Honda;
                            break;
                    }

                    Console.Write("Model: ");
                    string _Model = Console.ReadLine();

                    Console.Write("Year: ");
                    string CarYear = Console.ReadLine();
                    int _Year;
                    int.TryParse(CarYear, out _Year);

                    Console.Write("Price: ");
                    string _PriceStr = Console.ReadLine();
                    decimal _Price = decimal.Parse(_PriceStr);

                    if (CarType == "n" || CarType == "N")
                    {
                        Console.Write("Extended Warranty: ");
                        string ExtendedWarrantyStr = Console.ReadLine();
                        bool _ExtendedWarranty;
                        bool.TryParse(ExtendedWarrantyStr, out _ExtendedWarranty);

                        if (ExtendedWarrantyStr == "y" || ExtendedWarrantyStr == "Y")
                        {
                            _ExtendedWarranty = true;
                        }

                        if (ExtendedWarrantyStr == "n" || ExtendedWarrantyStr == "N")
                        {
                            _ExtendedWarranty = false;
                        }

                        NewCar AddNewCar = new NewCar(_ExtendedWarranty, _Make, _Model, _Year, _Price);
                        mycarlist.Add(AddNewCar);

                        Console.WriteLine("\nHere is our updated vehicle inventory:\n");

                        for (int index = 0; index < mycarlist.Count; index++)
                        {
                            Console.WriteLine($"{index + 1}.\t{mycarlist[index]}");
                        }
                    }

                    if (CarType == "u" || CarType == "U")
                    {
                        Console.Write("Number of owners: ");
                        string NumberOfOwnersStr = Console.ReadLine();
                         int _NumberOfOwners = int.Parse(NumberOfOwnersStr);

                        Console.Write("Enter mileage: ");
                        string MileageStr = Console.ReadLine();
                        int _Mileage = int.Parse(MileageStr);

                        UsedCar AddUsedCar = new UsedCar(_NumberOfOwners, _Mileage, _Make, _Model, _Year, _Price);
                        mycarlist.Add(AddUsedCar);

                        Console.WriteLine("\nHere is our updated vehicle inventory:\n");

                        for (int index = 0; index < mycarlist.Count; index++)
                        {
                            Console.WriteLine($"{index + 1}.\t{mycarlist[index]}");
                        }
                    }
                }

                else if (choice == "3")
                {
                    Console.WriteLine("\nYou chose to purchase a car.");

                    Console.WriteLine("\nHere is our current vehicle inventory:\n");

                    for (int index = 0; index < mycarlist.Count; index++)
                    {
                        Console.WriteLine($"{index + 1}.\t{mycarlist[index]}");
                    }
                        string PurchaseCar = "";
                        int i = 0;

                        Console.Write("Please enter the car number to purchase: ");
                        PurchaseCar = Console.ReadLine();
                        i = int.Parse(PurchaseCar);

                        Console.WriteLine("\nHere is the car you chose to purchase:\n");
                        Console.WriteLine(mycarlist[i - 1]);
                        Console.Write("\nPlease confirm car choice: (y/n) ");
                        string entry = Console.ReadLine();
                        if (entry == "y" || entry == "Y")
                        {
                            Console.WriteLine($"\nThe record for {mycarlist[i - 1]} has been deleted.");
                            mycarlist.RemoveAt(i - 1);
                            Console.WriteLine("\nHere's the updated car inventory!\n");

                                for (int index = 0; index < mycarlist.Count; index++)
                                {
                                    Console.WriteLine($"{index + 1}.\t{mycarlist[index]}");
                                }
                        }
                }

                if (choice == "4")
                {
                    Console.WriteLine("\nYou chose to Quit the CarLot program:\n");
                    Console.Write("\nPlease confirm your choice: (y/n) ");
                    string entry = Console.ReadLine();
                    if (entry == "y" || entry == "Y")
                    {
                        KeepGoing = false;
                        Console.WriteLine("Thank you for stopping by DevBuild Auto Sales! Have a great rest of your day!!");
                    }
                    else
                    {
                        KeepGoing = true;
                    }
                }
            }
        }
    }
}
