namespace LaptopShop
{
    using System;
    using System.Globalization;
    using System.Text;

    public class Laptop
    {
        private const uint MinimumRam = 1;

        private const uint MaximumRam = 128;

        private const decimal MinimumPrice = 0.01m;

        private const int StringPadding = -14;

        private string model;

        private string manucafturer;

        private string proccessor;

        private uint ram;

        private string graphicsCard;

        private StorageDrive storage;

        private string screen;

        private Battery battery;

        private decimal price;

        public Laptop(string model, decimal price)
        {
            this.Model = model;
            this.Price = price;
        }

        public Laptop(
            string model, string manufacturer, string proccessor, uint ram, string graphicsCard, StorageDrive drive,
            string screen, Battery battery, decimal price) : this(model, price)
        {
            this.Manucafturer = manufacturer;
            this.Proccessor = proccessor;
            this.Ram = ram;
            this.GraphicsCard = graphicsCard;
            this.Storage = drive;
            this.Screen = screen;
            this.Battery = battery;
        }

        public string Model
        {
            get { return this.model; }

            set
            {
                ValidateString(value, nameof(this.Model));
                this.model = value;
            }
        }

        public string Manucafturer
        {
            get
            {
                return this.manucafturer;
            }

            set
            {
                ValidateString(value, nameof(this.Manucafturer));
                this.manucafturer = value;
            }
        }

        public string Proccessor
        {
            get
            {
                return this.proccessor;
            }

            set
            {
                ValidateString(value, nameof(this.Proccessor));
                this.proccessor = value;
            }
        }

        public uint Ram
        {
            get
            {
                return this.ram;
            }

            set
            {
                if (value < MinimumRam || MaximumRam < value)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(this.Ram),
                        value,
                        $"Ram must be between {MinimumRam} and {MaximumRam}");
                }

                this.ram = value;
            }
        }

        public string GraphicsCard
        {
            get
            {
                return this.graphicsCard;
            }

            set
            {
                ValidateString(value, nameof(this.GraphicsCard));
                this.graphicsCard = value;
            }
        }

        public StorageDrive Storage
        {
            get
            {
                return this.storage;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(
                        nameof(this.Storage), "The storage cannot be null");
                }

                this.storage = value;
            }
        }

        public string Screen
        {
            get
            {
                return this.screen;
            }

            set
            {
                ValidateString(value, nameof(this.Screen));
                this.screen = value;
            }
        }

        public Battery Battery
        {
            get
            {
                return this.battery;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(
                        nameof(this.Battery), "The battery cannot be null");
                }

                this.battery = value;
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
                if (value < MinimumPrice)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(this.Price),
                        value,
                        $"Price should definately be at least {MinimumPrice}");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var property in this.GetType().GetProperties())
            {
                var value = property.GetValue(this);
                if (value != null)
                {
                    sb.AppendFormat(
                            "{0," + StringPadding + "}: {1}", property.Name, value);

                    if (property.Name.Equals(nameof(this.Ram)))
                    {
                        if ((uint)value > 0)
                        {
                            sb.Append("Gb");
                        }
                        else
                        {
                            int charsCount = property.Name.Length - StringPadding + 1;
                            sb.Remove(sb.Length - charsCount, charsCount);
                        }

                    }
                    else if (property.Name.Equals("Price"))
                    {
                        var ri = RegionInfo.CurrentRegion;
                        sb.AppendFormat(" {0}", ri.ISOCurrencySymbol);
                    }

                    sb.AppendLine();
                }
            }

            return sb.ToString();
        }

        private static void ValidateString(string value, string checkedParameterName)
        {
            if (string.IsNullOrEmpty(value.Trim()))
            {
                throw new ArgumentException("Value cannot be null or empty", checkedParameterName);
            }
        }
    }
}