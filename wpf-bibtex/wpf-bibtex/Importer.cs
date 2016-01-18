using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace wpf_bibtex
{
    internal static class Importer
    {
        internal static List<Importable> GetItems(string v)
        {
            var result = new List<Importable>();

            Importable entry;
            using (var f = new StreamReader(v))
            {
                string line = String.Empty;
                entry = new Importable();

                while (!f.EndOfStream)
                {
                    // catch start of entry (starts with @)
                    while (!IsStartOfEntry(line));
                        line = f.ReadLine();

                    // read in type and code
                    entry.Code = GetEntryCode(line);
                    entry.Type = GetEntryType(line);

                    // while not end of entry (== "}")
                    while (!IsEndOfEntry(line))
                    {
                        line = f.ReadLine();

                        if (string.IsNullOrEmpty(line))
                            continue;
                        
                        // read in properties: 
                        // parse "     property = {propertyValue}"
                        var propertyName = GetPropertyName(line);
                        var propertyValue = GetPropertyValue(line);

                        if (propertyName == null || propertyValue == null)
                            continue;
                        
                        // save into dictionary[property] = propertyValue
                        entry.Properties[propertyName] = propertyValue;
                    }
                }
            }
            return result;
        }

        private static string GetPropertyValue(string line) =>
            line.Split('=')[1].Trim().TrimEnd(',').TrimStart('{').TrimEnd('}').Trim();

        private static string GetPropertyName(string line) =>
            line.Split('=')[0].Trim();

        private static bool IsEndOfEntry(string line) =>
            String.Equals(line.Trim(), "}");

        private static string GetEntryType(string line) =>
            line.Split('{')[1].Trim().TrimEnd(',');

        private static string GetEntryCode(string line) =>
            line.Split('{')[0].Trim().TrimStart('@');

        private static bool IsStartOfEntry(string line) => 
            line.StartsWith("@");


        internal static List<BOOK> ExtractBooks(List<Importable> import)
        {
            var books = new List<BOOK>();
            foreach (var item in import.Where(x => x.Type == "BOOK"))
            {
                var book = new BOOK();
                book.BibCodeOriginal = item.Code;
                book.Title = item.Properties["title"];
                book.Authors = item.Properties["author"];
                book.Year = Int32.Parse(item.Properties["year"]);
                book.Publisher = item.Properties["publisher"];
                book.PublishersAddress = item.Properties["address"];
                books.Add(book);
            }
            return books;
        }

        internal static List<ARTICLE> ExtractArticles(List<Importable> import)
        {
            var articles = new List<ARTICLE>();
            foreach (var item in import.Where(x => x.Type == "ARTICLE"))
            {
                var article = new ARTICLE();
                article.BibCodeOriginal = item.Code;
                article.Title = item.Properties["title"];
                article.Authors = item.Properties["author"];
                article.Year = Int32.Parse(item.Properties["year"]);
                article.Journal = item.Properties["journal"];
                article.Volume = item.Properties["volume"];
                articles.Add(article);
            }
            return articles;
        }

        internal static List<Thesis> ExtractMasters(List<Importable> import)
        {
            var masters = new List<Thesis>();
            foreach (var item in import.Where(x => x.Type == "MASTERSTHESIS"))
            {
                var master = new Thesis();
                master.BibCodeOriginal = item.Code;
                master.Title = item.Properties["title"];
                master.Authors = item.Properties["author"];
                master.Year = Int32.Parse(item.Properties["year"]);
                master.Type = Thesis.ThesisType.MASTERSTHESIS;
                master.School = item.Properties["school"];
                masters.Add(master);
            }
            return masters;
        }

        internal static List<Thesis> ExtractPhds(List<Importable> import)
        {
            var phds = new List<Thesis>();
            foreach (var item in import.Where(x => x.Type == "PHDTHESIS"))
            {
                var phd = new Thesis();
                phd.BibCodeOriginal = item.Code;
                phd.Title = item.Properties["title"];
                phd.Authors = item.Properties["author"];
                phd.Year = Int32.Parse(item.Properties["year"]);
                phd.Type = Thesis.ThesisType.PHDTHESIS;
                phd.School = item.Properties["school"];
                phds.Add(phd);
            }
            return phds;
        }
    }
}