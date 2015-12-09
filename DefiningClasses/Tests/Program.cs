namespace Tests
{
    using System;
    using System.Diagnostics;
    using HomeworkHelpers;
    using LaptopShop;
    using PcCatalog;
    using Persons;

    /// <summary>
    /// Tests that all the things work
    /// </summary>
    public class Program
    {
        private const string AnnoyingMessage = "test are over, press a key to continue...";

        private static readonly HomeworkHelper Helper = new HomeworkHelper();

        private static void Main()
        {
            Helper.ConsoleMio.Setup();
            Helper.ConsoleMio.PrintHeading("Defining Classes Homework ");

            RunPersonsTests();
            Helper.ConsoleMio.WriteLine(
                $"Persons {AnnoyingMessage}\n", ConsoleColor.DarkGray);
            Console.ReadKey(true);

            RunLaptopTests();
            Helper.ConsoleMio.WriteLine(
                $"Laptop {AnnoyingMessage}\n", ConsoleColor.DarkGray);
            Console.ReadKey(true);

            RunPcCatalogTests();
        }

        private static void RunPersonsTests()
        {
            Helper.ConsoleMio.WriteLine("Persons Tests:", ConsoleColor.DarkCyan);

            int expectedExceptionCount = 3,
                actualExceptionCount = 0;

            // Valid
            var unaPersonaGrande = new Person("Pesho", 24);
            Helper.ConsoleMio.WriteLine(unaPersonaGrande.ToString(), ConsoleColor.DarkGreen);

            var grandePersonaDos = new Person("Ali Baba", 99, "ali@alibaba.com");
            Helper.ConsoleMio.WriteLine(grandePersonaDos.ToString(), ConsoleColor.DarkGreen);

            // Invalid
            try
            {
                var personaTresGrande = new Person("   ", 24);
            }
            catch (ArgumentException ex)
            {
                Helper.ConsoleMio.Write("Exception Caught: ", ConsoleColor.DarkGreen)
                    .WriteLine(ex.Message, ConsoleColor.DarkBlue);

                actualExceptionCount++;
            }

            try
            {
                var personaTresGrande = new Person("Gundi", 0);
            }
            catch (ArgumentException ex)
            {
                Helper.ConsoleMio.Write("Exception Caught: ", ConsoleColor.DarkGreen)
                    .WriteLine(ex.Message, ConsoleColor.DarkBlue);

                actualExceptionCount++;
            }

            try
            {
                var personaTresGrande = new Person("Dimitar Rachkov", 15, "Dimi");
            }
            catch (ArgumentException ex)
            {
                Helper.ConsoleMio.Write("Exception Caught: ", ConsoleColor.DarkGreen)
                    .WriteLine(ex.Message, ConsoleColor.DarkBlue);

                actualExceptionCount++;
            }

            Debug.Assert(
                expectedExceptionCount == actualExceptionCount,
                $"Expected {expectedExceptionCount} exceptions but found only " +
                $"{actualExceptionCount}");
        }

        private static void RunLaptopTests()
        {
            Helper.ConsoleMio.WriteLine("Laptop Shop Tests:", ConsoleColor.DarkCyan);

            int expectedExceptions = 2,
                actualExceptions = 0;

            var superNotbook = new Laptop("Mirosoft Sinewinder 500", 100.01m);
            Helper.ConsoleMio.WriteLine(superNotbook.ToString(), ConsoleColor.DarkGreen);

            var goodComp = new Laptop("Elenino", 1199.89m)
            {
                Proccessor = "16bit 4x4x2 1000mb cash -> $",
                Manucafturer = "Parvetc",
                Battery = new Battery(BatteryType.Polymer, 12, 12400, 8.33),
                GraphicsCard = "VooDoo 5 3Dfx",
                Ram = 12,
                Screen = "15.6\" - 800 x 600 (MegaXHD*), Teflon",
                Storage = new StorageDrive(1000, DriveType.Hybrid)
            };

            Helper.ConsoleMio.WriteLine(goodComp.ToString(), ConsoleColor.DarkGreen);

            try
            {
                var amIerror = new Laptop("Magbook", 0);
            }
            catch (ArgumentException ex)
            {
                Helper.ConsoleMio.Write("Exception Caught: ", ConsoleColor.DarkGreen)
                    .WriteLine(ex.Message, ConsoleColor.DarkBlue);

                actualExceptions++;
            }

            try
            {
                var amIerror = new Laptop(string.Empty, 5);
            }
            catch (ArgumentException ex)
            {
                Helper.ConsoleMio.Write("Exception Caught: ", ConsoleColor.DarkGreen)
                    .WriteLine(ex.Message, ConsoleColor.DarkBlue);

                actualExceptions++;
            }

            Debug.Assert(
                expectedExceptions == actualExceptions,
                $"Expected {expectedExceptions} exceptions but found only " +
                $"{actualExceptions}");
        }

        private static void RunPcCatalogTests()
        {
            Helper.ConsoleMio.WriteLine("Pc Catalog Tests:", ConsoleColor.DarkCyan);

            Component[] pcStuff =
            {
                new Component("Miska", 45, "Azis"),
                new Component("Monitor", 100, "Generic PnP Monitor"),
                new Component("Chip", 1000),
            };

            var pc = new Computer("Pesho pc", pcStuff);

            Helper.ConsoleMio.WriteLine(pc.ToString(), ConsoleColor.Blue);
        }
    }
}
