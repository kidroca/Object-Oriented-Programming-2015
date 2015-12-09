namespace CompanyHierarchy.Contracts
{
    using System;
    using System.Collections;
    using System.Text;
    using Global;
    using HumanStudentAndWorker;

    public abstract class Person : Human, IPerson, IEquatable<Person>
    {
        protected const int PropertyNamePadding = -15;

        protected Person(string firstName, string lastName, string id)
            : base(firstName, lastName)
        {
            this.Id = PropertyValidator.ValidateIdentityString(
                    id, nameof(this.Id));
        }

        public string Id { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("Ocupation: {0}\n", this.GetType().Name);

            foreach (var property in this.GetType().GetProperties())
            {
                if (property.PropertyType != typeof(string)
                    && (typeof(IEnumerable).IsAssignableFrom(property.PropertyType)
                    || property.PropertyType.IsClass))
                {
                    continue;
                }

                var value = property.GetValue(this);

                sb.AppendFormat(
                    "{0," + PropertyNamePadding + "}: {1}\n", property.Name, value);
            }

            return sb.ToString();
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public bool Equals(Person other)
        {
            return this.Id.Equals(other.Id, StringComparison.Ordinal);
        }
    }
}