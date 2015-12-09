namespace Persons
{
    using System;
    using System.Text.RegularExpressions;

    public class Person
    {
        private const uint MinAllowedAge = 1;

        private const uint MaxAllowedAge = 100;

        private const string EmailValidationPattern =
            "^(([a-zA-Z]|[0-9])|([-]|[_]|[.]))+[@](([a-zA-Z0-9])|([-])){2,63}[.](([a-zA-Z0-9]){2,63})+$";

        private string name;

        private uint age;

        private string email;

        public Person(string name, uint age)
            : this(name, age, null)
        {
        }

        public Person(string name, uint age, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }

        public string Name
        {
            get { return this.name; }

            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException("the name cannot be null, empty, or white space", nameof(this.Name));
                }

                this.name = value;
            }
        }

        public uint Age
        {
            get { return this.age; }

            set
            {
                if (MinAllowedAge <= value && value <= MaxAllowedAge)
                {
                    this.age = value;
                }
                else
                {
                    throw new ArgumentException(
                        $"Valid ages are between {MinAllowedAge} and {MaxAllowedAge} inclusive", nameof(this.Age));
                }
            }
        }

        public string Email
        {
            get { return this.email; }

            set
            {
                if (value != null && !Regex.IsMatch(value, EmailValidationPattern))
                {
                    throw new ArgumentException("Invalid email address", nameof(this.Email));
                }

                this.email = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
                "Hi, I'm {0}, I'm {1} years old and I {2} an email {3}",
                this.Name,
                this.Age,
                this.Email == null ? "don't have" : "have",
                this.Email ?? string.Empty)
                    .TrimEnd();
        }
    }
}