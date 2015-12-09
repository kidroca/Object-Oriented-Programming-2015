namespace CompanyHierarchy.Development
{
    using System.Collections.Generic;

    public interface IDeveloper
    {
        IDictionary<string, Project> Projects { get; }

        string ToString();

        void AddProject(Project project);

        bool RemoveProject(string name);

        bool CloseProject(string name);
    }
}