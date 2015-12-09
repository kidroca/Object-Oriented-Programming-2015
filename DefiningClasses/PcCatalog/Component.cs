namespace PcCatalog
{
    using System;
    using System.Xml.Linq;

    public class Component
    {
        private const decimal MinPrice = 0.01m;

        private string name;

        private string details;

        private decimal price;

        public Component(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public Component(string name, decimal price, string details)
            : this(name, price)
        {
            this.Details = details;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set { this.name = Validator.ValidateString(value, nameof(this.Name)); }
        }

        public string Details
        {
            get
            {
                return this.details;
            }

            set
            {
                { this.details = Validator.ValidateString(value, nameof(this.Details)); }
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
                this.price = Validator.ValidateNumber(
                    value, nameof(this.Price), min: MinPrice, max: Decimal.MaxValue);
            }
        }

        public XElement ToXml()
        {
            var xmlBuilder = new XElement(this.GetType().Name);

            foreach (var prop in this.GetType().GetProperties())
            {
                var value = prop.GetValue(this);
                if (value != null)
                {
                    xmlBuilder.Add(new XElement(prop.Name, value));
                }
            }

            return xmlBuilder;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() << 2 + this.Price.GetHashCode();
        }
    }
}