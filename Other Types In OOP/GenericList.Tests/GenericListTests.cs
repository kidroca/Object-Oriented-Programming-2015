namespace GenericList.Tests
{
    using System;
    using System.Reflection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using P3_Generic_List;
    using P4_Generic_List_Version;

    [TestClass]
    public class GenericListTests
    {
        [TestMethod]
        public void AddingToListShouldIncreaseCount()
        {
            var list = new GenericList<int>();
            Assert.AreEqual(0, list.Count, "Initial count should be zero");

            for (int i = 1; i <= 10; i++)
            {
                list.Add(i);
                Assert.AreEqual(i, list.Count, "The count should be equal to the added items");
            }
        }

        [TestMethod]
        public void ListShouldResizeWhenCapacityIsReached()
        {
            var list = new GenericList<DateTime>(4);
            int initialCapacity = list.Capacity;
            Assert.AreEqual(
                4, initialCapacity, "Initial capacity should be as specified in the constructor");

            for (int i = 0; i < 10; i++)
            {
                list.Add(DateTime.Now.AddDays(i));
            }

            Assert.IsTrue(list.Capacity > initialCapacity, "Capacity should have increased");
        }

        [TestMethod]
        public void IndexOfShouldWorkProperly()
        {
            GenericList<int> list = GenerateCollection(0, 9);

            string messageFormat = "{0} should be at index {0}";

            Assert.AreEqual(0, list.IndexOf(0), string.Format(messageFormat, 0, 0));
            Assert.AreEqual(4, list.IndexOf(4), string.Format(messageFormat, 4, 4));
            Assert.AreEqual(5, list.IndexOf(5), string.Format(messageFormat, 5, 5));
            Assert.AreEqual(9, list.IndexOf(9), string.Format(messageFormat, 9, 9));
        }

        [TestMethod]
        public void IndexatorsShouldWorkProperlyWithCorectValues()
        {
            GenericList<int> list = GenerateCollection(10, 50);

            int index = list.IndexOf(10);
            Assert.AreEqual(10, list[index]);

            index = list.IndexOf(50);
            Assert.AreEqual(50, list[index]);

            index = list.IndexOf(30);
            Assert.AreEqual(30, list[index]);

            list[11] = 1000;
            Assert.AreEqual(11, list.IndexOf(1000));
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AccessingByIndexAboveOrEqualToListCountShouldThrow()
        {
            var list = GenerateCollection(0, 10);
            int count = list.Count;

            int i = list[count];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AccessingByIndexBelowZeroShouldThrow()
        {
            var list = GenerateCollection(0, 10);

            int i = list[-1];
        }

        [TestMethod]
        public void InsertingShouldWorkProperlyWithValidIndex()
        {
            var list = new GenericList<double>(4);

            for (int i = 0; i <= 4; i++)
            {
                list.Insert(list.Count, i);
                Assert.AreEqual(i + 1, list.Count, "The list should contain one element");
                Assert.AreEqual(i, list.IndexOf(i), "Item should be inserted in the correct place");
            }

            int count = list.Count;

            double previousAtZero = list[0],
                previousLast = list[count - 1];

            list.Insert(0, 100);

            Assert.AreEqual(100, list[0], "The value should have been inserted at index 0");
            Assert.AreEqual(previousAtZero, list[1], "The previous value should be shifted at index 1");
            Assert.AreEqual(count + 1, list.Count, "The count should be increased by one");
            Assert.AreEqual(
                previousLast, list[list.Count - 1], "The last element should be at the corect place");
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void InsertingWithInvalidIndexShouldThrow()
        {
            var list = new GenericList<string>();
            list.Insert(1, "alabala");
        }

        [TestMethod]
        public void ContainsShouldWorkCorrectly()
        {
            var list = GenerateCollection(0, 10);

            Assert.IsTrue(list.Contains(10), "List should contain given number");
            Assert.IsFalse(list.Contains(int.MaxValue), "List should not contain given number");
        }

        [TestMethod]
        public void RemoveAtWithValidIndexShouldWorkCorrect()
        {
            var list = GenerateCollection(0, 10);

            string message = "The number should be removed from the list";
            string decreaseCount = "The count should have decreased";

            int count = list.Count;

            list.RemoveAt(10);
            Assert.IsFalse(list.Contains(10), message);
            Assert.AreEqual(--count, list.Count, decreaseCount);

            list.RemoveAt(5);
            Assert.IsFalse(list.Contains(5), message);
            Assert.AreEqual(--count, list.Count, decreaseCount);

            list.RemoveAt(0);
            Assert.IsFalse(list.Contains(0), message);
            Assert.AreEqual(--count, list.Count, decreaseCount);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RemoveAtWithInvalidIndexShouldThrow()
        {
            var list = new GenericList<string>();
            list.RemoveAt(2);
        }

        [TestMethod]
        public void RemoveByElementValueShouldWorkCorrectly()
        {
            var list = GenerateCollection(0, 10);
            int count = list.Count;
            bool result = list.Remove(10);

            Assert.IsTrue(result, "Method should have returned true");
            Assert.IsFalse(list.Contains(10), "List should not contain that number");
            Assert.AreEqual(--count, list.Count, "Count should have been decreased");

            result = list.Remove(int.MinValue);

            Assert.IsFalse(result, "Nothing should be removed from the list");
            Assert.AreEqual(count, list.Count, "Count should be the same");
        }

        [TestMethod]
        public void ForeachShouldWorkCorrectly()
        {
            var list = GenerateCollection(0, 10);
            int current = 0;

            foreach (var item in list)
            {
                Assert.AreEqual(
                    current,
                    item,
                    "Enumeration should be in the same order as insertion and iterate all elements");

                current++;
            }
        }

        [TestMethod]
        public void ClearShouldResetTheCountToZeroButKeepTheLastCapacity()
        {
            var list = GenerateCollection(0, 20);
            int capacity = list.Capacity;

            list.Clear();

            Assert.AreEqual(0, list.Count, "Count should be 0");
            Assert.AreEqual(capacity, list.Capacity, "Capacity should not be changed");
        }

        [TestMethod]
        public void CreatingListFromExistingCollectionShouldWorkCorrectly()
        {
            double[] collection = { 4, 3, 5, 10, 15 };
            var list = new GenericList<double>(collection);

            Assert.AreEqual(collection.Length, list.Count, "Collections should be of the same size");

            for (int i = 0; i < collection.Length; i++)
            {
                Assert.AreEqual(collection[i], list[i], "Collections should be identical");
            }
        }

        [TestMethod]
        public void ToStringShouldWorkCorrectly()
        {
            var list = GenerateCollection(1, 5);
            string expected = "Values: 1, 2, 3, 4, 5";
            string actual = list.ToString();

            Assert.AreEqual(expected, actual, "The strings must be equal");
        }

        [TestMethod]
        public void ExtensionMaxShouldWorkCorrectly()
        {
            var list = new GenericList<int>() { 1, 2, 7, 4, 10, 3, 1, 7 };
            int max = list.Max();

            Assert.AreEqual(10, max);
        }

        [TestMethod]
        public void ExtensionMinShouldWorkCorrectly()
        {
            var list = new GenericList<int>() { 1, 2, 7, 4, 10, -3, 1, 7 };
            int min = list.Min();

            Assert.AreEqual(-3, min);
        }

        [TestMethod]
        public void AssertVersionAttributeIsAssignedCorrectVersion()
        {
            var attribute = (VersionAttribute)typeof(GenericList<>)
                .GetCustomAttribute(typeof(VersionAttribute));

            Assert.AreEqual(1, attribute.Major);
            Assert.AreEqual(12, attribute.Minor);
        }

        private static GenericList<int> GenerateCollection(int from, int to)
        {
            var list = new GenericList<int>(4);
            for (int i = from; i <= to; i++)
            {
                list.Add(i);
            }

            return list;
        }
    }
}
