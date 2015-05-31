using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class Node
    {
        public string PreviousAttributeValue { get; set; }
        public Attribute Attribute { get; set; }
        public string Class { get; set; }
        public List<Node> Nodes { get; set; }

        public Node()
        {
            Nodes = new List<Node>();
        }
    }
}
