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

        public BOOK(string authorsList, string title, string publisher, int year, string publishersAddress) 
            : base()
        {
            foreach (var author in authorsList.Replace(", ", ",").Split(','))
                Authors.Add(new Author(author));

            Title = title;
            Publisher = publisher;
            Year = year;
            PublishersAddress = publishersAddress;
        }

        public override string BibTexPrint()
        {
            return $@"
@{BibType}{{
    {BibCode},
    title = {{ {Title} }},
    publisher = {{ {Publisher} }},
    year = {{ {Year} }},
    author = {{ {AuthorsString} }},
    address = {{ {PublishersAddress} }},
    timestamp = {{ {CreationDate} }}
}}";
        }
    }
}
