namespace Animals
{
    using Contracts;

    public class Dog : Animal
    {
        private const string DogWords = "Djaf, djaf";

        public Dog(string name, int age) : base(name, age)
        {
        }

        public Dog(string name, int age, AmimalGender gender)
            : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return DogWords;
        }
    }
}