using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ldn201511_minesweeper
{
    public class CellInputReader
    {
        public Cell[,] ReadCells(string filename)
        {
            string[] lines = System.IO.File.ReadAllLines(filename);
            int rows = lines.Count();
            int cols = lines[0].Length;
            
            int row = 0;
            Cell[,] cells = new Cell[rows,cols];

            foreach (string line in lines)
            {
                int col = 0;
                foreach (var c in line.ToCharArray())
                {
                    var cell = CellFactory.GetInstance().CreateCell(c);
                    cells[row, col] = cell;
                    col++;
                }
                row++;
            }
            return cells;
        }
    }
}
