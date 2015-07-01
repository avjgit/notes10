using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Neuron
    {
        public List<double> Weights { get; set; }
        public double BonusWeight { get; set; }
        public double YValue { get; set; }

        private double RandomBetween(double lowerBound, double upperBound)
        {
            var range = Math.Abs(upperBound - lowerBound);
            var randomPercentage = new Random().Next(101) / 100.0;
            var addition = range * randomPercentage;
            return Math.Round(lowerBound + addition, 1);
        }
        
        public Neuron()
        {

        }

        public Neuron(int inputSize)
        {

            Weights = new List<double>();
            for (int i = 0; i < inputSize; i++)
			{
			    Weights.Add(RandomBetween(-0.3, 0.3));
			};

            BonusWeight = RandomBetween(-0.3, 0.3);
        }
    }
}
