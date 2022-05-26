using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4
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

        #region lesson
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
            for (int i = 0, j = arr.Length - 1; i < arr.Length/2; i++, j--)
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
                        end = j+1;
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
                int index = rnd.Next(0,lst.Count);
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
                    QuickSortStart(arr, 0, arr.Length -1);
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
