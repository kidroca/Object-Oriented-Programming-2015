namespace P1_Galactic_GPS
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using HomeworkHelpers;

    /// <summary>
    /// Create a struct Location that holds fields of type double latitude and longitude 
    /// of a given location. Create an enumeration Planet that holds the following 
    /// constants: Mercury, Venus, Earth, Mars, Jupiter, Saturn, Uranus, Neptune.
    /// 
    /// •   Add an enum field of type Planet. Encapsulate all fields. Validate 
    ///     data (search in Internet what are the valid ranges for latitude and longitude).
    /// •   Add a constructor that holds 3 parameters: latitude, longitude and planet.
    /// •   Override ToString() to print the current location in the format 
    ///     <latitude>, <longitude> - <location>
    /// </summary>
    public class Program
    {
        private static readonly HomeworkHelper Helper = new HomeworkHelper();

        private static void Main()
        {
            Helper.ConsoleMio.Setup();
            Helper.ConsoleMio.PrintHeading("Galactic GPS");

            Helper.ConsoleMio.WriteLine("Valid Location Structures: ", ConsoleColor.DarkBlue);
            TestValid();
            Console.WriteLine();

            Helper.ConsoleMio.WriteLine("Invalid Location Structures: ", ConsoleColor.DarkBlue);
            TestInvalid();
            Console.WriteLine();
        }

        private static void TestInvalid()
        {
            Location place;

            try
            {
                place = new Location(100, 50, Planet.Earth);
            }
            catch (ValidationException e)
            {
                Helper.ConsoleMio.WriteLine(e.Message, ConsoleColor.DarkRed);
            }

            try
            {
                place = new Location(50, -180.000001, Planet.Jupiter);
            }
            catch (ValidationException e)
            {
                Helper.ConsoleMio.WriteLine(e.Message, ConsoleColor.DarkRed);
            }

            try
            {
                place = new Location(36.0553, -112.1218, Planet.Earth, "G");
            }
            catch (ValidationException e)
            {
                Helper.ConsoleMio.WriteLine(e.Message, ConsoleColor.DarkRed);
            }
        }

        private static void TestValid()
        {
            var grandCanyon = new Location(36.0553, -112.1218, Planet.Earth, "Grand Canyon");
            Console.WriteLine(grandCanyon);

            var faceOnMars = new Location(40.75, -9.46, Planet.Mars, "Face on Mars");
            Console.WriteLine(faceOnMars);

            // Border Cases
            var positiveEdgeOfThePlanet = new Location(90, 180);
            Console.WriteLine(positiveEdgeOfThePlanet);

            var negativeEdgeOfThePlanet = new Location(-90, -180);
            Console.WriteLine(negativeEdgeOfThePlanet);
        }
    }
}
