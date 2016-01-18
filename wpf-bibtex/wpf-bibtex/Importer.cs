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

            using (var f = new StreamReader(v))
            {
                while (!f.EndOfStream)
                {
                    // catch start of entry (starts with @)
                    // read in type and code

                    // while not end of entry (== "}")
                    // read in properties: 
                    // parse "     property = {propertyValue}"
                    // save into dictionary[property] = propertyValue

                }
            }

            return result;
        }

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