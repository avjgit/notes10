using System.Collections.Generic;
using System.Linq;

namespace wpf_bibtex
{
    public class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName => FirstName + ' ' + LastName;

        public string LastLastName => LastName.Split(' ').Last();

        public Author(string name)
        {
            var nameSplit = new List<string>(name.Split(' '));
            FirstName = nameSplit.First();
            LastName = string.Join(" ", nameSplit.Skip(1));
        }
        public Author(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }
    }
}
