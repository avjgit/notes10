using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Program
    {
        const string samplesFile = "..\\..\\..\\data\\examples.txt";
        const string expectedAnswers = "..\\..\\..\\data\\d.txt";

        static double RandomBetween(double lowerBound, double upperBound)
        {
            var range = Math.Abs(upperBound - lowerBound);
            var randomPercentage = new Random().Next(101) / 100.0;
            var addition = range * randomPercentage;
            return Math.Round(lowerBound + addition, 1);
        }

        static void Main(string[] args)
        {
            var samples = new List<Sample>();
            var answers = new List<int>();

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

            var neuron = new Neuron()
            {
                Weights = new List<double> { RandomBetween(-0.3, 0.3), RandomBetween(-0.3, 0.3) },
                BonusWeight = 0.1
            };

            var perceptron = new Perceptron()
            {
                Neurons = new List<Neuron>{neuron},
                Gradient = 0.2,
                LearningCoefficient = 0.1
            };

            //Console.WriteLine("Check slp run single:");
            //foreach (var sample in samples)
            //{
            //    perceptron.SlpRunSingle(sample).ForEach(result => Console.WriteLine(result));
            //}

            //Console.WriteLine("Check slp train single:");
            //for (int i = 0; i < samples.Count; i++)
            //{
            //    perceptron.SlpTrainSingle(samples[i], answers[i]).ForEach(result => Console.WriteLine(result));                
            //}

            //Console.WriteLine("Check slp train:");
            var trainingResult = perceptron.SlpTrain(samples, answers, 0.01, 500);
            Console.WriteLine("Weights:");
            trainingResult.Item1.ForEach(weights => weights.ForEach(w => Console.WriteLine(w)));
            Console.WriteLine("B:");
            trainingResult.Item2.ForEach(w => Console.WriteLine(w));

            Console.WriteLine("test: ");
            foreach (var sample in samples)
            {
                perceptron.SlpRunSingle(sample).ForEach(result => Console.WriteLine(result));
            }
        }
    }
}
