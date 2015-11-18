using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ldn_iteration4
{
    class EmptyCell : Cell
    {
        public int Mines { get; set; }

        public EmptyCell(int x, int y):base(x, y)
        {

        }
    }
}
