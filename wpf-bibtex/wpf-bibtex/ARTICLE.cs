using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_bibtex
{
    public class ARTICLE : BiblioItem
    {
        public string Journal { get; set; }
        public string Volume { get; set; }

        public ARTICLE(string journal, string volume)
        {
            Journal = journal;
            Volume = volume;
        }

        public override string BibTexPrint()
        {
            return $@"
@{BibType}{{{BibCode},
    author = {{ {AuthorsString} }},
    title = {{ {Title} }},
    journal = {{ {Journal} }},
    year = {{ {Year} }},
    timestamp = {{ {CreationDate} }}
}}";
        }
    }
}
