namespace Animals
{
    using Contracts;

    public class Kitten : Animal
    {
        private const string KittenWords = "Myauu, myauuu";

        public Kitten(string name, int age) : base(name, age)
        {
            this.Gender = AmimalGender.Female;
        }

        public override string ProduceSound()
        {
            return KittenWords;
        }
    }
}