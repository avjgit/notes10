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
                var bookTitle = String.Empty;
                var bookAuthors = String.Empty;
                var bookYear = 0;
                var bookPublisher = String.Empty;
                var bookPublishersAddress = String.Empty;


                if (item.Properties.TryGetValue("author", out propertyValue))
                    bookAuthors = propertyValue;

                if (item.Properties.TryGetValue("title", out propertyValue))
                    bookTitle = propertyValue;

                if (item.Properties.TryGetValue("year", out propertyValue))
                    bookYear = Int32.Parse(propertyValue);

                if (item.Properties.TryGetValue("publisher", out propertyValue))
                    bookPublisher = propertyValue;

                if (item.Properties.TryGetValue("address", out propertyValue))
                    bookPublishersAddress = propertyValue;

                var book = new BOOK(bookAuthors, bookTitle, bookPublisher, bookYear, bookPublishersAddress);
                book.BibCodeOriginal = item.Code;

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
                var articleTitle = String.Empty;
                var articleAuthors = String.Empty;
                var articleYear = 0;
                var articleJournal = String.Empty;
                var articleVolume = String.Empty;

                if (item.Properties.TryGetValue("title", out propertyValue))
                    articleTitle = propertyValue;

                if (item.Properties.TryGetValue("author", out propertyValue))
                    articleAuthors = propertyValue;

                if (item.Properties.TryGetValue("year", out propertyValue))
                    articleYear = Int32.Parse(propertyValue);

                if (item.Properties.TryGetValue("journal", out propertyValue))
                    articleJournal = propertyValue;

                if (item.Properties.TryGetValue("volume", out propertyValue))
                    articleVolume = propertyValue;

                var article = new ARTICLE(articleAuthors, articleTitle, articleYear, articleJournal, articleVolume);
                article.BibCodeOriginal = item.Code;

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
                var masterTitle = String.Empty;
                var masterAuthors = String.Empty;
                var masterYear = 0;
                var masterSchool = String.Empty;

                if (item.Properties.TryGetValue("title", out propertyValue))
                    masterTitle = propertyValue;

                if (item.Properties.TryGetValue("author", out propertyValue))
                    masterAuthors = propertyValue;

                if (item.Properties.TryGetValue("year", out propertyValue))
                    masterYear = Int32.Parse(propertyValue);

                if (item.Properties.TryGetValue("school", out propertyValue))
                    masterSchool = propertyValue;

                var master = new Thesis(
                    masterAuthors.Split(' ')[0],
                    masterAuthors.Split(' ')[1],
                    masterTitle,
                    Thesis.ThesisType.MASTERSTHESIS,
                    masterSchool,
                    masterYear);

                master.BibCodeOriginal = item.Code;
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
                var phdTitle = String.Empty;
                var phdAuthors = String.Empty;
                var phdYear = 0;
                var phdSchool = String.Empty;

                if (item.Properties.TryGetValue("title", out propertyValue))
                    phdTitle = propertyValue;

                if (item.Properties.TryGetValue("author", out propertyValue))
                    phdAuthors = propertyValue;

                if (item.Properties.TryGetValue("year", out propertyValue))
                    phdYear = Int32.Parse(propertyValue);

                if (item.Properties.TryGetValue("school", out propertyValue))
                    phdSchool = propertyValue;

                var phd = new Thesis(
                    phdAuthors.Split(' ')[0],
                    phdAuthors.Split(' ')[1],
                    phdTitle,
                    Thesis.ThesisType.PHDTHESIS,
                    phdSchool,
                    phdYear);

                phd.BibCodeOriginal = item.Code;
                phds.Add(phd);
            }
            return phds;
        }
    }
}