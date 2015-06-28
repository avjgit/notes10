using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Sample
    {
        public List<int> Inputs { get; set; }

        public Sample()
        {

        }

        public Sample(string input)
        {
            Inputs = input.Split('\t').Select(int.Parse).ToList();
        }
    }
}
