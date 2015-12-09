namespace P4_Generic_List_Version
{
    using System;

    [AttributeUsage((AttributeTargets)1116)]
    public class VersionAttribute : Attribute
    {
        public VersionAttribute(int major, int minor)
        {
            if (major < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(major), major, "Value should be positive");
            }

            if (minor < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(minor), minor, "Value should be positive");
            }

            this.Major = (int)major;
            this.Minor = (int)minor;
        }

        public VersionAttribute(Version version)
        {
            this.Major = version.Major;
            this.Minor = version.Minor;
        }

        public int Major { get; }

        public int Minor { get; }

        public override string ToString()
        {
            return string.Format("{0}.{1}", this.Major, this.Minor);
        }
    }
}
