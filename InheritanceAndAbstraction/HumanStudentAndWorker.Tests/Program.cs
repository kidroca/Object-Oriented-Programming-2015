namespace HumanStudentAndWorker.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Global;
    using HomeworkHelpers;

    /// <summary>
    /// Initialize a list of 10 students and sort them by faculty number in ascending order 
    /// (use a LINQ query or the OrderBy() extension method). Initialize a list of 10 workers
    /// and sort them by payment per hour in descending order.
    /// 
    /// Merge the lists and then sort them by first name and last name
    /// </summary>
    public class Program
    {
        private static readonly HomeworkHelper Helper = new HomeworkHelper();

        private static readonly Random Rnd = new Random();

        private static void Main()
        {
            Helper.ConsoleMio.Setup();
            Helper.ConsoleMio.PrintHeading("Human, Student and Worker");

            List<Student> students = GenerateStudents();
            students = students.OrderBy(s => s.FacultyNumber)
                .ToList();

            PrintHumans(students, "Students");

            List<Worker> workers = GenerateWorkers();
            workers = workers.OrderByDescending(w => w.GetMoneyPerHour())
                .ToList();

            PrintHumans(workers, "Workers");

            var humans = new List<Human>(students);
            humans.AddRange(workers);

            var resorted = humans
                .OrderBy(h => h.FirstName)
                .ThenBy(h => h.LastName);

            PrintHumans(resorted, "Humans");
        }

        private static List<Worker> GenerateWorkers()
        {
            var workers = new List<Worker>();

            for (int i = 0; i < 10; i++)
            {
                decimal salary = Rnd.Next(
                    (int)(Worker.MinimalSalary * 100),
                    (int)(Worker.MinimalSalary * 10000)) / (decimal)100;

                int workHours = Rnd.Next(
                    Worker.MinimalWorkHoursPerDay, Worker.MaximalWorkHoursPerDay + 1);

                workers.Add(new Worker(
                    firstName: HumanNames.FirstNames[Rnd.Next(0, HumanNames.FirstNames.Length)],
                    lastName: HumanNames.LastNames[Rnd.Next(0, HumanNames.LastNames.Length)],
                    weeklySalary: salary,
                    workHours: workHours));
            }

            return workers;
        }

        private static List<Student> GenerateStudents()
        {
            var students = new List<Student>();

            for (int i = 0; i < 10; i++)
            {
                students.Add(new Student(HumanNames.FirstNames[Rnd.Next(0, HumanNames.FirstNames.Length)], HumanNames.LastNames[Rnd.Next(0, HumanNames.LastNames.Length)],
                    $"abv12z{Rnd.Next(0, 10000)}"));
            }

            return students;
        }

        private static void PrintHumans(IEnumerable<Human> humans, string collectionName)
        {
            Helper.ConsoleMio.WriteLine(
                $"{humans.Count()} {collectionName}", ConsoleColor.DarkGreen);

            foreach (var human in humans)
            {
                Helper.ConsoleMio.WriteLine(human.ToString(), ConsoleColor.Blue);
            }

            Helper.ConsoleMio.WriteLine("Press a key to continue...\n", ConsoleColor.DarkBlue);
            Console.ReadKey(true);
        }
    }
}
