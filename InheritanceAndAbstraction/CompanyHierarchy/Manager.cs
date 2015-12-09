namespace CompanyHierarchy
{
    using System.Collections.Generic;
    using Contracts;

    public class Manager : Employee, IManager
    {
        public Manager(string firstName, string lastName, string id, decimal salary) : base(firstName, lastName, id, salary)
        {
            this.Team = new Dictionary<string, Employee>();
        }
        public Manager(
            string firstName, string lastName, string id, decimal salary, Manager manager)
            : this(firstName, lastName, id, salary)
        {
            this.ReportsTo = manager;
        }

        public IDictionary<string, Employee> Team { get; }

        public override string ToString()
        {
            return string.Format(
                "{0}{1," + PropertyNamePadding + "}: {2} members",
                base.ToString(),
                nameof(this.Team),
                this.Team.Count);
        }

        public void AddEmployeeToTeam(Employee employee)
        {
            this.Team.Add(employee.Id, employee);
        }

        public Employee RemoveEmployee(string id)
        {
            if (!this.Team.ContainsKey(id))
            {
                throw new KeyNotFoundException("No such Id in the this Manager's Team");
            }

            var employee = this.Team[id];
            this.Team.Remove(id);

            return employee;
        }

        public bool IsManagingEmployee(string id)
        {
            return this.Team.ContainsKey(id);
        }
    }
}