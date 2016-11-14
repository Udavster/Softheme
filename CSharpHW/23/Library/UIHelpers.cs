using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Library
{
    static class UIHelpers
    {
        public static IEnumerable<XElement> Searching(XLibDocument document)
        {
            IEnumerable<XElement> elements = null;
            while (true)
            {
                if (elements != null)
                {
                    Console.WriteLine("Enter f to filter results, or e to exit");
                    var control = Console.ReadLine().Trim().ToLower();
                    switch (control)
                    {
                        case "e":
                            return elements;
                        case "f":
                            break;
                        default:
                            continue;
                    }
                    Console.WriteLine("What do you want to filter by? (author, tiltle, price)");
                } else
                {
                    Console.WriteLine("What do you want to search by? (author, tiltle, price)");
                }

                string by = Console.ReadLine();
                Console.WriteLine("What should the {0} be?", by);
                string value = Console.ReadLine();
                if (elements == null)
                {
                    elements = document.Filter(by, value);
                } else
                {
                    elements = XLibDocument.Filter(elements, by, value);
                }

                ShowResults(elements);
            }
        }

        public static void ShowResults(IEnumerable<XElement> elements)
        {
            XElement[] results;
            if ((elements == null) ||
                ((results = elements.ToArray()).Length == 0))
            {
                Console.WriteLine("0 elements");
                return;
            }

            try
            {
                for (int i = 0; i < results.Length; i++, Console.WriteLine())
                {
                    Console.WriteLine("Title: {0}, Author: {1}\n" +
                    "Price: {2},\n Description: {3}",
                        results[i].Attribute("name").Value, results[i].Attribute("author").Value,
                        results[i].Element("price").Value, results[i].Element("desc").Value);
                }
            } catch (NullReferenceException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nXML structure is corrupted or not from current program.");
                Console.ResetColor();

                throw new ArgumentException("XML structure not valid");
            }
        }

        public static XLibDocument AddBook(XLibDocument document)
        {
            Console.WriteLine("Enter authors name");
            string author = Console.ReadLine();
            
            Console.WriteLine("Enter book title:");
            string title = Console.ReadLine();
            
            Console.WriteLine("Enter book description:");
            string desc = Console.ReadLine();
            
            int price = 0;
            string sPrice = "";
            do
            {
                Console.WriteLine("Enter book price:");
                sPrice = Console.ReadLine();
            } while (!int.TryParse(sPrice, out price));

            document.AddBook(title, author, desc, price);
            return document;
        }
        public static void Flow(XLibDocument document)
        {
            document = (document == null) ? new XLibDocument() : document;

            while (true)
            {
                Console.WriteLine("What to do next? ( 0 - open file, 1 - search, 2 - save" +
                    " 3 - show all, 4 - add, 5 - remove, 6 - exit)");
                string variant = Console.ReadLine();
                Console.Clear();

                switch (variant)
                {
                    case "0":
                        Console.WriteLine("Enter path:");
                        document.Open(Console.ReadLine(), prevIfFail: true);
                        break;

                    case "1":
                        UIHelpers.Searching(document);
                        break;

                    case "2":
                        Console.WriteLine("Enter filename and path");
                        document.Save(Console.ReadLine());
                        break;

                    case "3":
                        try
                        {
                            UIHelpers.ShowResults(document.Books);
                        } catch (ArgumentException)
                        {
                            document = new XLibDocument();
                            Console.WriteLine("Current document flushed");
                        }
                        break;

                    case "4":
                        document = UIHelpers.AddBook(document);
                        Console.WriteLine("Added");
                        break;

                    case "5":
                        Console.WriteLine("Find which books to remove");
                        document.RemoveBooks(UIHelpers.Searching(document));
                        Console.WriteLine("Removed successfully");
                        break;

                    case "6":
                        return;

                    default:
                        Console.WriteLine("Wrong input - please open a number from 0 to 4 or 5 to exit");
                        break;
                }

            }
        }


    }

}
