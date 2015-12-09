namespace CompanyHierarchy.Sales
{
    using System.Collections.Generic;

    public interface ISalesEmployee
    {
        IDictionary<int, Sale> SalesData { get; }

        string ToString();

        void AddSale(Sale sale);

        bool RemoveSale(int id);
    }
}