using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Library
{
    class XLibDocument
    {
        public const string stdFileName = "./lib.xml";
        private XDocument document;

        public XLibDocument()
        {
            document = new XDocument(new XElement("books"));
        }

        public IEnumerable<XElement> Books
        {
            get
            {
                if (document == null)
                {
                    return null;
                }
                return document.Root.Descendants("book");
            }
        }

        public void AddBook(string name, string author, string description, int price)
        {
            CheckDocument(document);
            var book = new XElement("book");
            book.Add(new XAttribute("author", author));
            book.Add(new XAttribute("name", name));
            book.Add(new XElement("price", price));
            book.Add(new XElement("desc", description));
            document.Element("books").Add(book);
        }
        public void RemoveBooks(IEnumerable<XElement> elements)
        {
            var books = elements.ToArray();
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] == null) continue;
                books[i].Remove();
            }
        }
        private void CheckDocument(XDocument document)
        {
            if (document == null)
            {
                document = new XDocument(new XElement("books"));
                return;
            }
            if (document.Element("books") == null)
            {
                document = new XDocument(new XElement("books"));
            }
        }
        public void Save(string path)
        {
            if (path.Trim() == "") path = stdFileName;
            try
            {
                using (System.IO.Stream stream = File.Create(path))
                {
                    document.Save(stream);
                }
            } catch (IOException)
            {
                Console.WriteLine("Invalid path or don't have access.");
            } catch (Exception)
            {
                Console.WriteLine("Error");
            }
        }
        public void Open(string path, bool prevIfFail = false)
        {
            if (path.Trim() == "") path = stdFileName;
            try
            {
                using (System.IO.Stream stream = File.OpenRead(path))
                {
                    document = XDocument.Load(stream);
                }
            } catch (System.Xml.XmlException)
            {
                Console.WriteLine("Exception. The file is not xml or corrupted ({0})", path);
                if (!prevIfFail)
                {
                    document = null;
                }
                return;
            } catch (Exception)
            {
                Console.WriteLine("Exception. The file wasn't opened ({0})", path);
                if (!prevIfFail)
                {
                    document = null;
                }
                return;
            }
        }

        public IEnumerable<XElement> Search(Predicate<XElement> predicate)
        {
            if (document == null) return null;
            return document.Root.Descendants("book").Where(book => predicate(book));
        }
        public static IEnumerable<XElement> Search(IEnumerable<XElement> books, Predicate<XElement> predicate)
        {
            if (books == null) return null;
            return books.Where(book => predicate(book));
        }
        public static IEnumerable<XElement> Filter(IEnumerable<XElement> collection, string by, string value)
        {
            if (collection == null)
            {
                return null;
            }

            switch (by.ToLower())
            {
                case "name":
                    return Search(collection, book => ((string)book.Attribute("title") == value));
                case "author":
                    return Search(collection, book => (((string)book.Attribute("author")) == value));
                case "price":
                    return Search(collection, book => ((string)book.Element("price") == value));
                default:
                    Console.WriteLine("Wrong attribute/element name - {0}", by);
                    return null;
            }
        }
        public IEnumerable<XElement> Filter(string by, string value)
        {
            IEnumerable<XElement> collection = null;
            if (document != null)
            {
                collection = document.Root.Descendants("book");
            }
            return XLibDocument.Filter(collection, by, value);
        }
    }
}
