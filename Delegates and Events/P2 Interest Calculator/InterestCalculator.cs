namespace P2_Interest_Calculator
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class InterestCalculator : IInterestCalculator
    {
        private decimal money;
        private double interest;
        private int years;

        public InterestCalculator(
            decimal money, double interest, int years, Func<decimal, double, int, decimal> calculationFormula)
        {
            this.Money = money;
            this.Interest = interest;
            this.Years = years;
            this.CalculateInterest = calculationFormula;
        }

        [MinValue(0)]
        public decimal Money
        {
            get
            {
                return this.money;
            }

            set
            {
                Validator.ValidateProperty(value, new ValidationContext(this)
                {
                    MemberName = nameof(this.Money)
                });

                this.money = value;
            }
        }

        [MinValue(0, inclusive: false)]
        public double Interest
        {
            get
            {
                return this.interest;
            }

            set
            {
                Validator.ValidateProperty(value, new ValidationContext(this)
                {
                    MemberName = nameof(this.Interest)
                });

                this.interest = value;
            }
        }

        [MinValue(0)]
        public int Years
        {
            get
            {
                return this.years;
            }

            set
            {
                Validator.ValidateProperty(value, new ValidationContext(this)
                {
                    MemberName = nameof(this.Years)
                });

                this.years = value;
            }
        }

        public Func<decimal, double, int, decimal> CalculateInterest { get; set; }

        public override string ToString()
        {
            return string.Format(
                "{0,-15}|{1,-14}%|{2,-15}|{3,-25}|{4:F4}",
                this.Money,
                this.Interest,
                this.Years,
                this.CalculateInterest.Method.Name,
                this.CalculateInterest(this.money, this.Interest, this.Years));
        }
    }
}