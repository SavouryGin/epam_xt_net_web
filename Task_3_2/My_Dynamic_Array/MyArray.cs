using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace My_Dynamic_Array
{
    public class MyArray<T> : ICloneable, IEnumerable, IEnumerable<T>, ICollection<T>
    {

        // === Field ===
        private T[] innerArray;        

        // === Constructors === 
        public MyArray(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException("The capacity of a dynamic array cannot be less than zero.");
            }
            else
            {
                innerArray = new T[capacity];
                Len = 0;
            }
        }

        public MyArray() : this(8) { }

        public MyArray(IEnumerable<T> coll)
        {
            innerArray = new T[coll.Count()];
            Len = 0;

            foreach (var item in coll)
            {
                innerArray[Len] = item;
                Len++;
            }
        }

        // === Properties ===
        public int Len { get; private set; }        // Getting the number of array elements

        public int Capacity                        // Getting the capacity of the internal array
        {
            get { return innerArray.Length; }

            set                                    // Change the value of capacity manually
            {
                if (value < 0)
                {
                    throw new ArgumentException("The capacity of a dynamic array cannot be less than zero.");
                }
                else if (value == innerArray.Length)
                {
                    return;
                }
                else if (value > Len)
                {
                    T[] newArray = new T[value];
                    int newAmount = Math.Min(Len, value);

                    for (int i = 0; i < newAmount; i++)
                    {
                        newArray[i] = innerArray[i];
                    }

                    innerArray = newArray;
                    Len = newAmount;
                }
            }
        }

        // === Generic methods ===
        public void Add(T item)
        {
            if (Len + 1 >= Capacity)
            {
                int newCapacity = Capacity * 2;       // Double the capacity
                T[] tempArray = new T[newCapacity];

                innerArray.CopyTo(tempArray, 0);
                innerArray = tempArray;
            }
            
            innerArray[Len] = item;
            Len++;
        }

        public void AddRange(IEnumerable<T> coll)
        {
            if (!coll.Any() || coll == null)            // Check for an empty collection
            {
                throw new ArgumentException("You have provided an empty collection.");
            }
            
            if (Len + coll.Count() >= Capacity)         // Double capacity if necessary
            {
                int newCapacity = Capacity * 2 + coll.Count();
                T[] tempArray = new T[newCapacity];

                innerArray.CopyTo(tempArray, 0);
                innerArray = tempArray;
            }

            int pos = Len;
            foreach (var item in coll)
            {
                innerArray[pos] = item;
                pos++;
                Len++;
            }
        }

        public bool Remove(T itemToRemove)
        {
            for (int i = 0; i < Len; i++)
            {
                if (Equals(itemToRemove, innerArray[i]))
                {
                    for (int j = i; j < Len - 1; j++)
                    {
                        innerArray[j] = innerArray[j + 1];
                    }

                    innerArray[Len - 1] = default;
                    Len--;
                    return true;
                }
            }

            return false;
        }

        public bool Insert(int index, T item)
        {
            if (index < 0 || index > Len)
            {
                throw new ArgumentOutOfRangeException("The entered index exceeds the bounds of the array.");
            }
                
            if (Len == Capacity)                           // Double capacity if necessary
            {
                int newCapacity = Capacity * 2;
                T[] tempArray = new T[newCapacity];

                innerArray.CopyTo(tempArray, 0);
                innerArray = tempArray;
            }

            for (int i = Len - 1; i > index; i--)
                innerArray[i] = innerArray[i - 1];

            innerArray[index] = item;
            Len++;

            return true;
        }

        public T[] ToArray()
        {
            T[] res = new T[Len];

            for (int i = 0; i < Len; i++)
                res[i] = innerArray[i];

            return res;
        }

        public override string ToString() => string.Join(", ", this.ToArray());

        // === ICloneable realization ===
        public object Clone()
        {
            T[] tempArray = new T[Capacity];

            for (int i = 0; i < Len; i++)
            {
                tempArray[i] = this[i];
            }

            return new MyArray<T>(tempArray);
        }

        // === IEmumerable, IEnumerable<T> realization ===
        public virtual IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Len; i++)
            {
                yield return innerArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        // === ICollection<T> realisation ===
        public void Clear()
        {
            innerArray = new T[8];
            Len = 0;
        }

        public bool IsReadOnly => false;

        public int Count => Len;

        public bool Contains(T toCompare)
        {
            foreach (T item in this)
            {
                if (Equals(toCompare, item))
                {
                    return true;
                }
            }

            return false;
        }  

        public void CopyTo(T[] targetArray, int idx)
        {
            if (targetArray == null)
                throw new ArgumentException("You have provided an empty collection.");

            if (idx < 0 || Count + idx > targetArray.Length)
                throw new ArgumentOutOfRangeException("The entered index exceeds the bounds of the array.");

            for (int i = 0; i < Len; i++)
            {
                targetArray[i + idx] = innerArray[i];
            }

        }

        // === Indexer ===
        public T this[int index]
        {
            get     // Access to elements from the end when using a negative index
            {
                if (index >= -Len && index <= Len - 1)
                {
                    return innerArray[(index + Len) % Len];
                } 
                else
                {
                    throw new ArgumentOutOfRangeException("The index you entered exceeds the bounds of the array.");
                }                   
            }

            set
            {
                if (index >= -Len && index <= Len - 1)
                {
                    innerArray[(index + Len) % Len] = value;
                }                    
                else
                {
                    throw new ArgumentOutOfRangeException("The index you entered exceeds the bounds of the array.");
                }                    
            }
        }
    }
}
