namespace LaptopShop
{
    using System;

    public class Battery
    {
        private const uint MinimumCellsCount = 1;

        private const uint MaximumCellsCount = 24;

        private const uint MinimumAmpereHours = 1000;

        private const uint MaximumAmpereHours = 200000;

        private const double MinimumBatteryLife = 0.33;

        private const double MaximumBatteryLife = 24;

        private uint cellsCount;

        private uint miliAmpereHours;

        private double batteryLife;

        public Battery(BatteryType type, uint cellsCount, uint miliApmpereHours, double batteryLife)
        {
            this.Type = type;
            this.CellsCount = cellsCount;
            this.MiliAmpereHours = miliApmpereHours;
            this.BatteryLife = batteryLife;
        }

        public uint CellsCount
        {
            get
            {
                return this.cellsCount;
            }

            set
            {
                if (value < MinimumCellsCount || MaximumCellsCount < value)
                {
                    throw new ArgumentException(
                        $"Cells count must be between {MinimumCellsCount} and {MaximumCellsCount}");
                }

                this.cellsCount = value;
            }
        }

        public BatteryType Type { get; set; }

        public uint MiliAmpereHours
        {
            get
            {
                return this.miliAmpereHours;
            }

            set
            {
                if (value < MinimumAmpereHours || MaximumAmpereHours < value)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(this.MiliAmpereHours),
                        value,
                        $"The battery miliampere hours are out of the allowed range ({MinimumAmpereHours} to {MaximumAmpereHours}");
                }

                this.miliAmpereHours = value;
            }
        }

        public double BatteryLife
        {
            get
            {
                return this.batteryLife;
            }

            set
            {
                if (value < MinimumBatteryLife || MaximumBatteryLife < value)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(this.BatteryLife),
                        value,
                        "Battery life given is out of range");
                }

                this.batteryLife = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Type}, {this.CellsCount} cells, {this.MiliAmpereHours} mAh\n" +
                   $"battery life  : {this.BatteryLife} hours";
        }
    }

    public enum BatteryType
    {
        LiIon = 0,
        Polymer = 1,
        NiMh = 2,
        Kartofi = 3
    }
}
