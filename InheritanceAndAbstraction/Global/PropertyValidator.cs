namespace Global
{
    using System;
    using System.Text.RegularExpressions;

    public class PropertyValidator
    {
        private static readonly Regex FacutyNumberPattern = new Regex("^[A-Za-z0-9]{5,10}$");

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

        public static string ValidateIdentityString(string number, string propName)
        {
            if (FacutyNumberPattern.IsMatch(number))
            {
                return number;
            }
            else
            {
                throw new ArgumentException($"Invalid {propName}, foramt doesn't match");
            }
        }
    }
}