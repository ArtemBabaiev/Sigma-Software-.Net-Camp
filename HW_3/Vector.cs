using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_3
{
    class Vector
    {
        private int[] arr;

        public Vector(int size)
        {
            arr = new int[size];
        }

        public Vector(int[] arr)
        {
            this.arr = arr;
        }

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



        public void RandomInitialization(int a, int b)
        {
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(a, b);

            }
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

        public int this[int index]
        {
            get
            {
                if (index >= 0 && index<arr.Length)
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
