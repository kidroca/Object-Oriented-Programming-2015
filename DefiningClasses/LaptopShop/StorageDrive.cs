namespace LaptopShop
{
    using System;

    public class StorageDrive
    {
        private const uint MinimumCapacity = 20;

        private const uint MaximumCapacity = 5000;

        private uint capacity;

        public StorageDrive(uint capacity, DriveType type)
        {
            this.Capacity = capacity;
            this.Type = type;
        }

        public DriveType Type { get; set; }

        public uint Capacity
        {
            get
            {
                return this.capacity;
            }

            set
            {
                if (value < MinimumCapacity || MaximumCapacity < value)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(this.Capacity),
                        value,
                        $"Disk capacity must be between {MinimumCapacity} and {MaximumCapacity}");
                }

                this.capacity = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Capacity}GB {this.Type}";
        }
    }

    public enum DriveType
    {
        Hdd = 0,
        Ssd = 1,
        Hybrid = 2
    }
}