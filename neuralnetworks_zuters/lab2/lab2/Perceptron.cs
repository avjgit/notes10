using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Perceptron
    {
        public List<Neuron> Neurons { get; set; }
        public double Gradient { get; set; }
        public double LearningCoefficient { get; set; }

        public Perceptron()
        {

        }

        public Perceptron(List<Neuron> neurons, double gradient, double learning)
        {
            Neurons = neurons;
            Gradient = gradient;
            LearningCoefficient = learning;
        }

        public List<double> SlpRunSingle(Sample sample)
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

        public List<double> SlpTrainSingle(Sample sample, int expectedAnswer)
        {
            var slpResult = SlpRunSingle(sample);
            var errors = new List<double>();

            for (int i = 0; i < Neurons.Count; i++)
            {
                var error = expectedAnswer - slpResult[i];
                errors.Add(error);
                var grad = error / Gradient * slpResult[i] * (1 - slpResult[i]);

                for (int k = 0; k < Neurons[i].Weights.Count; k++)
                {
                    Neurons[i].Weights[k] += LearningCoefficient * sample.Inputs[k] * grad;
                }
                Neurons[i].BonusWeight += LearningCoefficient * grad;
            }
            return errors;
        }

        public Tuple<List<List<double>>, List<double>> SlpTrain(
            List<Sample> samples, 
            List<int> expectedAnswers, 
            double maxError, 
            int maxEpochs)
        {
            var error = double.MaxValue;
            var epoch = 0;
            while (epoch < maxEpochs && error > maxError)
            {
                epoch++;
                error = 0;

                for (int i = 0; i < samples.Count; i++)
                {
                    var errors = SlpTrainSingle(samples[i], expectedAnswers[i]);

                    for (int n = 0; n < Neurons.Count; n++)
                    {
                        error += Math.Pow(errors[n], 2);
                    }
                }

                error = error / samples.Count * Neurons.Count;
            }

            Console.WriteLine("Epochs used: " + epoch);

            var weights = Neurons.Select(x => x.Weights).ToList();
            var bonusWeights = Neurons.Select(x => x.BonusWeight).ToList();
            return Tuple.Create(weights, bonusWeights);
        }
    }
}
