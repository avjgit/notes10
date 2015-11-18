using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ldn201511_minesweeper
{
    public class Bomb : Cell
    {
        public Bomb()
        {
            Value = '*';
        }

        public override bool IsBomb() => true;
    }
}
