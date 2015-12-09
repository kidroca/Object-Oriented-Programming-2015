namespace P1_Galactic_GPS
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [Rakia("Big")]
    [Rakia("Big")]
    [Rakia("Small")]
    public struct Location
    {
        public const double MaxLatitude = 90;
        public const double MinLatitude = -90;

        public const double MaxLongitude = 180;
        public const double MinLongitude = -180;

        private double latitude;
        private double longitude;
        private string name;

        public Location(double latitude, double longitude, Planet? planet = null, string name = null)
            : this()
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Planet = planet;
            this.Name = name;
        }

        [Range(MinLatitude, MaxLatitude, ErrorMessage = "Latitude is out of the allowed range")]
        public double Latitude
        {
            get { return this.latitude; }

            set
            {
                Validator.ValidateProperty(value, new ValidationContext(this, null, null)
                {
                    MemberName = nameof(this.Latitude)
                });

                this.latitude = value;
            }
        }

        [Range(MinLongitude, MaxLongitude, ErrorMessage = "Longitude is out of the allowed range")]
        public double Longitude
        {
            get
            {
                return this.longitude;
            }

            set
            {
                Validator.ValidateProperty(value, new ValidationContext(this, null, null)
                {
                    MemberName = nameof(this.Longitude)
                });

                this.longitude = value;
            }
        }

        [MinLength(2, ErrorMessage = "If a location has a name it must be at least 2 characters long")]
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Validator.ValidateProperty(value, new ValidationContext(this, null, null)
                {
                    MemberName = nameof(this.Name)
                });

                this.name = value;
            }
        }

        public Planet? Planet { get; set; }

        public override string ToString()
        {
            return string.Format(
                "{0} {1}° {2}, {3}° {4} - {5}",
                this.Name ?? string.Empty,
                Math.Abs(this.Latitude),
                this.Latitude >= 0 ? "North" : "South",
                Math.Abs(this.Longitude),
                this.Longitude >= 0 ? "East" : "West",
                this.Planet == null ? "Unspecified Planet" : this.Planet.ToString()).Trim();
        }
    }
}