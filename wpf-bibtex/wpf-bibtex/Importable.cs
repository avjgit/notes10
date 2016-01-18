using System.Collections.Generic;

namespace wpf_bibtex
{
    internal class Importable
    {
        public string Type { get; set; }
        public string Code { get; set; }
        public Dictionary<string, string> Properties { get; set; }
        public Importable()
        {
            Properties = new Dictionary<string, string>();
        }
    }
}