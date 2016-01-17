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

        public ARTICLE() : base()
        {

        }

        public ARTICLE(string authorsList, string title, int year, string journal, string volume) 
            : base()
        {
            Authors = authorsList;
            Title = title;
            Year = year;
            Journal = journal;
            Volume = volume;
        }

        public override string BibTexPrint()
        {
            return $@"
@{BibType}{{{BibCode},
    author = {{ {Authors} }},
    title = {{ {Title} }},
    journal = {{ {Journal} }},
    year = {{ {Year} }},
    timestamp = {{ {CreationDate} }}
}}";
        }

        public static string ProgramName = "AJ05044HW1";
        public static string GetProgramName => ProgramName;
    }
}
