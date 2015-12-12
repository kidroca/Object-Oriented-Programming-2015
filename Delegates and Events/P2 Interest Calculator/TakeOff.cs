namespace P2_Interest_Calculator
{
    using System;
    using HomeworkHelpers;

    /// <summary>
    /// Create a class InterestCalculator that takes in its constructor money, interest, years 
    /// and interest calculation delegate. 
    /// </summary>
    public class TakeOff
    {
        private const int COMPOUND_TIMES = 12;
        private const ConsoleColor TABLE_ROW = ConsoleColor.DarkCyan;

        private static readonly HomeworkHelper Helper = new HomeworkHelper();

        private static void Main()
        {
            Helper.ConsoleMio.Setup();
            Helper.ConsoleMio.PrintHeading("Interest Calculator ");

            var compoundCalculator = new InterestCalculator(500, 5.6, 10, GetCompoundInterest);
            var simpleCalculator = new InterestCalculator(500, 5.6, 10, GetSimpleInterest);

            Helper.ConsoleMio.WriteLine(
                "{0,-15}|{1,-15}|{2,-15}|{3,-25}|{4,-29}",
                ConsoleColor.Blue,
                "Money",
                "Interest",
                "Years",
                "Type",
                "Result")
                .WriteLine(compoundCalculator.ToString(), TABLE_ROW)
                .WriteLine(simpleCalculator.ToString(), TABLE_ROW);

            compoundCalculator = new InterestCalculator(2500, 7.2, 15, GetCompoundInterest);
            simpleCalculator = new InterestCalculator(2500, 7.2, 15, GetSimpleInterest);

            Helper.ConsoleMio
                .WriteLine(compoundCalculator.ToString(), TABLE_ROW)
                .WriteLine(simpleCalculator.ToString(), TABLE_ROW);
        }

        private static decimal GetSimpleInterest(decimal sum, double interest, int years)
        {
            interest /= 100;
            return sum *= ((decimal)interest * years) + 1;
        }

        private static decimal GetCompoundInterest(decimal sum, double interest, int years)
        {
            interest /= 100;
            double calculation = (interest / COMPOUND_TIMES) + 1;
            double power = Math.Pow(calculation, years * COMPOUND_TIMES);

            return sum * (decimal)power;
        }
    }
}