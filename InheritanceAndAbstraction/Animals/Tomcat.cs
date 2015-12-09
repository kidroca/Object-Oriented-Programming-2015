namespace Animals
{
    using Contracts;

    public class Tomcat : Cat
    {
        private const string TomcatWords = "Matz pis, pis, pis";

        public Tomcat(string name, int age) : base(name, age)
        {
        }

        public override string ProduceSound()
        {
            return TomcatWords;
        }
    }
}