namespace CompanyHierarchy.Development
{
    using System;
    using Global;

    public class Project
    {
        private string projectName;

        private string details;

        public Project(string name, DateTime startingDate)
        {
            this.ProjectName = name;
            this.StartDate = startingDate;
            this.State = ProjectState.Open;
        }

        public string ProjectName
        {
            get
            {
                return this.projectName;
            }

            set
            {
                this.projectName = PropertyValidator.ValidateString(
                    value, nameof(this.ProjectName));
            }
        }

        public string Details
        {
            get
            {
                return this.details;
            }

            set
            {
                this.details = PropertyValidator.ValidateString(
                    value, nameof(this.Details));
            }
        }

        public DateTime StartDate { get; }

        public ProjectState State { get; private set; }

        public void CloseProject()
        {
            if (this.State == ProjectState.Closed)
            {
                throw new InvalidOperationException("The project is already closed.");
            }

            this.State = ProjectState.Closed;
        }
    }
}