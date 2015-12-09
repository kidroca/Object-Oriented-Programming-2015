namespace HumanStudentAndWorker
{
    using Global;

    public abstract class Human
    {
        private string firstName;

        private string lastName;

        protected Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                this.firstName = PropertyValidator.ValidateString(
                    value, $"{this.GetType().Name} -> {nameof(this.FirstName)}");
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                this.lastName = PropertyValidator.ValidateString(
                    value, $"{this.GetType().Name} -> {nameof(this.LastName)}");
            }
        }

        public override string ToString()
        {
            return $"I'm {this.FirstName} {this.LastName}";
        }
    }
}