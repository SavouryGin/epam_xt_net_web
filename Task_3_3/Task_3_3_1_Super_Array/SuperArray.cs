using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_3_3_1_Super_Array
{
    public static class SuperArray
    {
        #region 1. Process each individual element of an array

        public static IEnumerable<T> ProcessColl<T>(this IEnumerable<T> coll, Func<T, T> f)
        {
            if (coll == null || !coll.Any())
            {
                throw new ArgumentException("The passed array must contain at least one element.");
            }

            if (f == null)
            {
                throw new ArgumentNullException("You did not pass any function!");
            }

            return coll.Select(element => f(element)).ToArray();
        }

        #endregion

        #region 2. Find the sum of all elements in a collection

        public static int FindSumOfColl(this IEnumerable<int> coll)
        {
            if (coll == null || !coll.Any())
            {
                throw new ArgumentException("The passed array must contain at least one element.");
            }

            int sum = 0;

            checked
            {
                foreach (int num in coll) sum += num;
            }

            return sum;
        }

        public static double FindSumOfColl(this IEnumerable<double> coll)
        {
            if (coll == null || !coll.Any())
            {
                throw new ArgumentException("The passed array must contain at least one element.");
            }

            double sum = 0;

            checked
            {
                foreach (int num in coll) sum += num;
            }

            return sum;
        }

        public static int? FindSumOfColl(this IEnumerable<int?> coll)
        {

            if (coll == null || !coll.Any())
            {
                throw new ArgumentException("The passed array must contain at least one element.");
            }

            int sum = 0;

            checked
            {
                foreach (int? num in coll)
                {
                    if (num != null) sum += num.GetValueOrDefault();
                }
            }

            return sum;
        }

        public static double? FindSumOfColl(this IEnumerable<double?> coll)
        {

            if (coll == null || !coll.Any())
            {
                throw new ArgumentException("The passed array must contain at least one element.");
            }

            double sum = 0;

            checked
            {
                foreach (double? num in coll)
                {
                    if (num != null) sum += num.GetValueOrDefault();
                }
            }

            return sum;
        }

        #endregion

        #region 3. Find the average value in a collection

        public static double FindAverageOfColl(this IEnumerable<int> coll)
        {
            if (coll == null || !coll.Any())
            {
                throw new ArgumentException("The passed array must contain at least one element.");
            }

            long sum = 0;
            long count = 0;

            checked
            {
                foreach (int num in coll)
                {
                    sum += num;
                    count++;
                }
            }

            return (double)sum / count;
        }

        public static double FindAverageOfColl(this IEnumerable<double> coll)
        {
            if (coll == null || !coll.Any())
            {
                throw new ArgumentException("The passed array must contain at least one element.");
            }

            long sum = 0;
            long count = 0;

            checked
            {
                foreach (int num in coll)
                {
                    sum += num;
                    count++;
                }
            }

            return (double)sum / count;
        }

        public static double? FindAverageOfColl(this IEnumerable<int?> coll)
        {
            if (coll == null || !coll.Any())
            {
                throw new ArgumentException("The passed array must contain at least one element.");
            }

            long sum = 0;
            long count = 0;
            checked
            {
                foreach (int? num in coll)
                {
                    if (num != null)
                    {
                        sum += num.GetValueOrDefault();
                        count++;
                    }
                }
            }

            return (double)sum / count;
        }

        public static double? FindAverageOfColl(this IEnumerable<double?> coll)
        {
            if (coll == null || !coll.Any())
            {
                throw new ArgumentException("The passed array must contain at least one element.");
            }

            double sum = 0;
            long count = 0;
            checked
            {
                foreach (double? num in coll)
                {
                    if (num != null)
                    {
                        sum += num.GetValueOrDefault();
                        count++;
                    }
                }
            }

            return (double)sum / count;
        }

        #endregion

        #region 4. Find the most frequently repeated element in a collection
        public static T FindFrequent<T>(this IEnumerable<T> coll)
        {
            if (coll == null || !coll.Any())
            {
                throw new ArgumentException("The passed collection must contain at least one element.");
            }

            var query = (from item in coll
                         group item by item into temp 
                         orderby temp.Count() descending 
                         select temp.Key).First();

            return query;
        }

        #endregion

    }
}
