using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Perceptron
    {
        public List<Neuron> Neurons { get; set; }
        public double Gradient { get; set; }
        public double LearningCoefficient { get; set; }

        public double LocalGradient { get; set; }

        public Perceptron()
        {
            Neurons = new List<Neuron>();
        }

        public Perceptron(List<Neuron> neurons, double gradient, double learning)
        {
            Neurons = neurons;
            Gradient = gradient;
            LearningCoefficient = learning;
        }

        public List<double> RunLayerSingle(Sample sample)
        {
            var results = new List<double>();

            foreach (var neuron in Neurons)
            {
                var inputsMultipliedByWeights = sample.Inputs.Zip(neuron.Weights, (i, w) => i * w).Sum();

                var NET = neuron.BonusWeight + inputsMultipliedByWeights;

                results.Add( 1 / (1 + Math.Exp(-NET / Gradient)));
            }
            
            return results;
        }
        
        public List<double> TrainLastSingle(Sample sample, double expectedAnswer)
        {
            //var slpResult = RunLayerSingle(sample);
            var errors = new List<double>();

            for (int i = 0; i < Neurons.Count; i++)
            {
                var error = expectedAnswer - Neurons[i].YValue;
                errors.Add(error);
                LocalGradient = error / Gradient * Neurons[i].YValue * (1 - Neurons[i].YValue);

                for (int k = 0; k < Neurons[i].Weights.Count; k++)
                {
                    Neurons[i].Weights[k] += LearningCoefficient * sample.Inputs[k] * LocalGradient;
                }
                Neurons[i].BonusWeight += LearningCoefficient * LocalGradient;
            }
            return errors;
        }

        public void TrainHiddenSingle(Sample sample, Perceptron NEXT)
        {
            for(int j = 0; j < Neurons.Count; j++)
            {
                double error = 0;
                foreach (var neuron in NEXT.Neurons)
	            {
                    error += NEXT.LocalGradient * neuron.Weights[j];
	            }
                
                LocalGradient = error / Gradient * Neurons[j].YValue * (1 - Neurons[j].YValue);

                for (int k = 0; k < Neurons[j].Weights.Count; k++)
                {
                    Neurons[j].Weights[k] += LearningCoefficient * sample.Inputs[k] * LocalGradient;
                }
                Neurons[j].BonusWeight += LearningCoefficient * LocalGradient;
            }
        }
    }
}
