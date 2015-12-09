namespace PcCatalog
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Xml.Linq;

    public class Computer
    {
        private readonly ISet<Component> components;

        private string name;

        private decimal? price;

        public Computer(string name)
        {
            this.Name = name;
            this.components = new HashSet<Component>();
        }

        public Computer(string name, IEnumerable<Component> components)
            : this(name)
        {
            foreach (var component in components)
            {
                this.AddComponent(component);
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set { this.name = Validator.ValidateString(value, nameof(this.Name)); }
        }

        public IReadOnlyCollection<Component> Components
        {
            get { return (IReadOnlyCollection<Component>)this.components; }
        }

        public decimal Price
        {
            get
            {
                // This way the price is not calculated each time it is 
                // invoked with the getter
                if (this.price == null)
                {
                    this.price = 0;
                    foreach (var component in this.components)
                    {
                        this.price += component.Price;
                    }
                }

                return this.price.Value;
            }
        }

        public override string ToString()
        {
            var complexElement = new XElement(this.GetType().Name);
            complexElement.SetAttributeValue(nameof(this.Name).ToLower(), this.Name);

            foreach (var component in this.components)
            {
                complexElement.Add(component.ToXml());
            }

            var priceElement = new XElement("TotalPrice", this.Price);
            priceElement.SetAttributeValue(
                "currency", RegionInfo.CurrentRegion.ISOCurrencySymbol);

            complexElement.Add(priceElement);

            return complexElement.ToString();
        }

        public void AddComponent(Component component)
        {
            if (component == null)
            {
                throw new ArgumentNullException(
                    nameof(component), "Cannot add a null component");
            }
            else
            {
                this.components.Add(component);
                this.price = null; // Forces price recalculation
            }
        }

        public bool RemoveComponent(Component component)
        {
            if (this.components.Remove(component))
            {
                this.price = null;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
