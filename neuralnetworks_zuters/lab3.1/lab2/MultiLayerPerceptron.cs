using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class MultiLayerPerceptron
    {
        public Perceptron Hidden { get; set; }
        public Perceptron Last { get; set; }

        public List<double> RunMlpSingle(Sample sample)
        {
            List<double> output = Hidden.RunLayerSingle(sample);

            var outputAsSample = new Sample();
            outputAsSample.Inputs = output;

            return Last.RunLayerSingle(outputAsSample);
        }

        
        public void TrainMlp(
            List<Sample> samples,
            List<double> expectedAnswers,
            double maxError,
            int maxEpochs)
        {
            var error = double.MaxValue;
            var epoch = 0;
            while (epoch < maxEpochs && error > maxError)
            {
                epoch++;
                error = 0;

                var errors = new List<double>();
                for (int k = 0; k < samples.Count; k++)
                {
                    RunMlpSingle(samples[k]);

                    var sampleFromHiddenOtput = new Sample();
                    sampleFromHiddenOtput.Inputs = Hidden.Neurons.Select(x => x.YValue).ToList();

                    errors = Last.TrainLastSingle(sampleFromHiddenOtput, expectedAnswers[k]);

                    Hidden.TrainHiddenSingle(samples[k], Last);

                    foreach (var e in errors)
                    {
                        error += Math.Pow(e, 2);
                    }
                }

                error = error / (samples.Count * errors.Count);
            }

            Console.WriteLine("Epochs used: " + epoch);
        }
    }
}
