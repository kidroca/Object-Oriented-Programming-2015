namespace Animals
{
    using Contracts;

    public class Frog : Animal
    {
        private const string FrogWords = "Kva, kva";

        public Frog(string name, int age) : base(name, age)
        {
        }

        public Frog(string name, int age, AmimalGender gender)
            : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return FrogWords;
        }
    }
}