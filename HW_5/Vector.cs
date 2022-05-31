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

        public int[] Arr { get => arr; private set => arr = value; }

        #region constructors
        public Vector(int size)
        {
            Arr = new int[size];
        }

        public Vector(IEnumerable<int> arr)
        {
            this.Arr = arr.ToArray();
        }
        #endregion

        #region hw_5_part
        public void HeapSort(SortOrder sortOrder = SortOrder.ASCENDING)
        {
            int size = Arr.Length;
            CompareInHeap(0, size, sortOrder);
            while (size > 0)
            {
                int temp = Arr[0];
                Arr[0] = Arr[size - 1];
                Arr[size - 1] = temp;
                size--;
                CompareInHeap(0, size, sortOrder);
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
                if (sortOrder == SortOrder.ASCENDING && Arr[largestIndex] < Arr[rightIndex])
                {
                    largestIndex = rightIndex;
                }
                else if (sortOrder == SortOrder.DESCENDING && Arr[largestIndex] > Arr[rightIndex])
                {
                    largestIndex = rightIndex;
                }
            }
            //Ідемо в відносний лівий кінець гілки і достаємо найбільший
            if (leftIndex < heapSize)
            {
                CompareInHeap(leftIndex, heapSize, sortOrder);
                if (sortOrder == SortOrder.ASCENDING && Arr[largestIndex] < Arr[leftIndex])
                {
                    largestIndex = leftIndex;
                }
                if (sortOrder == SortOrder.DESCENDING && Arr[largestIndex] > Arr[leftIndex])
                {
                    largestIndex = leftIndex;
                }
            }

            if (largestIndex != head)
            {
                //Ставимо найбільший на місце головної ноди
                int temp = Arr[head];
                Arr[head] = Arr[largestIndex];
                Arr[largestIndex] = temp;
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
            List<int> arrToSort = new List<int>(Arr);
            switch (pivot)
            {
                case Pivot.START:
                    QuickSortStart(Arr, 0, Arr.Length - 1);
                    break;
                case Pivot.MIDDLE:
                    QuickSortMiddle(Arr, 0, Arr.Length - 1);
                    break;
                case Pivot.END:
                    QuickSortEnd(Arr, 0, Arr.Length - 1);
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
            int half = Arr.Length / 2;

            for (int i = 0, j = Arr.Length - 1; i < half; i++, j--)
            {
                if (Arr[i] != Arr[j])
                {
                    return false;
                }
            }
            return true;
        }

        public void StandartReverse()
        {
            Array.Reverse(Arr);
        }

        public void MyReverse()
        {
            for (int i = 0, j = Arr.Length - 1; i < Arr.Length / 2; i++, j--)
            {
                int temp = Arr[i];
                Arr[i] = Arr[j];
                Arr[j] = temp;
            }
        }


        public int[] LongestSubSequence()
        {

            int startOfLongestSequence = 0;
            int endOfLongestSequence = 0;
            for (int i = 0; i < Arr.Length; i++)
            {
                int start = i;
                int end = i + 1;
                for (int j = i + 1; j < Arr.Length; j++)
                {
                    if (Arr[i] == Arr[j])
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
            return Arr[startOfLongestSequence..endOfLongestSequence];
        }

        public void ShuffleInitialization()
        {
            Random rnd = new Random();
            List<int> lst = new List<int>();
            for (int i = 1; i <= Arr.Length; i++)
            {
                lst.Add(i);
            }
            for (int i = 0; i < Arr.Length; i++)
            {
                int index = rnd.Next(0, lst.Count);
                Arr[i] = lst[index];
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
            for (int i = 0; i < Arr.Length; i++)
            {
                Arr[i] = rand.Next(a, b);

            }
        }

        public Pair[] CalculateFrequency()
        {
            Pair[] pairs = new Pair[Arr.Length];

            for (int i = 0; i < Arr.Length; i++)
            {
                pairs[i] = new Pair(0, 0);
            }

            int countDiff = 0;

            for (int i = 0; i < Arr.Length; i++)
            {
                bool isElement = false;
                for (int j = 0; j < countDiff; j++)
                {
                    if (Arr[i] == pairs[j].Number)
                    {
                        pairs[j].Frequency++;
                        isElement = true;
                        break;
                    }
                }
                if (!isElement)
                {
                    pairs[countDiff].Number = Arr[i];
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
            int max = Arr[0];
            int min = Arr[0];
            for (int i = 0; i < Arr.Length; i++)
            {
                if (Arr[i] > max)
                {
                    max = Arr[i];
                }
                if (Arr[i] < min)
                {
                    min = Arr[i];
                }
            }
            int[] temp = new int[max - min + 1];
            for (int i = 0; i < Arr.Length; i++)
            {
                temp[Arr[i] - min]++;
            }
            int k = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                for (int j = 0; j < temp[i]; j++)
                {
                    Arr[k] = i + min;
                    k++;
                }
            }
        }

        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < Arr.Length)
                {
                    return Arr[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                Arr[index] = value;
            }
        }

        public void SplitMergeSort()
        {
            SplitMergeSort(0, Arr.Length);
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

        public void Merge(int left, int q, int right)
        {
            int i = left;
            int j = q;
            int[] temp = new int[right - left];
            int k = 0; //runs on temp
            while (i < q && j < right)
            {
                if (Arr[i] < Arr[j])
                {
                    temp[k] = Arr[i];
                    i++;
                }
                else
                {
                    temp[k] = Arr[j];
                    j++;
                }
                k++;
            }
            if (i == q)
            {
                for (int m = j; m < right; m++)
                {
                    temp[k] = Arr[m];
                    k++;
                }
            }
            else
            {
                while (i < q)
                {
                    temp[k] = Arr[i];
                    i++;
                    k++;
                }
            }
            for (int n = 0; n < temp.Length; n++)
            {
                Arr[n + left] = temp[n];
            }
        }



        #endregion

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < Arr.Length; i++)
            {
                result += Arr[i];
                if (i < Arr.Length - 1)
                {
                    result += ", ";
                }
            }
            return result;
        }
    }


}