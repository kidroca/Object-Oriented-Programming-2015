namespace CompanyHierarchy.Sales
{
    using System.Collections.Generic;
    using Contracts;

    public class SalesEmployee : Employee, ISalesEmployee
    {
        public SalesEmployee(string firstName, string lastName, string id, decimal salary) : base(firstName, lastName, id, salary)
        {
            this.SalesData = new Dictionary<int, Sale>();
            this.Departemnt = EmployeeDepartemnt.Sales;
        }

        public IDictionary<int, Sale> SalesData { get; }

        public override string ToString()
        {
            return string.Format(
                "{0}{1," + PropertyNamePadding + "}: {2} sales",
                base.ToString(),
                nameof(this.SalesData),
                this.SalesData.Count);
        }

        public void AddSale(Sale sale)
        {
            this.SalesData.Add(sale.Id, sale);
        }

        public bool RemoveSale(int id)
        {
            return this.SalesData.Remove(id);
        }
    }
}