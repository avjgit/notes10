using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Sample
    {
        public List<double> Inputs { get; set; }

        public Sample()
        {

        }

        public Sample(string input)
        {
            Inputs = input.Split('\t').Select(double.Parse).ToList();
        }
    }
}
