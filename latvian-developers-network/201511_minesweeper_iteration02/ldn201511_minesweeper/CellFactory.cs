using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ldn201511_minesweeper
{
    public class CellFactory
    {
        private static CellFactory instance;

        public static CellFactory GetInstance()
        {
            if (instance == null)
            {
                instance = new CellFactory();
            }
            return instance;
        }

        private CellFactory()
        {

        }
        public Cell CreateCell(char val)
        {
            switch (val)
            {
                case '*':
                    return new Bomb();
                default:
                    return new EmptyCell();
            }
        }
    }
}
