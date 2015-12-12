namespace P1_Custom_LINQ_Extension_Methods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ExtensionsLinq
    {
        public static IEnumerable<T> WhereNot<T>(
            this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            var result = new List<T>();
            foreach (var item in collection)
            {
                if (!predicate(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public static string JoinWithComma<T>(this IEnumerable<T> collection)
        {
            return string.Join(", ", collection);
        }

        public static TSelector Max<TSource, TSelector>(
            this IEnumerable<TSource> collection, Func<TSource, TSelector> callback)
            where TSelector : IComparable<TSelector>
        {
            TSelector max = callback(collection.First());

            foreach (var item in collection)
            {
                TSelector value = callback(item);
                if (value.CompareTo(max) > 0)
                {
                    max = value;
                }
            }

            return max;
        }
    }
}