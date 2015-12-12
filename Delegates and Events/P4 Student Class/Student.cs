namespace P4_Student_Class
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Student
    {
        public event EventHandler<PropertyChangedEventArgs<object>> PropertyChange;

        private string firstName;
        private string lastName;
        private string email;

        public Student(string firstName, string lastName, string email = null)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
        }

        [Required]
        [RegularExpression("[A-Z][a-z]+")]
        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                Validator.ValidateProperty(value, new ValidationContext(this)
                {
                    MemberName = nameof(this.FirstName)
                });

                FireEvent(this.PropertyChange, this, nameof(this.FirstName), value, this.FirstName);

                this.firstName = value;
            }
        }

        [Required]
        [RegularExpression("[A-Z][a-z]+")]
        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                Validator.ValidateProperty(value, new ValidationContext(this)
                {
                    MemberName = nameof(this.LastName)
                });

                FireEvent(this.PropertyChange, this, nameof(this.LastName), value, this.LastName);

                this.lastName = value;
            }
        }

        [EmailAddress]
        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                Validator.ValidateProperty(value, new ValidationContext(this)
                {
                    MemberName = nameof(this.Email)
                });

                FireEvent(this.PropertyChange, this, nameof(this.Email), value, this.Email);

                this.email = value;
            }
        }

        private static void FireEvent(
            EventHandler<PropertyChangedEventArgs<object>> handler,
            Student student,
            string propName,
            object value,
            object oldValue)
        {
            if (handler != null)
            {
                var args = new PropertyChangedEventArgs<object>(propName, oldValue, value);
                handler(student, args);
            }
        }

        public void AttachHandler(EventHandler<PropertyChangedEventArgs<object>> onPropertyChange)
        {
            this.PropertyChange += onPropertyChange;
        }

        public void DetachHandler(EventHandler<PropertyChangedEventArgs<object>> onPropertyChange)
        {
            this.PropertyChange -= onPropertyChange;
        }
    }
}