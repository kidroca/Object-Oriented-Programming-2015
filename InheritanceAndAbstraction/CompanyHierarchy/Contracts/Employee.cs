namespace CompanyHierarchy.Contracts
{
    using Global;

    public abstract class Employee : Person, IEmployee, IManaged
    {
        public const decimal MinimumMonthlyWage = 600;

        private decimal salary;

        protected Employee(string firstName, string lastName, string id, decimal salary)
            : base(firstName, lastName, id)
        {
            this.Salary = salary;
        }

        public decimal Salary
        {
            get
            {
                return this.salary;
            }

            set
            {
                this.salary = PropertyValidator.ValidateNumber(
                    value,
                    nameof(this.Salary),
                    MinimumMonthlyWage,
                    decimal.MaxValue);
            }
        }

        public EmployeeDepartemnt Departemnt { get; set; }

        public Employee ReportsTo { get; set; }

        public override string ToString()
        {
            return string.Format(
                "{0}{1," + PropertyNamePadding + "}: {2}\n",
                base.ToString(),
                nameof(this.ReportsTo),
                this.ReportsTo == null
                    ? "None"
                    : $"{this.ReportsTo.Id} {this.ReportsTo.LastName}");
        }
    }
}