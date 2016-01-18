using System;
using System.Collections.Generic;
using System.IO;

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


        internal static List<BOOK> ExtractBooks(object imported)
        {
            throw new NotImplementedException();
        }

        internal static List<ARTICLE> ExtractArticles(object imported)
        {
            throw new NotImplementedException();
        }

        internal static List<Thesis> ExtractMasters(object imported)
        {
            throw new NotImplementedException();
        }

        internal static List<Thesis> ExtractPhds(object imported)
        {
            throw new NotImplementedException();
        }

    }
}