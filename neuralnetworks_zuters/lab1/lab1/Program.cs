using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Program
    {
        const string attributesNamesFile = "..\\..\\attributevaluenames.txt";
        const string examplesFile = "..\\..\\examples.txt";

        static void Main(string[] args)
        {
            List<Attribute> attributes = new List<Attribute>();

            try
            {
                int attribute_count = 0;
                using (StreamReader sr = new StreamReader(attributesNamesFile))
                {
                    attributes = new List<Attribute>();
                    string line;
                    Console.WriteLine("\nAttributes: ");
                    while ((line = sr.ReadLine()) != null)
                    {
                        attributes.Add(new Attribute(line));
                        Console.WriteLine(attribute_count + ": " + attributes.Last());
                        attribute_count++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The attribute file could not be read:" + e.Message);
            }
            
            List<Example> examples = new List<Example>();
            try
            {
                int example_count = 0;
                using (StreamReader sr = new StreamReader(examplesFile))
                {
                    string line;
                    Console.WriteLine("\nExamples: ");
                    while ((line = sr.ReadLine()) != null)
                    {
                        examples.Add(new Example(attributes, line));
                        Console.WriteLine(example_count.ToString("00") + ": " + examples.Last());
                        example_count++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The example file could not be read:" + e.Message);
            }

            Node trainedTree = ID3.Run(examples, attributes);

            //examples.ForEach(e => Console.WriteLine(ID3.Classify(trainedTree, e)));

            foreach (var e in examples)
            {
                Console.WriteLine(ID3.Classify(trainedTree, e));                
            }


        }
    }
}
