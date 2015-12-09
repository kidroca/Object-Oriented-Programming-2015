namespace P3_Generic_List
{
    using System;

    public static class ListExtensions
    {
        public static T Min<T>(this GenericList<T> list) where T : IComparable<T>
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            T min = list[0];
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].CompareTo(min) < 0)
                {
                    min = list[i];
                }
            }

            return min;
        }

        public static T Max<T>(this GenericList<T> list) where T : IComparable<T>
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            T max = list[0];
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].CompareTo(max) > 0)
                {
                    max = list[i];
                }
            }

            return max;
        }
    }
}