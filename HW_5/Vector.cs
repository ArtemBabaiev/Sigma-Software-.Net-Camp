using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_5
{
    class Vector
    {
        private int[] arr;

        #region constructors
        public Vector(int size)
        {
            arr = new int[size];
        }

        public Vector(int[] arr)
        {
            this.arr = arr;
        }
        #endregion

        #region hw_5_part
        public void HeapSort(SortOrder sortOrder = SortOrder.ASCENDING)
        {
            int size = arr.Length;
            CompareInHeap(0, size,  sortOrder);
            while (size > 0)
            {
                int temp = arr[0];
                arr[0] = arr[size - 1];
                arr[size - 1] = temp;
                size--;
                CompareInHeap(0, size,  sortOrder);
            }
            
        }

        private void CompareInHeap(int head, int heapSize, SortOrder sortOrder)
        {
            int largestIndex = head;
            int rightIndex = 2 * head + 1;
            int leftIndex = 2 * head + 2;
            //Якщо нода немає більше дочірніх елементів повертаємося
            if (rightIndex >= heapSize && leftIndex >= heapSize)
            {
                return;
            }
            //Ідемо в відносний кінець правої гілки і достаємо найбільший
            if (rightIndex < heapSize)
            {
                CompareInHeap(rightIndex, heapSize, sortOrder);
                if (sortOrder==SortOrder.ASCENDING && arr[largestIndex] < arr[rightIndex])
                {
                    largestIndex = rightIndex;
                }
                else if (sortOrder == SortOrder.DESCENDING && arr[largestIndex] > arr[rightIndex])
                {
                    largestIndex = rightIndex;
                }
            }
            //Ідемо в відносний лівий кінець гілки і достаємо найбільший
            if (leftIndex < heapSize)
            {
                CompareInHeap(leftIndex, heapSize, sortOrder);
                if (sortOrder == SortOrder.ASCENDING && arr[largestIndex] < arr[leftIndex])
                {
                    largestIndex = leftIndex;
                }
                if (sortOrder == SortOrder.DESCENDING && arr[largestIndex] > arr[leftIndex])
                {
                    largestIndex = leftIndex;
                }
            }
            
            if (largestIndex != head)
            {
                //Ставимо найбільший на місце головної ноди
                int temp = arr[head];
                arr[head] = arr[largestIndex];
                arr[largestIndex] = temp;
            }
        }

        #endregion

        #region hw_4_part
        /*
         Домашнє завдання №4:  
        В класі вектор реалізуваті швідке сортування. 
        Вибрати опорний елемент: як середній елемент масиву, перший та останній. 
        Всі варіанти методів реалізувати. 
         */
        public void QuickSort(Pivot pivot)
        {
            List<int> arrToSort = new List<int>(arr);
            switch (pivot)
            {
                case Pivot.START:
                    QuickSortStart(arr, 0, arr.Length - 1);
                    break;
                case Pivot.MIDDLE:
                    QuickSortMiddle(arr, 0, arr.Length - 1);
                    break;
                case Pivot.END:
                    QuickSortEnd(arr, 0, arr.Length - 1);
                    break;
                default:
                    break;
            }
        }

        private static void QuickSortEnd(int[] arr, int startIndex, int endIndex)
        {
            if (startIndex < endIndex)
            {
                int divIndex = ForQuick(arr, startIndex, endIndex);           //знаходження індексу опорного значення
                QuickSortEnd(arr, startIndex, divIndex - 1);                //Опорне значення на своєму місці
                QuickSortEnd(arr, divIndex + 1, endIndex);
            }

            static int ForQuick(int[] arr, int start, int pivotIndex)
            {
                int pivot = arr[pivotIndex];        //опорний останній
                int endOfLeftPart = (start - 1);
                int temp;

                for (int i = start; i <= pivotIndex - 1; i++)       //ідемо по всіх елементах крім опорного
                {
                    if (arr[i] < pivot)
                    {
                        endOfLeftPart++;                             //збільшуємо кінцевий індекс лівої частини та міняємо поточне значення з елементом
                        temp = arr[endOfLeftPart];
                        arr[endOfLeftPart] = arr[i];
                        arr[i] = temp;
                    }
                }
                temp = arr[endOfLeftPart + 1];               //вставляємо опорний між менших та більших
                arr[endOfLeftPart + 1] = arr[pivotIndex];
                arr[pivotIndex] = temp;
                return (endOfLeftPart + 1);
            }
        }

        private static void QuickSortStart(int[] arr, int startIndex, int endIndex)
        {
            if (startIndex < endIndex)
            {
                int divIndex = ForQuick(arr, startIndex, endIndex);
                QuickSortStart(arr, startIndex, divIndex - 1);
                QuickSortStart(arr, divIndex + 1, endIndex);
            }

            static int ForQuick(int[] arr, int pivotIndex, int end)
            {
                int pivot = arr[pivotIndex];
                int endOfRightPart = (end + 1);
                int temp;

                for (int i = end; i > pivotIndex; i--)
                {
                    if (arr[i] > pivot)
                    {
                        endOfRightPart--;
                        temp = arr[endOfRightPart];
                        arr[endOfRightPart] = arr[i];
                        arr[i] = temp;
                    }
                }
                temp = arr[endOfRightPart - 1];
                arr[endOfRightPart - 1] = arr[pivotIndex];
                arr[pivotIndex] = temp;
                return (endOfRightPart - 1);
            }
        }

        private static void QuickSortMiddle(int[] arr, int startIndex, int endIndex)
        {
            int pivot = arr[(startIndex + (endIndex - startIndex) / 2)];
            int leftPartExecption = startIndex;
            int rightPartExecption = endIndex;
            while (leftPartExecption <= rightPartExecption)
            {
                while (arr[leftPartExecption] < pivot)
                {
                    leftPartExecption++;
                }
                while (arr[rightPartExecption] > pivot)
                {
                    rightPartExecption--;
                }
                if (leftPartExecption <= rightPartExecption)
                {
                    int temp = arr[leftPartExecption];
                    arr[leftPartExecption] = arr[rightPartExecption];
                    arr[rightPartExecption] = temp;
                    leftPartExecption++;
                    rightPartExecption--;
                }
            }
            if (startIndex < rightPartExecption)
            {
                QuickSortMiddle(arr, startIndex, leftPartExecption - 1);
            }
            if (endIndex > leftPartExecption)
            {
                QuickSortMiddle(arr, rightPartExecption + 1, endIndex);
            }
        }

        #endregion

        #region hw_3_part
        public bool IsPalindrom()
        {
            int half = arr.Length / 2;

            for (int i = 0, j = arr.Length - 1; i < half; i++, j--)
            {
                if (arr[i] != arr[j])
                {
                    return false;
                }
            }
            return true;
        }

        public void StandartReverse()
        {
            Array.Reverse(arr);
        }

        public void MyReverse()
        {
            for (int i = 0, j = arr.Length - 1; i < arr.Length / 2; i++, j--)
            {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }


        public int[] LongestSubSequence()
        {

            int startOfLongestSequence = 0;
            int endOfLongestSequence = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int start = i;
                int end = i + 1;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        end = j + 1;
                    }
                    else
                    {
                        break;
                    }
                }
                if (endOfLongestSequence - startOfLongestSequence < end - start)
                {
                    startOfLongestSequence = start;
                    endOfLongestSequence = end;
                }
            }
            return arr[startOfLongestSequence..endOfLongestSequence];
        }

        public void ShuffleInitialization()
        {
            Random rnd = new Random();
            List<int> lst = new List<int>();
            for (int i = 1; i <= arr.Length; i++)
            {
                lst.Add(i);
            }
            for (int i = 0; i < arr.Length; i++)
            {
                int index = rnd.Next(0, lst.Count);
                arr[i] = lst[index];
                lst.RemoveAt(index);
            }



            /*for (int i = 0; i < arr.Length; i++)
            {
                while (arr[i]==0)
                {
                    int number = rand.Next(1, arr.Length + 1);
                    for (int j = 0; j < i; j++)
                    {
                        if (arr[j] == number)
                        {
                            number = 0;
                            break;
                        }
                    }
                    arr[i] = number;
                }*/


        }


        #endregion


        #region made on lesson
        public void RandomInitialization(int a, int b)
        {
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(a, b);

            }
        }

        public Pair[] CalculateFrequency()
        {
            Pair[] pairs = new Pair[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                pairs[i] = new Pair(0, 0);
            }

            int countDiff = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                bool isElement = false;
                for (int j = 0; j < countDiff; j++)
                {
                    if (arr[i] == pairs[j].Number)
                    {
                        pairs[j].Frequency++;
                        isElement = true;
                        break;
                    }
                }
                if (!isElement)
                {
                    pairs[countDiff].Number = arr[i];
                    pairs[countDiff].Frequency++;
                    countDiff++;
                }
            }

            Pair[] result = new Pair[countDiff];
            for (int i = 0; i < countDiff; i++)
            {
                result[i] = pairs[i];
            }
            return result;
        }

        public void CountingSort()
        {
            int max = arr[0];
            int min = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }
            int[] temp = new int[max - min + 1];
            for (int i = 0; i < arr.Length; i++)
            {
                temp[arr[i] - min]++;
            }
            int k = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                for (int j = 0; j < temp[i]; j++)
                {
                    arr[k] = i + min;
                    k++;
                }
            }
        }

        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < arr.Length)
                {
                    return arr[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                arr[index] = value;
            }
        }

        public void Merge(int left, int q, int right)
        {
            int i = left;
            int j = q;
            int[] temp = new int[right - left];
            int k = 0; //runs on temp
            while (i < q && j < right)
            {
                if (arr[i] < arr[j])
                {
                    temp[k] = arr[i];
                    i++;
                }
                else
                {
                    temp[k] = arr[j];
                    j++;
                }
                k++;
            }
            if (i == q)
            {
                for (int m = j; m < right; m++)
                {
                    temp[k] = arr[m];
                    k++;
                }
            }
            else
            {
                while (i < q)
                {
                    temp[k] = arr[i];
                    i++;
                    k++;
                }
            }
            for (int n = 0; n < temp.Length; n++)
            {
                arr[n + left] = temp[n];
            }
        }

        public void SplitMergeSort()
        {
            SplitMergeSort(0, arr.Length);
        }

        private void SplitMergeSort(int start, int end)
        {
            if (end - start <= 1)
            {
                return;
            }
            int middle = (start + end) / 2;
            SplitMergeSort(start, middle);
            SplitMergeSort(middle, end);
            Merge(start, middle, end);






        }

        public void ReadFromFile(String fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            reader.ReadLine();
            reader.Close();
        }

        #endregion






        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < arr.Length; i++)
            {
                result += arr[i];
                if (i < arr.Length - 1)
                {
                    result += ", ";
                }
            }
            return result;
        }
    }


}
