namespace P2_Fraction_Calculator
{
    using System;
    using HomeworkHelpers;

    /// <summary>
    /// Create a struct Fraction that holds the numerator and denominator of a fraction as 
    /// fields. A fraction is the division of two rational numbers (e.g. 22 / 7, where 22 
    /// is the numerator and 7 is the denominator).
    /// •   The struct constructor takes the numerator and denominator as arguments. They 
    ///     are integer numbers in the range [-9223372036854775808 … 9223372036854775807].
    /// •   Validate the input through properties. The denominator cannot be 0. Throw 
    ///     proper exceptions with descriptive messages.
    /// •   Overload the + and - operators to perform addition and subtraction on objects 
    ///     of type Fraction. The result should be a new Fraction.
    /// •   Override ToString() to print the fraction in floating-point format.
    /// </summary>
    public class Program
    {
        private const ConsoleColor INFO = ConsoleColor.Blue;
        private const ConsoleColor VALUE = ConsoleColor.DarkCyan;

        private static readonly HomeworkHelper Helper = new HomeworkHelper();

        private static void Main()
        {
            Helper.ConsoleMio.Setup();
            Helper.ConsoleMio.PrintHeading("Fraction Calculator");

            var fractionA = new Fraction(5, 7);
            PrintDetails(fractionA, "A:");

            var fractionB = new Fraction(6, 4);
            PrintDetails(fractionB, "B:");

            var fractionC = fractionA + fractionB;
            PrintDetails(fractionC, "C = A + B:");

            fractionA = fractionC - fractionB;
            PrintDetails(fractionA, "A = C - B");

            var fractionD = fractionA - fractionC;
            PrintDetails(fractionD, "D = A - C");

            fractionA = fractionD + fractionC;
            PrintDetails(fractionA, "A = D + C");
        }

        private static void PrintDetails(Fraction fraction, string prefix)
        {
            Helper.ConsoleMio.WriteLine(prefix, INFO)
                .Write("numerator: ", INFO)
                .WriteLine(fraction.Numerator.ToString(), VALUE)
                .Write("denominator: ", INFO)
                .WriteLine(fraction.Denominator.ToString(), VALUE)
                .Write("float value: ", INFO)
                .WriteLine(fraction.ToString(), VALUE);

            Console.WriteLine();
        }
    }
}
