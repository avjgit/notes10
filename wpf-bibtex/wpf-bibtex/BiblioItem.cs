using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_bibtex
{
    abstract class BiblioItem
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
        }

        public List<Author> Authors { get; set; }

        public string AuthorsString => string.Join(", ", Authors);

        public string BibCode => Authors.First().LastLastName + Year.ToString();

        public virtual string BibTexPrint()
        {
            return $@"
@{this.GetType().Name}{{
    {BibCode},
    title = {{ {Title} }},
    year = {{ {Year} }},
    author = {{ {AuthorsString} }}
}}";

        }

    }
}
