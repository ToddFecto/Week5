using System;
using System.Collections.Generic;

namespace DriveRatingApp
{
    //This is the DriveRating Enum
    public enum DriveRating
    {
        NeedsImprovement,
        AchievingExpectations,
        ExceedExpectations,
        RockStar
    }

    //Team Member class
    public class TeamMember
    {
        public string FirstName;
        public string LastName;
        public string CommonId;
        //This is an auto-implemented property for the DriveRating Enum
        public DriveRating DriveRating { get; set; }

        public TeamMember(string _FirstName, string _LastName, string _CommonId, DriveRating _DriveRating)
        {
            FirstName = _FirstName;
            LastName = _LastName;
            CommonId = _CommonId;
            DriveRating = _DriveRating;
        }

        public virtual double Determine()
        {
            string bonus = "";
            foreach (var rating in Enum.GetValues(typeof(DriveRating)))
            {
                bonus = (string)rating;

                if (bonus == "NeedsImprovement")
                {
                    return 0;
                }
                else if (bonus == "AchievingExpectations")
                {

                    return 1000;
                }
                else if (bonus == "ExceedsExpectations")
                {
                    return 5000;
                }
                else if (bonus == "RockStar")
                {
                    return 10000;
                }
            }
            return 0;
        }

        public override string ToString()
        {

            return $"\nTeam Members:\n{LastName}, {FirstName} DRIVE rating is {DriveRating} and their bonus is $bonus\n";
        }
    }

    class Leader : TeamMember
    {
        public Leader(string _FirstName, string _LastName, string _CommonId,
            DriveRating _DriveRating) : base(_FirstName, _LastName, _CommonId, _DriveRating)
        {
            FirstName = _FirstName;
            LastName = _LastName;
            CommonId = _CommonId;
            DriveRating = _DriveRating;
        }

        public override double Determine()
        {
            string bonus = "";
            foreach (var rating in Enum.GetValues(typeof(DriveRating)))
            {
                bonus = (string)rating;

                if (bonus == "NeedsImprovement")
                {
                    return 0;
                }
                else if (bonus == "AchievingExpectations")
                {
                    return 2000;
                }
                else if (bonus == "ExceedsExpectations")
                {
                    return 10000;
                }
                else if (bonus == "RockStar")
                {
                    return 20000;
                }
            }
            return 0;
        }
    }

    class Director : TeamMember
    {
        public Director(string _FirstName, string _LastName, string _CommonId,
            DriveRating _DriveRating) : base(_FirstName, _LastName, _CommonId, _DriveRating)
        {
            FirstName = _FirstName;
            LastName = _LastName;
            CommonId = _CommonId;
            DriveRating = _DriveRating;
        }

        public override double Determine()
        {
            string bonus = "";
            foreach (var rating in Enum.GetValues(typeof(DriveRating)))
            {
                bonus = (string)rating;

                if (bonus == "NeedsImprovement")
                {
                    return 0;
                }
                else if (bonus == "AchievingExpectations")
                {
                    return 3000;
                }
                else if (bonus == "ExceedsExpectations")
                {
                    return 15000;
                }
                else if (bonus == "RockStar")
                {
                    return 30000;
                }
            }
            return 0;
        }

        public void DirectorDriveRating(List<TeamMember> teamMembers)
        {
            foreach (var rating in teamMembers)
            {
                bonus = (string)rating;

                if (bonus == "NeedsImprovement")
                {
                    return 0;
                }
                if (bonus == "AchievingExpectations")
                {
                    return 3000;
                }
                if (bonus == "ExceedsExpectations")
                {
                    return 15000;
                }
                else
                {
                    return 30000;
                }
            }
            return 0;
        }
    }
    //Repository of Team Members
    public static class TeamMemberRepo
    {
        public static List<TeamMember> GetTeamMembers()
        {
            List<TeamMember> teamMembers = new List<TeamMember>
            {
                new TeamMember("Joe", "Spacito", "t1234", DriveRating.AchievingExpectations),
                new TeamMember("Jane", "Carrie", "t1235", DriveRating.AchievingExpectations),
                new TeamMember("Praj", "Nahim", "t1236", DriveRating.AchievingExpectations),
                new Leader("Fitz", "Caldwell", "l2239", DriveRating.AchievingExpectations),
                new Leader("Leslie", "Wrightfield", "l3239", DriveRating.AchievingExpectations),
                new Director("Charlie", "Georgina", "d5538", DriveRating.AchievingExpectations),
            };

            return teamMembers;
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TeamMemberRepo.GetTeamMembers()); //Supposed to output the entire Team Member list!!!

            teamMembers.GetTeamMembers();

            bool keepGoing = true;
            while (keepGoing)
            {
                Console.Write("\nPlease enter your Common ID (type 'q' to quit system) : ");
                string common = Console.ReadLine();

                if (common == "q")
                {
                    Console.WriteLine("Goodbye!!");
                    break;
                }
                if (common.StartsWith('t'))
                {
                    //Team Member Flow
                    Console.WriteLine($"\nTeamMember FirstName, your current DriveRating is.....");
                    Console.Write("Return to Title Screen (1)Yes or (2)Exit: ");
                    int choice = int.Parse(Console.ReadLine());
                    if (choice == 1)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Goodbye!!");
                        break;
                    }
                }
                else if (common.StartsWith('l'))
                {
                    //Leader Flow
                    Console.Write($"\nWould you like to (1)Update a Drive Rating or (2)View Bonus Report: ");
                    int choice = int.Parse(Console.ReadLine());

                    if (choice == 1)
                    {
                        bool tryagain = true;
                        while (tryagain)
                        {
                            Console.Write("\nPlease enter a Common ID (type 'q' to quit system) : ");
                            string IDCommon = Console.ReadLine();
                            if (IDCommon.StartsWith('l'))
                            {
                                Console.WriteLine("You do not have permissions to update leadership.");
                            }
                        }
                    }
                    if (choice == 2)
                    {
                        Console.WriteLine("This should view Bonus Report!");
                    }
                    else
                    {
                        Console.WriteLine("Goodbye!!");
                        break;
                    }
                }
                else if (common.StartsWith('d'))
                {
                    //Director Flow
                    Console.WriteLine($"\nDirector Flow");
                }
            }
        }
    }


}