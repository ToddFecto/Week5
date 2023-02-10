using System;
using System.Collections.Generic;

namespace Assessment4_Practice
{

    class Student
    {
        public string Name;
        public int Status;
        public List<int> Scores;
        public char Grade;

        public Student(string _Name, int _Status, List<int> _Scores)
        {
            Name = _Name;
            Status = _Status;
            Scores = _Scores;
        }



        public virtual char GetGrade()   //List<int> Scores passed in
        {
            //1. Loop through the list of scores
            //2. Get the Sum of all scores
            int sum = 0;
            foreach (var score in Scores)
            {
                sum = sum + score;
            }

            //3. Caluculate the average
            //sum / # of scores.count
            double average = sum / Scores.Count;

            //4. Use average score to determine grade >> use conditional structure

            if (average >= 90)
            {
                return  'a';
            }
            else if (average >= 80)
            {
                return  'b';
            }
            else if (average >= 70)
            {
                return 'c';
            }
            else if (average >= 60)
            {
                return  'd';
            }
            else 
            {
                return  'e';
            }
        }

        public override string ToString()
        {
            string scoresList = "";
            foreach (int score in Scores)
            {
                scoresList += score + " ";
            }
            return $"Student: {Name}, Scores: {scoresList}, Grade: {GetGrade()}";
        }
    }

    class GradStudent : Student
    {
        public List<Student> Students;

         public GradStudent(List<Student> _Students, string _gName, int _gStatus, List<int> _gScores) : base(_gName, _gStatus, _gScores)
        {
            Students = _Students;
        }

        public override char GetGrade()   //List<int> Scores passed in
        {
            //1. Loop through the list of scores
            //2. Get the Sum of all scores
            //3. Caluculate the average
            //sum / # of scores.count
            int sum = 0;
            int tally = 0;
            char gsGrade = base.GetGrade();

            foreach (var score in Scores)
            {
                sum = sum + score;
                double average = sum / Scores.Count;

                if (average >= 90)
                {
                    tally = tally + 10;
                }
                else if (average >= 80)
                {
                    tally = tally + 9;
                }
                else if (average >= 70)
                {
                    tally = tally + 8;
                }
                else if (average >= 60)
                {
                    tally = tally + 7;
                }
            }

            //4. Use average score to determine initial gsgrade then use both
            //      grade and tally to determine final gsGrade

            double tallyAvg = tally / Scores.Count;

            if (tallyAvg >= 7 && gsGrade == 'a' || gsGrade == 'b' || gsGrade == 'c')
            {
                return 'a';
            }
            else
            {
                return 'e';
            }
        }

        //public void ScoreAStudent(string student, int addScore)
        //{
           
        //    student = new Student(student, 1, addScore);
        //    Students.Add(student);
        //}
    }

    class Program
    {

        static void Main(string[] args)
        {
            List<Student> Students = new List<Student>();
            List<GradStudent> GradStudents = new List<GradStudent>();
            List<int> Scores = new List<int>();
            List<int> gScores = new List<int>();

            Scores = new List<int> { 75, 85, 95, 99, 100 };
            Student s1 = new Student("Todd", 1, Scores);
            Students.Add(s1);

            Scores = new List<int> { 85, 95, 90, 89, 80 };
            Student s2 = new Student("Chris", 1, Scores);
            Students.Add(s2);
            //Console.WriteLine(s2);

            Scores = new List<int> { 85, 90, 80, 90, 100 };
            Student gs1 = new Student("Sally", 2, Scores);
            Students.Add(gs1);
            ////Console.WriteLine(gs1);

            //Lists all students
            foreach (Student classmate in Students)
            {
                Console.WriteLine(classmate);
            }

            Console.WriteLine("\nWelcome to the Gradebook App.");
            Console.Write("To log in enter your name: ");
            string name = Console.ReadLine();

            //Console.WriteLine(Students.);
            // if (student status == '1')
            //{
            //    //1. display student details
            //    //2. prompt to return to log in or quit
            //        string entry = Console.ReadLine();
            //        if (entry == 'n')
            //        {
            //            goagain = false;
            //            Console.WriteLine()"Goodbye!");
            //        }
            //   }
            //   else
            //   {
            //    Console.WriteLine("Would you like to score a student (a)? Or see a report card? (b): ";
            //    char choice = Console.ReadLine();

            //    if (choice == 'a') 
            //     {
            //        //Call ScoreAStudent ()
            //     }
            //     if (choice == 'b') 
            //     {
            //        foreach (Student classmate in Students)
            //        {
            //            Console.WriteLine(classmate);
            //        }
            //     }
            //  }

            //foreach (Student classmate in Students)
            //{
            //    Console.WriteLine(classmate);
            //}

        }
    }
}
