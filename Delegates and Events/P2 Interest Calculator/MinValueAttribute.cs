namespace P2_Interest_Calculator
{
    using System.ComponentModel.DataAnnotations;

    public class MinValueAttribute : ValidationAttribute
    {
        public MinValueAttribute(object minimum, bool inclusive = true)
        {
            this.Minimum = minimum;
            this.IsInclusive = inclusive;
        }

        public object Minimum { get; }

        public bool IsInclusive { get; }

        public override bool IsValid(dynamic value)
        {
            if (this.IsInclusive)
            {
                return (dynamic)this.Minimum <= value;
            }
            else
            {
                return (dynamic)this.Minimum < value;
            }
        }
    }
}