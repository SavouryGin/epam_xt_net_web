using System;
using System.Linq;
using System.Text;

namespace Task_2_1_1_Custom_String_Library
{
    public class MyString
    {
        // Field
        private char[] charArray;

        // Constructors
        public MyString()
        {
            charArray = new char[] { };
        }

        public MyString(char[] someCharArray)
        {
            charArray = someCharArray;
        }

        public MyString(char someChar)
        {
            charArray = new char[] { someChar };
        }

        public MyString(string someString)
        {
            charArray = someString.ToCharArray();
        }

        public MyString(StringBuilder someBuilderString)
        {
            charArray = someBuilderString.ToString().ToCharArray();
        }

        // Property
        public int Length => charArray.Length;

        // Conversion methods
        public override string ToString()
        {
            return string.Join("", charArray);
        }

        public char[] ToArray()
        {
            return charArray;
        }

        public StringBuilder ToStringBuilder()
        {
            return new StringBuilder(string.Join("", charArray));
        }

        // Comparison methods
        public static bool operator ==(MyString input, string toCompare)
        {
            return input.ToString().Equals(toCompare) ? true : false;
        }

        public static bool operator !=(MyString input, string toCompare)
        {
            return input.ToString().Equals(toCompare) ? false : true;
        }

        public static bool operator ==(MyString input1, MyString input2)
        {
            return input1.Equals(input2) ? true : false;
        }

        public static bool operator !=(MyString input1, MyString input2)
        {
            return input1.Equals(input2) ? false : true;
        }

        public override int GetHashCode() => charArray.GetHashCode();

        public override bool Equals(Object obj)
        {
            return (this.GetHashCode() == obj.GetHashCode()) ? true : false;
        }

        // Concatenation methods
        public MyString Concat(string str)
        {
            return new MyString(string.Join("", charArray) + str);
        }

        public MyString Concat(char[] otherCharArray)
        {
            return new MyString(string.Join("", charArray) + string.Join("", otherCharArray));
        }

        public MyString Concat(MyString myOtherString)
        {
            return new MyString(string.Join("", charArray.Concat(myOtherString.charArray)));
        }

        public static MyString operator +(MyString input, string addition)
        {
            return input.Concat(addition);
        }

        public static MyString operator +(MyString input1, MyString input2)
        {
            return input1.Concat(input2);
        }

        public static MyString operator +(MyString input, int num)
        {
            return input.Concat(num.ToString());
        }

        public static MyString operator +(MyString input, double num)
        {
            return input.Concat(num.ToString());
        }

        // Search methods
        public int FindSymbol(char input)
        {
            for (int i = 0; i < Length; i++)
            {
                if (this[i] == input)
                {
                    return i;
                }
            }
            return -1;
        }

        // Knuth–Morris–Pratt algorithm
        public int FindSubstring(string pattern)
        {

            int[] pf = new int[pattern.Length];
            pf[0] = 0;
            int idx = 0;

            for (int i = 1; i < pattern.Length; i++)
            {
                while (idx >= 0 && pattern[idx] != pattern[i]) { idx--; }
                idx++;
                pf[i] = idx;
            }

            int res = -1;
            idx = 0;

            for (int i = 0; i < Length; i++)
            {
                while (idx > 0 && pattern[idx] != this[i]) { idx = pf[idx - 1]; }
                if (pattern[idx] == this[i]) idx++;
                if (idx == pattern.Length)
                {
                    return res = i - idx + 1;
                }
            }
            return res;
        }

        // Multiplication method
        public static MyString operator *(MyString input, int num)
        {
            StringBuilder temp = new StringBuilder(input.ToString());
            StringBuilder res = new StringBuilder();
            for (int i = 0; i < num; i++)
            {
                res.Append(temp);
            }
            return new MyString(res);
        }

        // Slice method
        public MyString Slice(int i, int j)
        {
            if (i > j || i < 0 || j < 0)
            {
                return new MyString();
            }
            else if (i > Length || j > Length)
            {
                return new MyString(ToString());
            }
            else if (i == j)
            {
                return new MyString(this[i]);
            }
            else
            {
                StringBuilder res = new StringBuilder();
                for (int k = i; k < j; k++)
                {
                    res.Append(this[k]);
                }
                return new MyString(res);
            }
        }

        // Indexer
        public char this[int index]
        {
            get => charArray[index];
            set => charArray[index] = value;
        }
    }
}
