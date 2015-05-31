using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class Example
    {
        public string Class { get; set; }
        //todo: to safe typed?
        public Dictionary<string, string> AttributeValues { get; set; }

        public Example(List<Attribute> attributes, string exampleRow)
        {
            //todo: unify class and attributes to one 
            List<int> exampleAttributeValues = exampleRow.Split('\t').Select(int.Parse).ToList();
            var classAttribute = attributes.First();
            var classValueIndex = exampleAttributeValues.First() - 1; //attribute encoding is 1-based, list is 0-based
            Class = classAttribute.Values[classValueIndex];

            var attributeValueCodes = exampleAttributeValues.Skip(1).ToList();

            AttributeValues = new Dictionary<string,string>();
            
            // assumption! order of attributes matches order of data in example
            attributes = attributes.Skip(1).ToList();
            for (int i = 0; i < attributeValueCodes.Count; i++)
            {
                var attribute = attributes[i];
                var valueIndex = attributeValueCodes[i] - 1;
                AttributeValues[attribute.Name] = attribute.Values[valueIndex];
            }
        }
        public override string ToString()
        {
            return Class + ": " + string.Join(", ", AttributeValues.Select(x => x.Value + " " + x.Key));
        }
    }
}
