namespace HumanStudentAndWorker
{
    using Global;

    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }

            set
            {
                this.facultyNumber = PropertyValidator.ValidateIdentityString(
                    value, nameof(this.FacultyNumber));
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()} and I'm a Student: {this.FacultyNumber}";
        }
    }
}