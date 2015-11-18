using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ldn201511_minesweeper
{
    public class EmptyCell : Cell
    {
        public override bool IsBomb() => false;

    }
}
