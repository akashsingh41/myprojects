using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortClass
{
    public class Sort
    {
        #region Quick Sort

        public List<int> QuickSort(List<int> a)
        {
            List<int> left = new List<int>();
            List<int> right = new List<int>();
            Random r = new Random();
            if (a.Count <= 1)
            {
                return a;
            }
            int pos = r.Next(a.Count);
            int pivot = a[pos];
            a.RemoveAt(pos);

            foreach (int x in a)
            {
                if (x <= pivot)
                {
                    left.Add(x);
                }
                else
                {
                    right.Add(x);
                }
            }
            return concat(QuickSort(left), pivot, QuickSort(right));
        }

        public List<int> concat(List<int> left, int pivot, List<int> right)
        {
            List<int> sorted = new List<int>(left);
            sorted.Add(pivot);
            foreach (int i in right)
            {

                sorted.Add(i);
            }
            return sorted;
        }

        #endregion

        #region Insertion Sort

        public List<int> InsertionSort(List<int> ar)
        {
            int i, j;

            for (i = 1; i < ar.Count; i++)
            {
                j = i;
                while (j > 0)
                {
                    if (ar[j - 1] > ar[j])
                    {
                        int temp;
                        temp = ar[j - 1];
                        ar[j - 1] = ar[j];
                        ar[j] = temp;
                        j--;
                    }
                    else
                        break;
                }
            }
                return ar;
            }

        #endregion

        #region Selection Sort
        public List<int> SelectionSort(List<int> ar)
        {
            int i, j, min, temp;
            for (i = 0; i < ar.Count; i++)
            {
                min = i;
                for (j = i + 1; j < ar.Count; j++)
                {
                    if (ar[j] < ar[min])
                    {
                        min = j;
                        temp = ar[i];
                        ar[i] = ar[min];
                        ar[min] = temp;
                    }
                }
            }
            return ar;
        }
        #endregion

        #region Bubble Sort

        public List<int> BubbleSort(List<int> ar)
        {
            int i, j, temp;
            for (i = 1; i < ar.Count; i++)
            {
                for (j = 0; j < ar.Count - 1; j++)
                {
                    if (ar[j] > ar[j + 1])
                    {
                        temp = ar[j + 1];
                        ar[j + 1] = ar[j];
                        ar[j] = temp;
                    }
                }
            }

            return ar;

        }

        #endregion

        #region Merge Sort
        public List<int> MergeSort(List<int> array)
        {
            if (array.Count <= 1)
                return array;
            int mid = array.Count / 2;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            for (int i = 0; i < mid; i++)
                left.Add(array[i]);
            for (int i = mid; i < array.Count; i++)
                right.Add(array[i]);
            return Merge(MergeSort(left),MergeSort(right));
        }
        private List<int> Merge(List<int> leftpart,List<int> rightpart)
        {
            List<int> mergedList=new List<int>();

            while (leftpart.Count > 0 && rightpart.Count > 0)
            {
                if (leftpart[0] <= rightpart[0])
                {
                    mergedList.Add(leftpart[0]);
                    leftpart.RemoveAt(0);
                }
                else
                {
                    mergedList.Add(rightpart[0]);
                    rightpart.RemoveAt(0);
                }
            }
                for (int i = 0; i < leftpart.Count; i++)
                    mergedList.Add(leftpart[i]);
                
                for (int i = 0; i < rightpart.Count; i++)
                    mergedList.Add(rightpart[i]);

            return mergedList;

        }

        #endregion

        #region Heap Sort
        public List<int> HeapSort(List<int> a)
        {

            int i, temp;
            int heapSize = a.Count;
            for (i = (heapSize-1)/2; i >= 0; i--)
                Heapify(a, heapSize, i);
            
            for (i = a.Count-1; i >0; i--)
                {
                temp = a[i];
                a[i] = a[0];
                a[0] = temp;

                heapSize--;
                Heapify(a, heapSize, 0);
                }
            return a;
        }
        private void Heapify(List<int> input, int heapSize, int index)
        {
            int left = (index + 1) * 2 - 1;
            int right = (index + 1) * 2;
            int largest = 0;

            if (left < heapSize && input[left] > input[index])
                largest = left;
            else
                largest = index;

            if (right < heapSize && input[right] > input[largest])
                largest = right;

            if (largest != index)
            {
                int temp = input[index];
                input[index] = input[largest];
                input[largest] = temp;

                Heapify(input, heapSize, largest);
            }
        }

        #endregion
    }
}
