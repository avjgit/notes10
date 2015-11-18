using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ldn201511_minesweeper
{
    public class GameField
    {
        public Cell[,] Cells;

        public GameField(Cell[,] cells)
        {
            Cells = cells;

        }

        public void Process()
        {
            for (int i = 0; i < Cells.Length; i++)
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    var cell = Cells[i,j];
                    if (cell.IsBomb())
                        UpdateNeighbors(i, j);
                }
        }

        private void UpdateNeighbors(int i, int j)
        {
            // update neighbors
        }
    }
}
