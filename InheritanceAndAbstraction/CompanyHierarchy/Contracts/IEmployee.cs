namespace CompanyHierarchy.Contracts
{
    public interface IEmployee
    {
        decimal Salary { get; }

        EmployeeDepartemnt Departemnt { get; }
    }
}