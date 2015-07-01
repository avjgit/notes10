using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Program
    {
        const string samplesFile = "..\\..\\..\\data\\examples_boolean.txt";
        const string expectedAnswers = "..\\..\\..\\data\\d_notand.txt";
        
        private static List<double> Normalize(List<double> data, Dictionary<double, double> rules)
        {
            data.ForEach(x => x = rules[x]);
            return data;
        }

        static void Main(string[] args)
        {
            var samples = new List<Sample>();
            var answers = new List<double>();

            try
            {
                Console.WriteLine("Samples: ");
                using (StreamReader sr = new StreamReader(samplesFile))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                        samples.Add(new Sample(line));
                    }
                }

                Console.WriteLine("Answers: ");
                using (StreamReader sr = new StreamReader(expectedAnswers))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                        answers.Add(Int32.Parse(line));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error by reading dataFile: " + e);
                throw;
            }

            Dictionary<double, double> normalizationRules1 = new Dictionary<double, double>();
            normalizationRules1.Add(1, 0);
            normalizationRules1.Add(2, 0.5);
            normalizationRules1.Add(3, 1);

            Dictionary<double, double> normalizationRules2 = new Dictionary<double, double>();
            normalizationRules2.Add(1, 0.1);
            normalizationRules2.Add(2, 0.5);
            normalizationRules2.Add(3, 0.2);

            //foreach (var s in samples)
            //{
            //    s.Inputs = Normalize(s.Inputs, normalizationRules1);
            //}

            //answers = Normalize(answers, normalizationRules1);
            
            var mlPerceptron = new MultiLayerPerceptron();
            
            mlPerceptron.Hidden = new Perceptron()
            {
                Neurons = new List<Neuron>
                {
                    new Neuron(samples.First().Inputs.Count),
                    new Neuron(samples.First().Inputs.Count),
                    new Neuron(samples.First().Inputs.Count),
                    new Neuron(samples.First().Inputs.Count)
                },
                LearningCoefficient = 0.1,
                Gradient = 0.2
            };

            mlPerceptron.Last = new Perceptron()
            {
                Neurons = new List<Neuron> { new Neuron(mlPerceptron.Hidden.Neurons.Count) },
                LearningCoefficient = 0.1,
                Gradient = 0.2
            };

            mlPerceptron.TrainMlp(samples, answers, 0.01, 500);

            Console.WriteLine("Weights of Hidden:");
            foreach (var neuron in mlPerceptron.Hidden.Neurons)
            {
                neuron.Weights.ForEach(x => Console.Write("{0} ", x));
                Console.WriteLine(neuron.BonusWeight);
            }

            Console.WriteLine("Weights of Last:");
            foreach (var neuron in mlPerceptron.Last.Neurons)
            {
                neuron.Weights.ForEach(x => Console.Write("{0} ", x));
                Console.WriteLine(neuron.BonusWeight);
            }

            Console.WriteLine("test: ");
            foreach (var sample in samples)
            {
                mlPerceptron.RunMlpSingle(sample).ForEach(result => Console.WriteLine(result));
            }
        }
    }
}
