using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_bibtex
{
    public class BOOK : BiblioItem
    {
        public string Publisher { get; set; }
        public string PublishersAddress { get; set; }

        public BOOK()
            : base()
        {
        }

        public BOOK(string authorsList, string title, string publisher, int year, string publishersAddress) 
            : base()
        {
            Authors = authorsList;
            Title = title;
            Publisher = publisher;
            Year = year;
            PublishersAddress = publishersAddress;
        }

        public override string BibTexPrint()
        {
            return $@"
@{BibType}{{{BibCode},
    author = {{ {Authors} }},
    title = {{ {Title} }},
    year = {{ {Year} }},
    publisher = {{ {Publisher} }},
    address = {{ {PublishersAddress} }},
    timestamp = {{ {CreationDate} }}
}}";
        }
    }
}
