namespace CompanyHierarchy.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Development;
    using Global;
    using HomeworkHelpers;
    using Sales;

    /// <summary>
    /// Create several employees of type Manager, SalesEmployee and Developer and add them in a
    ///  single collection. Finally, print them in a for-each loop.
    /// </summary>
    public class Program
    {
        private static readonly HomeworkHelper Helper = new HomeworkHelper();

        private static readonly Random Rnd = new Random();

        private static int nextEmployeeId = 1;

        private static void Main()
        {
            Helper.ConsoleMio.Setup();
            Helper.ConsoleMio.PrintHeading("Company Hierarchy ");

            IList<SalesEmployee> salesEmployees = GenereateSalesEmployees();
            IList<Developer> developers = GenerateDevelopers();
            IList<Manager> managers = GenerateManagers(salesEmployees, developers);

            var employees = new List<Employee>();
            employees.AddRange(salesEmployees);
            employees.AddRange(developers);
            employees.AddRange(managers);

            foreach (var employee in employees
                .OrderByDescending(e => e.GetType() == typeof(Manager))
                .ThenBy(e => e.Id))
            {
                Helper.ConsoleMio.WriteLine(employee.ToString(), ConsoleColor.DarkBlue);
                Console.WriteLine();
            }
        }

        private static IList<Manager> GenerateManagers(
            IEnumerable<SalesEmployee> salesEmployees, IEnumerable<Developer> developers)
        {
            IList<Employee> employees = salesEmployees.Concat<Employee>(developers)
                .ToList();

            var managers = new List<Manager>();

            for (int i = 0; i < 5; i++)
            {
                decimal salary = GenerateSalary();

                var manager = new Manager(
                    HumanNames.FirstNames[Rnd.Next(0, HumanNames.FirstNames.Length)],
                    HumanNames.LastNames[Rnd.Next(0, HumanNames.LastNames.Length)],
                    id: $"comEmp{nextEmployeeId++}",
                    salary: salary);

                for (int j = 0; j < Rnd.Next(1, 4); j++)
                {
                    var employee = SelectEmployeeToAdd(employees, manager);
                    employee.ReportsTo = manager;
                    manager.AddEmployeeToTeam(employee);
                }

                managers.Add(manager);
                employees.Add(manager);
            }

            return managers;
        }

        private static Employee SelectEmployeeToAdd(
            IList<Employee> employees, Manager manager)
        {
            int employeeIndex = Rnd.Next(0, employees.Count);
            var employee = employees[employeeIndex];
            employees.RemoveAt(employeeIndex);

            return employee;
        }

        private static IList<Developer> GenerateDevelopers()
        {
            var employees = new List<Developer>();

            for (int i = 0; i < 5; i++)
            {
                decimal salary = GenerateSalary();

                var developer = new Developer(
                    HumanNames.FirstNames[Rnd.Next(0, HumanNames.FirstNames.Length)],
                    HumanNames.LastNames[Rnd.Next(0, HumanNames.LastNames.Length)],
                    id: $"comEmp{nextEmployeeId++}",
                    salary: salary);

                developer.AddProject(new Project((i + 1).ToString(), DateTime.Now));

                employees.Add(developer);
            }

            return employees;
        }

        private static IList<SalesEmployee> GenereateSalesEmployees()
        {
            var employees = new List<SalesEmployee>();

            for (int i = 0; i < 5; i++)
            {
                decimal salary = GenerateSalary();

                var salesEmployee = new SalesEmployee(
                    HumanNames.FirstNames[Rnd.Next(0, HumanNames.FirstNames.Length)],
                    HumanNames.LastNames[Rnd.Next(0, HumanNames.LastNames.Length)],
                    id: $"comEmp{nextEmployeeId++}",
                    salary: salary);

                salesEmployee.AddSale(
                    new Sale(i + 1, (i + 1).ToString(), salary / 2, DateTime.Now));

                employees.Add(salesEmployee);
            }

            return employees;
        }

        private static decimal GenerateSalary()
        {
            return Rnd.Next(
                    (int)Employee.MinimumMonthlyWage * 100,
                    (int)Employee.MinimumMonthlyWage * 100000) / 100;
        }
    }
}
