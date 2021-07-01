using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public static class Extensions
    {
        public static void Swap<T>(this IList<T> list, int i, int j)
        {
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        public static void Print<T>(this IEnumerable<T> list)
        {
            foreach(T item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
