using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_1_and_2
{
    class MatrixFill
    {
        public static void PerformFill()
        {
            Console.Write("Input number of rows: ");
            int rows = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input number of columns: ");
            int columns = Convert.ToInt32(Console.ReadLine());
            if (rows == columns)
            {
                DiagonalFill(rows);
            }
            else
            {
                Console.Write("Spiral(1) or Reverse(2): ");
                switch (Console.ReadLine())
                {
                    case "1":
                        SnakeFill(rows, columns);
                        break;
                    case "2":
                        SpiralFill(rows, columns);
                        break;
                }

            }

        }
        private static void SnakeFill(int rows, int columns)
        {
            int[,] arr = new int[rows, columns];
            int k = 0;
            int val = 1;
            while (k < columns)
            {
                for (int i = 0; i < rows; i++)
                {
                    arr[i, k] = val;
                    val++;
                }
                k++;
                for (int i = rows - 1; i >= 0; i--)
                {
                    arr[i, k] = val;
                    val++;
                }
                k++;
            }
            PrintMatrix(arr, rows, columns);

        }

        private static void DiagonalFill(int size)
        {
            int[,] arr = new int[size, size];
            int val = 1;
            int startR = 0;
            int startC = 0;
            int diagonal = 0;
            int index = 0;

            while (index <= 2 * size - 1)
            {
                if (index < size)
                {
                    startC = diagonal;
                    startR = 0;
                    for (int i = 0; i <= diagonal; i++)
                    {
                        arr[startR, startC] = val;
                        val++;
                        startR++;
                        startC--;
                    }
                    diagonal++;
                }
                else if (index == size)
                {
                    diagonal--;
                }
                else
                {
                    startC = size - 1;
                    startR = size - diagonal;
                    for (int i = 0; i < diagonal; i++)
                    {
                        arr[startR, startC] = val;
                        val++;
                        startR++;
                        startC--;
                    }
                    diagonal--;
                }
                index++;

            }
            PrintMatrix(arr, size, size);
        }

        private static void SpiralFill(int rows, int columns)
        {
            int[,] arr = new int[rows, columns];
            int val = 1;
            int startRow = 0;
            int startColumn = 0;
            int finishColumn = columns;
            int finishRow = rows;

            while (startRow < finishRow && startColumn < finishColumn)
            {
                //left
                for (int i = startRow; i < finishRow; i++)
                {
                    arr[i, startRow] = val;
                    val++;
                }
                startRow++;
                //down
                for (int i = startColumn + 1; i < finishColumn; i++)
                {
                    arr[finishRow - 1, i] = val;
                    val++;
                }
                startColumn++;
                //right
                if (startRow < finishRow)
                {
                    for (int i = finishRow - 2; i >= startRow - 1; i--)
                    {
                        arr[i, finishColumn - 1] = val;
                        val++;
                    }
                    finishRow--;

                }
                //up
                if (startColumn < finishColumn)
                {
                    for (int i = finishColumn - 2; i >= startColumn; i--)
                    {
                        arr[startRow - 1, i] = val;
                        val++;
                    }
                    finishColumn--;
                }


            }
            PrintMatrix(arr, rows, columns);


        }

        static void PrintMatrix(int[,] arr, int rows, int columns)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
