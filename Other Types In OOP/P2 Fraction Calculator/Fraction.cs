namespace P2_Fraction_Calculator
{
    using System;

    public struct Fraction
    {
        private long denominator;

        public Fraction(long numerator, long denominator) : this()
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public long Numerator { get; private set; }

        public long Denominator
        {
            get
            {
                return this.denominator;
            }

            private set
            {
                if (value == 0)
                {
                    throw new ArithmeticException("A Denominator cannot be 0");
                }

                this.denominator = value;
            }
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            Fraction result;

            if (a.denominator != b.denominator)
            {
                long numerator =
                    (a.Numerator * b.Denominator) +
                     (b.Numerator * a.Denominator);

                long denominator = b.Denominator * a.Denominator;

                result = new Fraction(numerator, denominator);
                result.SimplifyFraction();
            }
            else
            {
                result = new Fraction(a.Numerator + b.Numerator, a.Denominator);
            }

            return result;
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            var result = a + new Fraction(-b.Numerator, b.Denominator);

            return result;
        }

        public override string ToString()
        {
            return ((double)this.Numerator / this.Denominator).ToString();
        }

        /// <summary>
        /// Gets the greatest common divisor of the members of this fraction
        /// </summary>
        /// <returns></returns>
        public long GetGreatestCommonDivisor()
        {
            long a = this.Numerator,
                b = this.Denominator;

            while (b != 0)
            {
                long t = b;
                b = a % b;
                a = t;
            }

            return a;
        }

        /// <summary>
        /// This method is private because it modifies/mutates the fraction properties and breaks the
        /// general rule that structures should be immutable
        /// </summary>
        private void SimplifyFraction()
        {
            long gcd = this.GetGreatestCommonDivisor();
            if (gcd == 1)
            {
                return;
            }

            this.Denominator /= gcd;
            this.Numerator /= gcd;
        }
    }
}