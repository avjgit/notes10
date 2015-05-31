using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class Attribute
    {
        public string Name { get; set; }
        public List<string> Values { get; set; }

        public Attribute(string attributeWithValues)
        {
            List<string> attribute = attributeWithValues.Split('\t').ToList();
            Name = attribute.First();
            Values = attribute.Skip(1).ToList();
            Values.Remove("-");
        }
        
        private int Code(string value)
        {
            return Values.IndexOf(value) + 1;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Name + ": ");
            Values.ForEach(v => sb.Append(v + " (" + Code(v) + "), "));
            return sb.ToString().Trim().TrimEnd(',');
        }
    }
}
