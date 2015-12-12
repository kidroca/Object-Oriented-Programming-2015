namespace P4_Student_Class
{
    using System;

    public class PropertyChangedEventArgs<T> : EventArgs
    {
        public PropertyChangedEventArgs(string propertyName, T oldValue, T newValue)
        {
            this.PropertyName = propertyName;
            this.OldValue = oldValue;
            this.NewValue = newValue;
        }

        public string PropertyName { get; }

        public T OldValue { get; }

        public T NewValue { get; }

        public override string ToString()
        {
            return string.Format(
                "{0} -> Old: {1}, New: {2}",
                this.PropertyName,
                this.OldValue,
                this.NewValue);
        }
    }
}