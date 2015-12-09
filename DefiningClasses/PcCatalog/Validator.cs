namespace PcCatalog
{
    using System;

    public class Validator
    {
        public static string ValidateString(string value, string nameOfParameter)
        {
            if (string.IsNullOrEmpty(value.Trim()))
            {
                throw new ArgumentException(
                    $"You cannot input null or empty for {nameOfParameter}");
            }
            else
            {
                return value;
            }
        }

        public static T ValidateNumber<T>(
            T value, string nameOfParameter, T min, T max) where T : IComparable<T>
        {
            if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameOfParameter, value, $"Expected a value between {min} and {max}");
            }
            else
            {
                return value;
            }
        }
    }
}