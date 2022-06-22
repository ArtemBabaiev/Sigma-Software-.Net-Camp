using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_10.Task2
{
    class Matrix : IEnumerable
    {
        int[,] matrix;
        private int rows;
        private int columns;

        public int Rows { get => rows; protected set => rows = value; }
        public int Columns { get => columns; protected set => columns = value; }

        public Matrix(int rows, int columns)
        {
            matrix = new int[rows, columns];
            this.Rows = rows;
            this.Columns = columns;
        }

        #region hw 10 part

        //горизонтальна змійка
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < rows; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        yield return matrix[i, j];
                    }
                }
                else
                {
                    for (int j = columns - 1; j >= 0; j--)
                    {
                        yield return matrix[i, j];
                    }
                }

            }
        }

        //Діагональна змійка
        /*public IEnumerator GetEnumerator()
        {
            if (Rows != Columns)
            {
                throw new Exception("For diagonal fill matrix must be square size");
            }

            int yCol = 0;
            int xRow = 0;
            int val = 1;
            int diagonalNumber = 0;
            int size = Rows - 1;

            //upperHalf and mainDiagonal
            for (int i = 0; i <= size; i++)
            {
                if (i % 2 == 0)
                {

                    yCol = diagonalNumber;
                    xRow = 0;


                    for (int j = 0; j <= diagonalNumber; j++)
                    {
                        yield return matrix[xRow, yCol];
                        val++;
                        xRow += 1;
                        yCol -= 1;
                    }
                    diagonalNumber++;
                }
                else
                {

                    yCol = 0;
                    xRow = diagonalNumber;

                    for (int j = 0; j <= diagonalNumber; j++)
                    {
                        yield return matrix[xRow, yCol];
                        val++;
                        xRow -= 1;
                        yCol += 1;
                    }
                    diagonalNumber++;
                }
            }

            //lower half
            for (int i = 1; i <= size; i++)
            {
                if (diagonalNumber % 2 == 0)
                {

                    xRow = i;
                    yCol = Columns - 1;
                    for (; xRow <= Rows - 1;)
                    {
                        yield return matrix[xRow, yCol];
                        val++;
                        xRow++;
                        yCol--;
                    }
                    diagonalNumber++;

                }
                else
                {
                    xRow = Rows - 1;
                    yCol = i;
                    for (; yCol <= Columns - 1;)
                    {
                        yield return matrix[xRow, yCol];
                        val++;
                        xRow--;
                        yCol++;
                    }
                    diagonalNumber++;
                }
            }
        }*/
        #endregion

        #region fillers
        public void NormalFill()
        {
            int val = 1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = val;
                    val++;
                }
            }
        }

        public void ReverseFill()
        {
            int k = 0;
            int val = 1;
            while (k < Columns)
            {
                for (int i = 0; i < Rows; i++)
                {
                    if (k < Columns)
                    {
                        matrix[i, k] = val;
                        val++;
                    }

                }
                k++;
                for (int i = Rows - 1; i >= 0; i--)
                {
                    if (k < Columns)
                    {
                        matrix[i, k] = val;
                        val++;
                    }

                }
                k++;
            }
        }

        public void DiagonalFill(Direction dir)
        {
            if (Rows != Columns)
            {
                throw new Exception("For diagonal fill matrix must be square size");
            }


            int yCol = 0;
            int xRow = 0;
            int val = 1;
            int diagonalNumber = 0;
            int size = Rows - 1;

            //upperHalf and mainDiagonal
            for (int i = 0; i <= size; i++)
            {
                if (i % 2 == 0)
                {
                    if (dir == Direction.DOWN)
                    {
                        yCol = diagonalNumber;
                        xRow = 0;
                    }
                    else
                    {
                        yCol = 0;
                        xRow = diagonalNumber;
                    }

                    for (int j = 0; j <= diagonalNumber; j++)
                    {
                        matrix[xRow, yCol] = val;
                        val++;
                        xRow += (int)dir;
                        yCol -= (int)dir;
                    }
                    diagonalNumber++;
                }
                else
                {
                    if (dir == Direction.DOWN)
                    {
                        yCol = 0;
                        xRow = diagonalNumber;
                    }
                    else
                    {
                        yCol = diagonalNumber;
                        xRow = 0;
                    }

                    for (int j = 0; j <= diagonalNumber; j++)
                    {
                        matrix[xRow, yCol] = val;
                        val++;
                        xRow -= (int)dir;
                        yCol += (int)dir;
                    }
                    diagonalNumber++;
                }
            }

            //lower half
            for (int i = 1; i <= size; i++)
            {
                if (diagonalNumber % 2 == 0)
                {
                    if (dir == Direction.DOWN)
                    {
                        xRow = i;
                        yCol = Columns - 1;
                        for (; xRow <= Rows - 1;)
                        {
                            matrix[xRow, yCol] = val;
                            val++;
                            xRow++;
                            yCol--;
                        }
                        diagonalNumber++;
                    }

                    else
                    {
                        xRow = Rows - 1;
                        yCol = i;
                        for (; yCol <= Columns - 1;)
                        {
                            matrix[xRow, yCol] = val;
                            val++;
                            xRow--;
                            yCol++;
                        }
                        diagonalNumber++;
                    }


                }
                else
                {
                    if (dir == Direction.DOWN)
                    {
                        xRow = Rows - 1;
                        yCol = i;
                        for (; yCol <= Columns - 1;)
                        {
                            matrix[xRow, yCol] = val;
                            val++;
                            xRow--;
                            yCol++;
                        }
                        diagonalNumber++;
                    }
                    else
                    {
                        xRow = i;
                        yCol = Columns - 1;
                        for (; xRow <= Rows - 1;)
                        {
                            matrix[xRow, yCol] = val;
                            val++;
                            xRow++;
                            yCol--;
                        }
                        diagonalNumber++;
                    }


                }
            }
        }

        public void SpiralFill()
        {
            int val = 1;
            int startRow = 0;
            int startColumn = 0;
            int finishColumn = Columns;
            int finishRow = Rows;

            while (startRow < finishRow && startColumn < finishColumn)
            {
                //left column
                for (int i = startRow; i < finishRow; i++)
                {
                    matrix[i, startColumn] = val;
                    val++;
                }
                startColumn++;
                //lower row
                for (int i = startColumn; i < finishColumn; i++)
                {
                    matrix[finishRow - 1, i] = val;
                    val++;
                }
                finishRow--;
                //right column
                if (startColumn < finishColumn)
                {
                    for (int i = finishRow - 1; i >= startRow; i--)
                    {
                        matrix[i, finishColumn - 1] = val;
                        val++;
                    }
                    finishColumn--;
                }
                //upper row
                if (startRow < finishRow)
                {
                    for (int i = finishColumn - 1; i >= startColumn; i--)
                    {
                        matrix[startRow, i] = val;
                        val++;
                    }
                    startRow++;
                }
            }

        }
        #endregion

        #region methods
        public void PrintMatrix()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public void ReadMatrixFromFile(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string line = reader.ReadLine();
                string[] sizes = line.Split(" ");
                this.Rows = int.Parse(sizes[0]);
                this.Columns = int.Parse(sizes[1]);
                matrix = new int[Rows, Columns];
                for (int i = 0; i < Rows; i++)
                {
                    string[] items = reader.ReadLine().Split(" ");
                    for (int j = 0; j < Columns; j++)
                    {
                        matrix[i, j] = int.Parse(items[j]);
                    }
                }
            }
        }

        

        #endregion
    }
}
