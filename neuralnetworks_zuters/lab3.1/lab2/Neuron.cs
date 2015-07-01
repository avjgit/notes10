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
        
        private double RandomBetween(Random r, int lowerBound, int upperBound, int step = 1)
        {
            var range = Math.Abs(upperBound - lowerBound);
            var stepsInRange = (int) (range / step);
            var randomSteps = r.Next(0, stepsInRange + 1);
            return (lowerBound + step * randomSteps)/10.0;
        }
        
        public Neuron()
        {

        }

        public Neuron(Random r, int inputSize)
        {

            Weights = new List<double>();
            for (int i = 0; i < inputSize; i++)
			{
			    Weights.Add(RandomBetween(r, -3, 3));
			};

            BonusWeight = RandomBetween(r, -3, 3);
        }
    }
}
