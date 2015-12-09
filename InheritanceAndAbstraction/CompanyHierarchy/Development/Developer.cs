namespace CompanyHierarchy.Development
{
    using System.Collections.Generic;
    using Contracts;

    public class Developer : Employee, IDeveloper
    {
        public Developer(string firstName, string lastName, string id, decimal salary)
            : base(firstName, lastName, id, salary)
        {
            this.Projects = new Dictionary<string, Project>();
            this.Departemnt = EmployeeDepartemnt.Production;
        }

        public IDictionary<string, Project> Projects { get; }

        public override string ToString()
        {
            return string.Format(
                "{0}{1," + PropertyNamePadding + "}: {2} projects",
                base.ToString(),
                nameof(this.Projects),
                this.Projects.Count);
        }

        public void AddProject(Project project)
        {
            this.Projects.Add(project.ProjectName, project);
        }

        public bool RemoveProject(string name)
        {
            return this.Projects.Remove(name);
        }

        public bool CloseProject(string name)
        {
            if (this.Projects.ContainsKey(name))
            {
                this.Projects[name].CloseProject();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}