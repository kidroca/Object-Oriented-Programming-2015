namespace Animals.Contracts
{
    using Global;

    public abstract class Animal : ISoundProducible
    {
        public const int MinimumAge = 1;

        public const int MaximumAge = 1000000;

        private int age;

        private string name;

        protected Animal(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = AmimalGender.Male;
        }

        protected Animal(string name, int age, AmimalGender gender)
            : this(name, age)
        {
            this.Gender = gender;
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                this.age = PropertyValidator.ValidateNumber(
                    value,
                    $"{this.GetType().Name} -> {nameof(this.Age)}",
                    MinimumAge,
                    MaximumAge);
            }
        }

        public AmimalGender Gender { get; protected set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = PropertyValidator.ValidateString(
                    value, $"{this.GetType().Name} -> {nameof(this.Name)}");
            }
        }

        public abstract string ProduceSound();
    }
}