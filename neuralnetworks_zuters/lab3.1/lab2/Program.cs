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
        private static List<double> Normalize(List<double> data, Dictionary<double, double> rules)
        {
            if (rules != null)
            {
                data.ForEach(x => x = rules[x]);
            }
            return data;
        }

        static void Main(string[] args)
        {
            var r = new Random();

            Run("examples_boolean.txt", "d_notand.txt", null, r);

            Run("examples_boolean.txt", "d_xor.txt", null, r);

            Dictionary<double, double> normalizationRules1 = new Dictionary<double, double>();
            normalizationRules1.Add(1, 0);
            normalizationRules1.Add(2, 0.5);
            normalizationRules1.Add(3, 1);
            Run("examples.txt", "d.txt", normalizationRules1, r);

            Dictionary<double, double> normalizationRules2 = new Dictionary<double, double>();
            normalizationRules2.Add(1, 0.1);
            normalizationRules2.Add(2, 0.5);
            normalizationRules2.Add(3, 0.9);
            Run("examples.txt", "d.txt", normalizationRules2, r);

            //Run("examples.txt", "d2.txt", null);
            //Run("examples.txt", "d2.txt", null);
        }

        static void Run(string samplesFile, string answersFile, Dictionary<double, double> normalizationRules, Random r)
        {
            Console.WriteLine("================ Running for " + answersFile);

            var samples = new List<Sample>();
            var answers = new List<double>();

            samplesFile = "..\\..\\..\\data\\" + samplesFile;
            answersFile = "..\\..\\..\\data\\" + answersFile;

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
                using (StreamReader sr = new StreamReader(answersFile))
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

            foreach (var s in samples)
            {
                s.Inputs = Normalize(s.Inputs, normalizationRules);
            }

            answers = Normalize(answers, normalizationRules);
            
            var mlPerceptron = new MultiLayerPerceptron();
            
            mlPerceptron.Hidden = new Perceptron()
            {
                Neurons = new List<Neuron>
                {
                    new Neuron(r, samples.First().Inputs.Count),
                    new Neuron(r, samples.First().Inputs.Count),
                    new Neuron(r, samples.First().Inputs.Count),
                    new Neuron(r, samples.First().Inputs.Count)
                },
                LearningCoefficient = 0.1,
                Gradient = 0.2
            };

            mlPerceptron.Last = new Perceptron()
            {
                Neurons = new List<Neuron> 
                { 
                    new Neuron(r, mlPerceptron.Hidden.Neurons.Count) 
                },
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
