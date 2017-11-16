using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_Student
{
    class Program
    {
        static List<Student> students = new List<Student>{
             new Student {First="Andrey", Last="Letunov", ID=2, Scores= new List<int> {92, 93, 72, 61}},
        new Student {First="Nataliia", Last="Zahriazhskaya", ID=1, Scores= new List<int> {91, 92, 71, 60}},
       
        new Student {First="Timur", Last="Phrolov", ID=3, Scores=new List<int>{60,60,60,60} }};

        static void Main(string[] args)
        {
            System.Collections.Generic.IEnumerable<Student> studentQuery =
                from student in students
                where student.Scores[0] > 90 && student.Scores[3] < 80
                orderby student.Scores[0] descending
                select student;

            foreach (Student student in studentQuery)
            {
                Console.WriteLine("{0}, {1} {2}", student.Last, student.First, student.Scores[0]);

            }

            Console.WriteLine("++++++++++++++++++The second requerst++++++++++++");

            var studentQuery2 =
                from student in students
                group student by student.Last[0];

            foreach (var studentGroup in studentQuery2)
            {
                Console.WriteLine(studentGroup.Key);
                foreach (Student student in studentGroup)
                {
                    Console.WriteLine(" {0}, {1}",
                    student.Last, student.First);
                }
            }

            Console.WriteLine("+++++++++++++++++The third requerst:++++++++++++++++");

            var studentQuery5 = from student in students
                                let totalScore = student.Scores[0] + student.Scores[1] +
                                student.Scores[2] + student.Scores[3]
                                where totalScore / 4 < student.Scores[0]
                                select student.Last + " " + student.First;
            foreach (string s in studentQuery5)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("+++++++++++++++++The fourth requerst:++++++++++++++++");
            var studentQuery6 = from student in students
                                let totalScore = student.Scores[0] + student.Scores[1] +
                                student.Scores[2] + student.Scores[3]
                                select totalScore;
            double averageScore = studentQuery6.Average();
            Console.WriteLine("Class average score = {0}", averageScore);

            Console.WriteLine("+++++++++++++++++The fifth requerst:++++++++++++++++");
            IEnumerable<string> studentQuery7 =
                from student in students
                where student.Last == "Garcia"
                select student.First;

            Console.WriteLine("The Garcias in the class are:");
            foreach (string s in studentQuery7)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("+++++++++++++++++The second requerst:++++++++++++++++");
            var studentQuery8 =
                from student in students
                let x = student.Scores[0] + student.Scores[1] +
                student.Scores[2] + student.Scores[3]
                where x > averageScore
                select new { id = student.ID, score = x };
            foreach (var item in studentQuery8)
            {
                Console.WriteLine("Student ID: {0}, Score: {1}", item.id, item.score);
            }

            Console.ReadLine();
        }
    }
}
