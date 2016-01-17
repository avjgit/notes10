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
        private string year;

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

        public string Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
            }
        }


    }
}
