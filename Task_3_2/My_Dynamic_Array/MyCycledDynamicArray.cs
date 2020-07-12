using System.Collections.Generic;

namespace My_Dynamic_Array
{
    public class MyCycledDynamicArray<T> : MyArray<T>
    {
        public MyCycledDynamicArray() : base() { }

        public MyCycledDynamicArray(int capacity) : base(capacity) { }

        public MyCycledDynamicArray(IEnumerable<T> coll) : base(coll) { }

        public override IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; ; i = (i + 1) % Len)
            {
                yield return this[i];
            }
        }
    }
}
