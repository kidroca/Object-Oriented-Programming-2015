namespace P3_Asynchronous_Timer
{
    using System;
    using System.Diagnostics;
    using HomeworkHelpers;

    /// <summary>
    /// Create a class AsyncTimer that executes a given method each t seconds.
    /// </summary>
    public class TakeOff
    {
        private static readonly HomeworkHelper Helper = new HomeworkHelper();
        private static int counter;

        private static void Main()
        {
            Helper.ConsoleMio.Setup();
            Helper.ConsoleMio.PrintHeading("Asynchronous Timer");

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            counter = 15;
            Action callback = () =>
            {
                Helper.ConsoleMio.WriteLine(
                    "Hello World! counter: {0}, elapsed: {1}",
                    ConsoleColor.DarkBlue,
                    counter--,
                    stopwatch.Elapsed);
            };

            var timer = new AsyncTimer(counter, 1500, callback);

            timer.Start();

            Helper.ConsoleMio.WriteLine(
                "The timer is not interrupting the Main method -> type 'pause' anytime: ",
                ConsoleColor.DarkGreen);

            while (counter > 0)
            {
                string str = Helper.ConsoleMio.ReadInColor(ConsoleColor.DarkMagenta);
                if (str.ToLower().Contains("pause"))
                {
                    timer.Pause();
                    Helper.ConsoleMio.WriteLine(
                "Type 'start' anytime to resume...",
                ConsoleColor.DarkGreen);
                }
                else if (str.ToLower().Contains("start"))
                {
                    timer.Start();
                }
            }

            Helper.ConsoleMio.WriteLine(
                "Congratulations you receive... a HANDSHAKE from Nakov",
                ConsoleColor.DarkMagenta);
        }
    }
}
