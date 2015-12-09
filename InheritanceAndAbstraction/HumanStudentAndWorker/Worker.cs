namespace HumanStudentAndWorker
{
    using System;
    using Global;

    public class Worker : Human
    {
        public const decimal MinimalSalary = 200;

        public const int MinimalWorkHoursPerDay = 2;

        public const int MaximalWorkHoursPerDay = 10;

        public const int WorkdaysPerWeek = 5;

        private decimal weeklySalary;

        private int workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weeklySalary, int workHours)
            : base(firstName, lastName)
        {
            this.WeeklySalary = weeklySalary;
            this.WorkHoursPerDay = workHours;
        }

        public decimal WeeklySalary
        {
            get
            {
                return this.weeklySalary;
            }

            set
            {
                this.weeklySalary = PropertyValidator.ValidateNumber(
                    value,
                    $"{this.GetType().Name} -> {nameof(this.WeeklySalary)}",
                    MinimalSalary,
                    decimal.MaxValue);
            }
        }

        public int WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }

            set
            {
                this.workHoursPerDay = PropertyValidator.ValidateNumber(
                    value,
                    $"{this.GetType().Name} -> {nameof(this.WorkHoursPerDay)}",
                    MinimalWorkHoursPerDay,
                    MaximalWorkHoursPerDay);
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()} and I'm working, my hourly " +
                   $"payment is {Math.Round(this.GetMoneyPerHour() * 100) / 100}";
        }

        public decimal GetMoneyPerHour()
        {
            return this.WeeklySalary / WorkdaysPerWeek / this.WorkHoursPerDay;
        }
    }
}