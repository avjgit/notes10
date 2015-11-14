using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ldn201511_minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\avjma_000\Documents\GitHub\notes10\codeforce\ldn201511_minesweeper\ldn201511_minesweeper\minesweeper_input.txt");
            int rows = lines.Count();
            int cols = lines[0].Count();
            Console.WriteLine($"There are {rows} rows and {cols} cols");

            char[][] output = new char[rows][];

            int i = 0;
            foreach (string line in lines)
            {
                output[i] = line.ToCharArray();
                i++;
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (output[row][col] == '.')
                    {
                        output[row][col] = CountBombsNearby(output, row, col, rows-1, cols-1).ToString()[0];
                    }
                }
            }

            ///////////////////////// printout
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(output[row][col]);
                }
                Console.WriteLine();
            }
        }

        static int CountBombsNearby(char[][]world, int row, int col, int maxRow, int maxCol)
        {
            Console.WriteLine($"Checking {row} and {col}");
            int count = 0;

            if (row > 0)
            {
                if (col > 0)
                if (world[row - 1][col - 1] == '*') count++;

                if (world[row - 1][col] == '*') count++;

                if (col < maxCol)
                if (world[row - 1][col + 1] == '*') count++;
            }

            if (col > 0)
            if (world[row][col - 1] == '*') count++;

            if (col < maxCol)
            if (world[row][col + 1] == '*') count++;

            if (row < maxRow)
            {
                if (col > 0)
                if (world[row + 1][col - 1] == '*') count++;

                if (world[row + 1][col + 0] == '*') count++;

                if (col < maxCol)
                if (world[row + 1][col + 1] == '*') count++;
            }
            return count;
        }
    }
}
