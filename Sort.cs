using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    class Sort
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="isDescending"></param>
        /// <returns></returns>
        public static IEnumerable<T> SelectionSort<T>(IEnumerable<T> list, bool isDescending = false) where T : IComparable<T>
        {
            IList<T> tempList = new List<T>(list);

            for (int i = 0; i < tempList.Count - 1; i++)
            {
                int currentIndex = i;
                for (int j = i + 1; j < tempList.Count; j++)
                {
                    if ((!isDescending && tempList[j].CompareTo(tempList[currentIndex]) < 0) ||
                        (isDescending && tempList[j].CompareTo(tempList[currentIndex]) > 0))
                    {
                        currentIndex = j;
                    }
                }
                tempList.Swap(currentIndex, i);
            }

            return tempList.AsEnumerable<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="isDescending"></param>
        /// <returns></returns>
        public static IEnumerable<T> InsertionSort<T>(IEnumerable<T> list, bool isDescending = false) where T : IComparable<T>
        {
            IList<T> tempList = new List<T>(list);

            for (int i = 1; i < tempList.Count; i++)
            {
                T currentValue = tempList[i];
                int j = i - 1;
                while (j >= 0 &&
                    ((!isDescending && tempList[j].CompareTo(currentValue) > 0) ||
                    (isDescending && tempList[j].CompareTo(currentValue) < 0)))
                {
                    tempList[j + 1] = tempList[j];
                    j--;
                }

                tempList[j + 1] = currentValue;
            }

            return tempList.AsEnumerable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="isDescending"></param>
        /// <returns></returns>
        public static IEnumerable<T> BubbleSort<T>(IEnumerable<T> list, bool isDescending = false) where T : IComparable<T>
        {
            IList<T> tempList = new List<T>(list);

            for (int i = 0; i < tempList.Count - 1; i++)
            {
                for (int j = 0; j < tempList.Count - i - 1; j++)
                {
                    if ((!isDescending && tempList[j].CompareTo(tempList[j + 1]) > 0) ||
                        (isDescending && tempList[j].CompareTo(tempList[j + 1]) < 0))
                    {
                        tempList.Swap(j, j + 1);
                    }
                }

            }

            return tempList.AsEnumerable();
        }

        public static IEnumerable<T> QuickSort<T>(IEnumerable<T> list, bool isDescending = false) where T : IComparable<T>
        {
            IList<T> tempList = new List<T>(list);
            QuickSortHelper(tempList, 0, tempList.Count - 1, isDescending);
            return tempList.AsEnumerable();
        }

        private static void QuickSortHelper<T>(IList<T> list, int left, int right, bool isDescending = false) where T : IComparable<T>
        {
            if (left < right)
            {
                int pivot = Partioner(list, left, right, isDescending);

                QuickSortHelper(list, left, pivot - 1, isDescending);
                QuickSortHelper(list, pivot + 1, right, isDescending);
            }
        }

        private static int Partioner<T>(IList<T> list, int left, int right, bool isDescending) where T : IComparable<T>
        {
            T pivot = list[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if ((!isDescending && list[j].CompareTo(pivot) < 0) ||
                    (isDescending && list[j].CompareTo(pivot) > 0))
                {
                    i++;
                    list.Swap(i, j);
                }
            }
            list.Swap(i + 1, right);
            return ++i;
        }

        public static IEnumerable<T> MergeSort<T>(IEnumerable<T> list, bool isDescending = false) where T : IComparable<T>
        {
            IList<T> tempList = new List<T>(list);
            MergeSortHelper(tempList, 0, tempList.Count - 1, isDescending);
            return tempList.AsEnumerable();
        }

        private static void MergeSortHelper<T>(IList<T> list, int start, int end, bool isDescending = false) where T : IComparable<T>
        {
            if(start < end)
            {
                int middle = start + (end - start) / 2;

                MergeSortHelper(list, start, middle, isDescending);
                MergeSortHelper(list, middle + 1, end, isDescending);

                Merge(list, start, middle, end, isDescending);
            }
        }

        private static void Merge<T>(IList<T> list, int start, int middle, int end, bool isDescending) where T : IComparable<T>
        {
            T[] leftArr = new T[middle - start + 1];
            T[] rightArr = new T[end - middle];
            int leftIndex = 0, rightIndex = 0, mergeIndex = start;

            for (int i = 0; i < leftArr.Length; i++)
            {
                leftArr[i] = list[start + i];
            }

            for (int i = 0; i < rightArr.Length; i++)
            {
                rightArr[i] = list[middle + 1 + i];
            }

            while (leftIndex < leftArr.Length && rightIndex < rightArr.Length)
            {
                if ((!isDescending && leftArr[leftIndex].CompareTo(rightArr[rightIndex]) <= 0) ||
                    (isDescending && leftArr[leftIndex].CompareTo(rightArr[rightIndex]) >= 0))
                {
                    list[mergeIndex] = leftArr[leftIndex];
                    leftIndex++;
                }
                else
                {
                    list[mergeIndex] = rightArr[rightIndex];
                    rightIndex++;
                }
                mergeIndex++;


            }
            while (leftIndex < leftArr.Length)
            {
                list[mergeIndex] = leftArr[leftIndex];
                leftIndex++;
                mergeIndex++;
            }

            while (rightIndex < rightArr.Length)
            {
                list[mergeIndex] = rightArr[rightIndex];
                rightIndex++;
                mergeIndex++;
            }
        }


    }
}
