using System;
using System.Collections.Generic;
namespace SiftMember
{
    public class SiftMember
    {
        private string name;
        private DateTime anniversaryDate;
        private string jobTitle;
        private string email;
        private List<string> skills;
        public SiftMember(string name, DateTime anniversaryDate, string jobTitle, string email, List<string> skills)
        {
            this.name = name;
            this.anniversaryDate = anniversaryDate;
            this.jobTitle = jobTitle;
            this.email = email;
            this.skills = skills;
        }
        public bool AddSkill(string skill)
        {
            if (skills.Contains(skill))
            {
                return false;
            }
            else
            {
                skills.Add(skill);
                return true;
            }
        }
        public string GetName()
        {
            return name;
        }
        public override string ToString()
        {
            string skillsList = "";
            foreach (string skill in skills)
            {
                skillsList += skill + " ";
            }
            return "Name: " + name + "\nJob Title: " + jobTitle + "\nAnniversary: " + anniversaryDate + "\nEmail: " + email + "\nSkills: " + skillsList;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // initialize and populate a List of SiftMembers
            // with at least 1 SiftMember
            List<SiftMember> members = new List<SiftMember>();
            DateTime anniversaryDate = DateTime.Parse("03/29/2021");
            List<string> skills = new List<string>();
            skills.Add("doodling");
            skills.Add("strolling");
            SiftMember tiia = new SiftMember("Tiia Kansa", anniversaryDate, "APM", "tiia@gmail.com", skills);
            members.Add(tiia);
            // start looping
            bool goAgain = true;
            while (goAgain)
            {
                // present the menu
                Console.WriteLine("Welcome to Sift, what would you like to do?");
                Console.WriteLine("1. Add a tm");
                Console.WriteLine("2. Search and add skills");
                Console.WriteLine("3. Print all members");
                Console.WriteLine("4. Quit");
                int choice = int.Parse(Console.ReadLine());
                // add a TM
                if (choice == 1)
                {
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Anniversary Date MM/dd/yy: ");
                    DateTime anniversary = DateTime.Parse(Console.ReadLine());
                    Console.Write("Title: ");
                    string title = Console.ReadLine();
                    Console.Write("Email: ");
                    string email = Console.ReadLine();
                    SiftMember member = new SiftMember(name, anniversary, title, email, new List<string>());
                    members.Add(member);
                }
                // search for a TM and add skills
                if (choice == 2)
                {
                    Console.Write("Please enter the name of the team member you would like to add skills for: ");
                    string name = Console.ReadLine();
                    foreach (SiftMember member in members)
                    {
                        if (member.GetName() == name)
                        {
                            while (true)
                            {
                                Console.Write("Skill (type 'q' to quit adding): ");
                                string skill = Console.ReadLine();
                                if (skill == "q")
                                {
                                    break;
                                }
                                bool isAdded = member.AddSkill(skill);
                                if (isAdded)
                                {
                                    Console.WriteLine(skill + " was added!");
                                }
                                else
                                {
                                    Console.WriteLine("Sorry, that skill is already listed!");
                                }
                            }
                        }
                    }
                }
                // print all the TMs
                if (choice == 3)
                {
                    foreach (SiftMember member in members)
                    {
                        Console.WriteLine(member);
                    }
                }
                if (choice == 4)
                {
                    goAgain = false;
                    Console.WriteLine("Byeeeee!");
                }
            }
        }
    }
}