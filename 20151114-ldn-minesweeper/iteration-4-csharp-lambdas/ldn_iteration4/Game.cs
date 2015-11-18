using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ldn_iteration4
{
    public class Game
    {
        List<Cell> cells = new List<Cell>();

        public void Start()
        {
            var myLines = File.ReadAllLines(@"C:\Users\avjma_000\Documents\GitHub\notes10\codeforce\ldn201511_minesweeper\ldn201511_minesweeper\minesweeper_input.txt");
            myLines.ToList().ForEach(line => Console.WriteLine(line));
            for (int row = 0; row < myLines.Length; row++) {
                for (int col = 0; col < myLines[row].Length; col++) {
                    var cell = CellFactory(myLines[row][col], row, col);
                    cells.Add(cell);
                }
            }

        }

        public void Count()
        {
            foreach (var cell in cells)
            {
                if (cell is Mine)
                {
                    cells.Where(c => c.IsNeighbor(cell)).ToList().ForEach(c =>
                        {
                            if (!c.IsMine)
                                c.Mines++;
                        }
                    );
                }
            }
        }


        private Cell CellFactory(char symbol, int X, int Y)
        {
            if (symbol.Equals('*'))
            {
                return new Mine(X,Y);
            }
            return new EmptyCell(X,Y);
        }
    }
}