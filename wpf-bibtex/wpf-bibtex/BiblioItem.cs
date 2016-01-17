using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_bibtex
{
    public abstract class BiblioItem
    {
        private string title;
        private int year;
        private DateTime creationDate;

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                if (value > 1800 && value <= DateTime.Now.Year + 1)
                    year = value;
            }
        }

        public DateTime CreationDate
        {
            get
            {
                return creationDate;
            }
        }

        public BiblioItem()
        {
            Authors = new List<Author>();
            creationDate = DateTime.Now;
        }

        public List<Author> Authors { get; set; }

        public string AuthorsString => string.Join(", ", Authors);

        private string AuthorsLastNames => Authors.Select(a => a.LastLastName).ToString();

        internal string BibCode => AuthorsLastNames + Year.ToString();

        internal string BibType => GetType().Name;
        public virtual string BibTexPrint()

        {
            return $@"
@{BibType}{{
    {BibCode},
    title = {{ {Title} }},
    year = {{ {Year} }},
    author = {{ {AuthorsString} }},
    timestamp = {{ {CreationDate} }}
}}";
        }

    }
}
