using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_bibtex
{
    public class Thesis : BiblioItem
    {
        public enum ThesisType
        {
            MASTERSTHESIS,
            PHDTHESIS,
            QUALIFICATIONTHESIS
        }

        public ThesisType Type { get; set; }
        public string School { get; set; }

        public Thesis(
            string authorFirstname, 
            string authorLastname,
            string title,
            ThesisType thesisType,
            string school,
            int year
            )
        {
            Authors.Add(new Author(authorFirstname, authorLastname));
            Title = title;
            Type = thesisType;
            School = school;
            Year = year;
        }

        public override string BibTexPrint()
        {
            return $@"
@{Type}{{
    {BibCode},
    author = {{ {AuthorsString} }},
    title = {{ {Title} }},
    school = {{ {School} }},
    year = {{ {Year} }},
    timestamp = {{ {CreationDate} }}
}}";
        }

    }
}
