namespace P3_Generic_List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using P4_Generic_List_Version;

    [Version(1, 12)]
    public class GenericList<T> : IList<T>
    {
        public const int INITIAL_CAPACITY = 16;

        private const string INDEX_OUT_OF_RANGE = "Tried to access an invalid index: {0}";

        private T[] data;

        public GenericList(int initialCapacity = INITIAL_CAPACITY, bool isReadOnly = false)
        {
            this.data = new T[initialCapacity];
            this.IsReadOnly = isReadOnly;
            this.Count = 0;
        }

        public GenericList(
            IEnumerable<T> collection,
            int initialCapacity = INITIAL_CAPACITY,
            bool isReadOnly = false) : this(initialCapacity, isReadOnly)
        {
            foreach (var item in collection)
            {
                this.Add(item);
            }
        }

        public int Capacity
        {
            get { return this.data.Length; }
        }

        public int Count { get; private set; }

        public bool IsReadOnly { get; }

        public T this[int index]
        {
            get { return this.data[this.ValidateIndex(index)]; }

            set { this.data[this.ValidateIndex(index)] = value; }
        }

        public override string ToString()
        {
            return string.Format("Values: {0}", string.Join(", ", this));
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(T item)
        {
            this.ResizeIfNeeded();
            this.data[this.Count++] = item;
        }

        public void Clear()
        {
            this.data = new T[this.Capacity];
            this.Count = 0;
        }

        public bool Contains(T item)
        {
            return this.IndexOf(item) != -1;
        }

        /// <summary>
        /// Copies the list to the target one dimensional array starting from the targeted array index
        /// </summary>
        /// <param name="array">the target array</param>
        /// <param name="arrayIndex">index of the targeted array to insert the copies from</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array.Length - arrayIndex < this.Count)
            {
                throw new IndexOutOfRangeException(
                    "Copying the list to the given array will result in index out of range");
            }

            Array.Copy(this.data, 0, array, arrayIndex, this.Count);
        }

        public bool Remove(T item)
        {
            int index = this.IndexOf(item);
            if (index == -1)
            {
                return false;
            }

            this.RemoveAt(index);
            return true;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (item.Equals(this.data[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || this.Count < index)
            {
                throw new IndexOutOfRangeException(string.Format(INDEX_OUT_OF_RANGE, index));
            }

            this.ResizeIfNeeded();
            this.Count++;

            for (int i = this.Count; i > index; i--)
            {
                this.data[i] = this.data[i - 1];
            }

            this.data[index] = item;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);

            this.data[index] = default(T);

            for (int i = index + 1; i < this.Count; i++)
            {
                this.data[i - 1] = this.data[i];
            }

            this.Count--;
        }

        private void ResizeIfNeeded()
        {
            if (this.Count + 1 == this.Capacity)
            {
                T[] newData = new T[this.Capacity * 2];
                Array.Copy(this.data, newData, this.data.Length);

                this.data = newData;
            }
        }

        private int ValidateIndex(int index)
        {
            if (index < 0 || this.Count <= index)
            {
                throw new IndexOutOfRangeException(string.Format(INDEX_OUT_OF_RANGE, index));
            }

            return index;
        }
    }
}
