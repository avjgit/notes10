using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ldn_iteration4
{
    class Mine:Cell
    {
        public bool IsMine => true;

        public Mine(int x, int y):base(x, y)
        {

        }
    }

}
