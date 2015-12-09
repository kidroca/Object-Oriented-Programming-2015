namespace CompanyHierarchy
{
    using System.Collections.Generic;
    using Contracts;

    public interface IManager
    {
        IDictionary<string, Employee> Team { get; }

        void AddEmployeeToTeam(Employee employee);

        Employee RemoveEmployee(string id);

        bool IsManagingEmployee(string id);
    }
}