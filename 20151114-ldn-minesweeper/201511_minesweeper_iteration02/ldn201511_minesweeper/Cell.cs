using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ldn201511_minesweeper
{
    public abstract class Cell
    {
        public char Value { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }

        public abstract bool IsBomb();
    }
}
