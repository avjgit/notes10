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

            using (var f = new StreamReader(v))
            {
                while (!f.EndOfStream)
                {
                    var line = String.Empty;

                    var entry = new Importable();

                    // catch start of entry (starts with @)
                    while (!IsStartOfEntry(line))
                        line = f.ReadLine();

                    // read in type and code
                    entry.Type = GetEntryType(line);
                    entry.Code = GetEntryCode(line);

                    // while not end of entry (== "}")
                    line = f.ReadLine();

                    do
                    {
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

                        line = f.ReadLine();

                    } while (!IsEndOfEntry(line));

                    result.Add(entry);
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

        private static string GetEntryCode(string line) =>
            line.Split('{')[1].Trim().TrimEnd(',');

        private static string GetEntryType(string line) =>
            line.Split('{')[0].Trim().TrimStart('@');

        private static bool IsStartOfEntry(string line) =>
            line.StartsWith("@");


        internal static List<BOOK> ExtractBooks(List<Importable> import)
        {
            var books = new List<BOOK>();
            var propertyValue = String.Empty;
            foreach (var item in import.Where(x => x.Type == "BOOK"))
            {
                var book = new BOOK();
                book.BibCodeOriginal = item.Code;

                if (item.Properties.TryGetValue("title", out propertyValue))
                    book.Title = propertyValue;

                if (item.Properties.TryGetValue("author", out propertyValue))
                    book.Authors = propertyValue;

                if (item.Properties.TryGetValue("year"", out propertyValue))
                    book.Year = Int32.Parse(propertyValue;

                if (item.Properties.TryGetValue("publisher", out propertyValue))
                    book.Publisher = propertyValue;

                if (item.Properties.TryGetValue("address", out propertyValue))
                    book.PublishersAddress = propertyValue;
                books.Add(book);
            }
            return books;
        }

        internal static List<ARTICLE> ExtractArticles(List<Importable> import)
        {
            var articles = new List<ARTICLE>();
            var propertyValue = String.Empty;
            foreach (var item in import.Where(x => x.Type == "ARTICLE"))
            {
                var article = new ARTICLE();
                article.BibCodeOriginal = item.Code;

                if (item.Properties.TryGetValue("title", out propertyValue))
                    article.Title = propertyValue;

                if (item.Properties.TryGetValue("author", out propertyValue))
                    article.Authors = propertyValue;

                if (item.Properties.TryGetValue("year"", out propertyValue))
                    article.Year = Int32.Parse(propertyValue;

                if (item.Properties.TryGetValue("journal", out propertyValue))
                    article.Journal = propertyValue;

                if (item.Properties.TryGetValue("volume", out propertyValue))
                    article.Volume = propertyValue;
                articles.Add(article);
            }
            return articles;
        }

        internal static List<Thesis> ExtractMasters(List<Importable> import)
        {
            var masters = new List<Thesis>();
            var propertyValue = String.Empty;
            foreach (var item in import.Where(x => x.Type == "MASTERSTHESIS"))
            {
                var master = new Thesis();
                master.BibCodeOriginal = item.Code;

                if (item.Properties.TryGetValue("title", out propertyValue))
                    master.Title = propertyValue;

                if (item.Properties.TryGetValue("author", out propertyValue))
                    master.Authors = propertyValue;

                if (item.Properties.TryGetValue("year"", out propertyValue))
                    master.Year = Int32.Parse(propertyValue;
                master.Type = Thesis.ThesisType.MASTERSTHESIS;

                if (item.Properties.TryGetValue("school", out propertyValue))
                    master.School = propertyValue;
                masters.Add(master);
            }
            return masters;
        }

        internal static List<Thesis> ExtractPhds(List<Importable> import)
        {
            var phds = new List<Thesis>();
            var propertyValue = String.Empty;
            foreach (var item in import.Where(x => x.Type == "PHDTHESIS"))
            {
                var phd = new Thesis();
                phd.BibCodeOriginal = item.Code;

                if (item.Properties.TryGetValue("title", out propertyValue))
                    phd.Title = propertyValue;

                if (item.Properties.TryGetValue("author", out propertyValue))
                    phd.Authors = propertyValue;

                if (item.Properties.TryGetValue("year", out propertyValue))
                    phd.Year = Int32.Parse(propertyValue);
                phd.Type = Thesis.ThesisType.PHDTHESIS;

                if (item.Properties.TryGetValue("school", out propertyValue))
                    phd.School = propertyValue;
                phds.Add(phd);
            }
            return phds;
        }
    }
}