namespace P1_Custom_LINQ_Extension_Methods
{
    using System;
    using HomeworkHelpers;

    /// <summary>
    /// Create your own LINQ extension methods:
    /// •    public static IEnumerable{T} WhereNot{T}(
    ///          this IEnumerable{T} collection, Func{T, bool} predicate)
    /// •    public static TSelector Max{TSource, TSelector}(
    ///          this IEnumerable{TSource}, Func{TSource, TSelector})
    /// </summary>
    public class TakeOff
    {
        private const ConsoleColor INFO = ConsoleColor.DarkBlue;
        private const ConsoleColor VALUES = ConsoleColor.DarkRed;

        private static readonly HomeworkHelper Helper = new HomeworkHelper();

        private static void Main()
        {
            Helper.ConsoleMio.Setup();
            Helper.ConsoleMio.PrintHeading("Custom LINQ Extension Methods ");

            Helper.ConsoleMio.WriteLine("WhereNot usages: ", INFO);
            TestWhereNotExtension();
            Console.WriteLine();

            Helper.ConsoleMio.WriteLine("Max usages: ", INFO);
            TestMaxExtensions();
        }

        private static void TestWhereNotExtension()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7 };
            Helper.ConsoleMio.Write("Initial Collection: ", INFO)
                .WriteLine(numbers.JoinWithComma(), VALUES);

            var numbersResult = numbers.WhereNot(x => x % 2 == 0);
            Helper.ConsoleMio.Write("WhereNot(x => x % 2 == 0): ", INFO)
                .WriteLine(numbersResult.JoinWithComma(), VALUES);

            Console.WriteLine();

            string[] words = { "hi", "hello", "rock", "hi", "hi", "secret message", "hi" };
            Helper.ConsoleMio.Write("Initial Collection: ", INFO)
                .WriteLine(words.JoinWithComma(), VALUES);

            var wordsResult = words.WhereNot(w => w.Equals("hi", StringComparison.Ordinal));
            Helper.ConsoleMio.Write("WhereNot(word => word == \"hi\"): ", INFO)
                .WriteLine(wordsResult.JoinWithComma(), VALUES);
        }

        private static void TestMaxExtensions()
        {
            DateTime[] dates =
            {
                new DateTime(2015, 12, 9), new DateTime(1913, 12, 9), new DateTime(2114, 08, 01)
            };

            Helper.ConsoleMio.Write("Initial Collection: ", INFO)
                .WriteLine(dates.JoinWithComma(), VALUES);

            var maxYear = dates.Max(date => date.Year);

            Helper.ConsoleMio.Write("Max(date => date.Year): ", INFO)
                .WriteLine(maxYear.ToString(), VALUES);
        }
    }
}