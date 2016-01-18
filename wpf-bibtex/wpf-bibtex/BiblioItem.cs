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
            creationDate = DateTime.Now;
            year = DateTime.Now.Year;
        }

        public string Authors { get; set; }

        private string AuthorsLastNames()
        {
            string authorsLastNames = String.Empty;
            foreach (var author in Authors.Replace(", ", ",").Split(','))
            {
                authorsLastNames += author.Split(' ').Last();
            };
            return authorsLastNames;
        }

        private string BibCodeGenerated => AuthorsLastNames() + Year.ToString();

        public string BibCodeOriginal { get; set; }

        internal string BibCode =>
            String.IsNullOrEmpty(BibCodeOriginal)
            ? BibCodeGenerated
            : BibCodeOriginal;

        internal string BibType => GetType().Name;

        public virtual string BibTexPrint()

        {
            return $@"
@{BibType}{{{BibCode},
    title = {{ {Title} }},
    year = {{ {Year} }},
    author = {{ {Authors} }},
    timestamp = {{ {CreationDate} }}
}}";
        }

    }
}
