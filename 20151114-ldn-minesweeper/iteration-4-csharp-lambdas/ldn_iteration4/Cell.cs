using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ldn_iteration4
{
    class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Cell(int col, int row)
        {
            X = col;
            Y = row;
        }
        public int Mines { get; set; }

        public bool IsMine => false;

        public bool IsNeighbor(Cell cell)
        {
            return (X == cell.X + 1 && Y == cell.Y - 1)
                || (X == cell.X + 1 && Y == cell.Y)
                || (X == cell.X + 1 && Y == cell.Y + 1)
                || (X == cell.X && Y == cell.Y - 1)
                || (X == cell.X && Y == cell.Y + 1)
                || (X == cell.X - 1 && Y == cell.Y - 1)
                || (X == cell.X - 1 && Y == cell.Y)
                || (X == cell.X - 1 && Y == cell.Y + 1)
                ;
        }
    }
}
