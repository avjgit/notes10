using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class Attribute
    {
        public List<string> NameAndValues { get; set; }

        public string Name 
        {
            get { return NameAndValues.First(); }
        }

        public List<string> Values 
        {
            get { return NameAndValues.Skip(1).ToList(); }
        }

        public Attribute()
        {

        }

        public Attribute(string attributeWithValues)
        {
            NameAndValues = attributeWithValues.Split('\t').ToList();
            NameAndValues.Remove("-");
        }
        
        private int Code(string value)
        {
            return NameAndValues.IndexOf(value);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Name + ": ");
            Values.ToList<string>().ForEach(v => sb.Append(v + " (" + Code(v) + "), "));
            return sb.ToString().Trim().TrimEnd(',');
        }
    }
}
