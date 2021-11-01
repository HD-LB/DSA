using System;
using System.Linq;

namespace DoggePlus
{
    class DoggePlusMain
    {


        static void Main()
        {
            var strs = Console.ReadLine().Split(' ');
            int rows = int.Parse(strs[0]);
            int cols = int.Parse(strs[1]);
            int k = int.Parse(strs[2]);

            var table = new long[rows + 1, cols + 1, k + 1];
            var enemies = new bool[rows, cols];

            var coordinates = Console.ReadLine()
                .Split("; ".ToCharArray())
                .Select(int.Parse)
                .ToArray();

            //Dymanic Solution
            table[0, 0, k] = 1;

            for (int i = 0; i < coordinates.Length; i += 2)
            {
                enemies[coordinates[i], coordinates[i + 1]] = true;
            }

            for (int t = k; t >= 0; --t)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (enemies[i, j])
                        {
                            continue;
                        }

                        table[i, j + 1, t] += table[i, j, t];
                        table[i, j + 1, t] += table[i, j, t];

                        if (t > 0)
                        {
                            if (i > 0)
                            {
                                table[i - 1, j, t - 1] += table[i, j, t];
                            }

                            if (j > 0)
                            {
                                table[i, j - 1, t - 1] += table[i, j, t];
                            }
                        }
                    }
                }
            }

            long total = 0;
            for (int i = 0; i <= k; i++)
            {
                total += table[rows - 1, cols - 1, i];
            }
            Console.WriteLine(total);
        }

        ////Recursion Solution
        //static long Recursion(long[,] table, int row, int col)
        //{
        //    if (row >= table.GetLength(0))
        //    {
        //        return 0; 
        //    }

        //    if (col >= table.GetLength(1))
        //    {
        //        return 0;
        //    }

        //    if (table[row, col] < 0 )
        //    {
        //        return 0;
        //    }

        //    if (table.GetLength(0) - 1 == row && table.GetLength(1) - 1 == col)
        //    {
        //        return 1;
        //    }

        //    if (table[row, col] == 0)
        //    {
        //        table[row, col] = Recursion(table, row + 1, col) + Recursion(table, row, col + 1);
        //    }           
        //    return table[row, col];
        //}
    }
}
