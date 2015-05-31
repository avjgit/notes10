using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public static class ID3
    {
        public static string Classify(Node trainedTree, Example example)
        {
            if (!String.IsNullOrEmpty(trainedTree.Class))
            {
                return trainedTree.Class;
            }
            else
            {
                var attribute = trainedTree.Attribute;
                var attribute_value = example.AttributeValues[attribute.Name];
                var treeBranch = trainedTree.Nodes.Where(n => n.PreviousAttributeValue == attribute_value).First();
                return Classify(treeBranch, example);
            }
        }

        public static Node Run(List<Example> examples, List<Attribute> attributes, string previousAttributeValue = null)
        {
            var decisionTree = new Node();
            decisionTree.PreviousAttributeValue = previousAttributeValue;

            if (AreEmpty(examples))
                return decisionTree;

            if (AllOfSameClass(examples))
            {
                decisionTree.Class = examples.First().Class;
            }
            else if (AreEmpty(attributes))
            {
                decisionTree.Class = MostFrequentClass(examples);
            }
            else
            {
                var bestAttribute = BestAttribute(examples, attributes);

                if (bestAttribute == null)
                    return decisionTree;


                decisionTree.Attribute = bestAttribute;
                
                foreach (var x in bestAttribute.Values)
                {
                    Console.WriteLine("Evaluating attribute " + bestAttribute.Name.ToUpper() + " value " + x);
                    var examplesWithBestAttributeValueX = examples.Where(e => e.AttributeValues[bestAttribute.Name] == x).ToList();

                    Node node = new Node();
                    if (AreEmpty(examplesWithBestAttributeValueX))
                    {
                        node.PreviousAttributeValue = x;
                        node.Class = MostFrequentClass(examples);
                    }
                    else
                    {
                        attributes.Remove(bestAttribute);
                        node = Run(examplesWithBestAttributeValueX, new List<Attribute>(attributes), x);
                    }
                    decisionTree.Nodes.Add(node);
                }                
            }
            return decisionTree;
        }

        private static Attribute BestAttribute(List<Example> examples, List<Attribute> attributes)
        {
            // test
            List<string> testAttributeNames = new List<string>() { "income", "history", "debt" };

            foreach (var name in testAttributeNames)
            {
                var attribute = attributes.Where(a => a.Name == name).FirstOrDefault();
                if (attribute != null)
                    return attribute;                
            }
            return null;
            //todo: do real
        }

        private static bool AreEmpty(IEnumerable<object> examples)
        {
            return examples == null || !examples.Any();
        }        

        private static bool AllOfSameClass(List<Example> examples)
        {
            var firstExampleClass = examples.First().Class;
            return examples.All(x => x.Class == firstExampleClass);
        }

        private static string MostFrequentClass(List<Example> examples)
        {
            return examples
                    .GroupBy(e => e.Class)
                    .OrderByDescending(gp => gp.Count())
                    .Take(1)
                    .Select(t => t.Key)
                    .ToString();
        }
    }
}
