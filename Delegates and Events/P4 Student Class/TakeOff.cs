namespace P4_Student_Class
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;
    using HomeworkHelpers;
    using HomeworkHelpers.ConsoleEnchantments;

    /// <summary>
    /// Write a class Student that holds name and age. Add an event PropertyChanged that should 
    /// fire whenever a property of Student is changed, displaying a message in the format 
    /// Property changed: {property} (from {old value} to {new value}). Create a custom 
    /// PropertyChangedEventArgs class to keep the property name, old value and new value. 
    /// </summary>
    public class TakeOff
    {
        private const ConsoleColor INFO = ConsoleColor.DarkBlue;
        private const ConsoleColor EVENT = ConsoleColor.DarkRed;
        private const ConsoleColor MENU_FRONT = ConsoleColor.DarkGray;
        private const ConsoleColor MENU_BACK = ConsoleColor.Blue;
        private const ConsoleColor ERROR = ConsoleColor.Red;

        private static readonly HomeworkHelper Helper = new HomeworkHelper();

        private static bool keepRunning = true;

        private static void Main()
        {
            Helper.ConsoleMio.Setup();
            Helper.ConsoleMio.PrintHeading("Student Class (with event)");

            Helper.ConsoleMio.WriteLine(
                "Creating student Pesho Softuni and attaching event...",
                INFO);

            var student = new Student("Pesho", "Softuni");

            student.AttachHandler(PrintEventInformation);

            var properties = student
                .GetType()
                .GetProperties()
                .Where(prop => prop.PropertyType == typeof(string))
                .ToList();

            var menu = Helper.ConsoleMio.CreateMenu(properties);

            Console.CancelKeyPress += (sender, args) =>
            {
                keepRunning = false;
                Helper.ConsoleMio.WriteLine("Bye, bye...", INFO);
            };

            LaunchCycle(student, menu);
        }

        private static void LaunchCycle(Student student, ConsoleMenu<PropertyInfo> menu)
        {
            Helper.ConsoleMio
                .WriteLine(
                "Press Ctrl + C at any time to exit.\n" +
                "Choose a property and set an appropriate value: ",
                INFO);

            while (keepRunning)
            {
                var choice = menu.DisplayMenu(MENU_FRONT, MENU_BACK);
                try
                {
                    string value = Helper.ConsoleMio
                        .Write("{0}: ", INFO, choice.Name)
                        .ReadInColor(EVENT);

                    choice.SetValue(student, value);
                }
                catch (TargetInvocationException e)
                {
                    var inner = e.InnerException;
                    if (inner is ValidationException)
                    {
                        Helper.ConsoleMio.WriteLine(inner.Message, ERROR);
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        private static void PrintEventInformation<T>(object obj, PropertyChangedEventArgs<T> args)
        {
            Helper.ConsoleMio
                .Write("Property changed: ", EVENT)
                .Write(args.PropertyName, INFO)
                .Write(" (from ", EVENT)
                .Write(args.OldValue.ToString(), INFO)
                .Write(" to ", EVENT)
                .Write(args.NewValue.ToString(), INFO)
                .WriteLine(")", EVENT);
        }
    }
}