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
            var cells = new CellInputReader().ReadCells(@"C:\Users\avjma_000\Documents\GitHub\notes10\codeforce\ldn201511_minesweeper\ldn201511_minesweeper\minesweeper_input.txt");

            var world = new GameField(cells);
            Console.WriteLine("ok");
            ///////////////////////// printout
                       

            //for (int row = 0; row < rows; row++)
            //{
            //    for (int col = 0; col < cols; col++)
            //    {
            //        Console.Write(output[row][col]);
            //    }
            //    Console.WriteLine();
            //}
        }

    }
}
