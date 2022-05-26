using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_3
{
    class Matrix
    {
        int[,] matrix;
        private int rows;
        private int columns;

        public Matrix(int rows, int columns)
        {
            matrix = new int[rows, columns];
            this.rows = rows;
            this.columns = columns;
        }

        public void ReverseFill()
        {
            int k = 0;
            int val = 1;
            while (k < columns)
            {
                for (int i = 0; i < rows; i++)
                {
                    if (k<columns)
                    {
                        matrix[i, k] = val;
                        val++;
                    }
                    
                }
                k++;
                for (int i = rows - 1; i >= 0; i--)
                {
                    if (k < columns)
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
            if (rows != columns)
            {
                throw new Exception("For diagonal fill matrix must be square size");
            }


            int yCol = 0;
            int xRow = 0;
            int val = 1;
            int diagonalNumber = 0;
            int size = rows - 1;

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
                        xRow+=(int)dir;
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
                        yCol = columns - 1;
                        for (; xRow <= rows - 1;)
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
                        xRow = rows - 1;
                        yCol = i;
                        for (; yCol <= columns - 1;)
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
                        xRow = rows - 1;
                        yCol = i;
                        for (; yCol <= columns - 1;)
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
                        yCol = columns - 1;
                        for (; xRow <= rows - 1;)
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
            int finishColumn = columns;
            int finishRow = rows;

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
                    matrix[finishRow-1, i] = val;
                    val++;
                }
                finishRow--;
                //right column
                if (startColumn<finishColumn)
                {
                    for (int i = finishRow-1; i >= startRow; i--)
                    {
                        matrix[i, finishColumn-1] = val;
                        val++;
                    }
                    finishColumn--;
                }
                //upper row
                if (startRow<finishRow)
                {
                    for (int i = finishColumn-1; i >= startColumn; i--)
                    {
                        matrix[startRow, i] = val;
                        val++;
                    }
                    startRow++;
                }
            }

        }

        public void PrintMatrix()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
