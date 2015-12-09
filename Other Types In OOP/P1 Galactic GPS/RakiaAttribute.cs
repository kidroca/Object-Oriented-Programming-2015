namespace P1_Galactic_GPS
{
    using System;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
    public class RakiaAttribute : Attribute
    {
        public RakiaAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}