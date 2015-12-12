namespace P2_Interest_Calculator
{
    using System;

    public interface IInterestCalculator
    {
        decimal Money { get; }

        double Interest { get; }

        int Years { get; }

        Func<decimal, double, int, decimal> CalculateInterest { get; }
    }
}