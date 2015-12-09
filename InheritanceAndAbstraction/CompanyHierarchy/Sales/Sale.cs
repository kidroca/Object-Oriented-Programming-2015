namespace CompanyHierarchy.Sales
{
    using System;
    using System.Text;
    using Global;

    public class Sale
    {
        private string productName;

        private decimal price;

        public Sale(int id, string productName, decimal price, DateTime date)
        {
            this.Id = PropertyValidator.ValidateNumber(id, nameof(id), 0, int.MaxValue);
            this.ProductName = productName;
            this.Price = price;
            this.Date = date;
        }

        public string ProductName
        {
            get
            {
                return this.productName;
            }

            set
            {
                this.productName = PropertyValidator.ValidateString(
                    value, nameof(this.ProductName));
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                this.price = PropertyValidator.ValidateNumber(
                    value,
                    nameof(this.Price),
                    0,
                    decimal.MaxValue);
            }
        }

        public DateTime Date { get; private set; }

        public int Id { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendFormat("Product: {0}\n", this.ProductName);
            sb.AppendFormat("Price  : {0}\n", this.Price);
            sb.AppendFormat("Date   : {0}\n", this.Date.ToShortDateString());

            return sb.ToString();
        }
    }
}