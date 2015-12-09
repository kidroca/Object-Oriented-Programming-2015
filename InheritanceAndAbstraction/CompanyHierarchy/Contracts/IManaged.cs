namespace CompanyHierarchy.Contracts
{
    public interface IManaged
    {
        Employee ReportsTo { get; }
    }
}