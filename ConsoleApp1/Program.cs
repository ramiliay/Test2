using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            intersect_();
        }


        //String matching
        private static void intersect_()
{
            string input = "Net a Amount";
            string needle = "Net a Amount";

            string regex = Regex.Escape(needle).Replace(@"\ ", @"\s*");
            bool isMatch = Regex.IsMatch(input, regex, RegexOptions.IgnoreCase);
            Console.WriteLine("isMatch: {0}", isMatch);

            string text = "C# is the best language there is in the world.";
            string search = "the";
            MatchCollection matches = Regex.Matches(text, search);
            Console.WriteLine("there was {0} matches for '{1}'", matches.Count, search);

 
        


            Console.ReadKey();
        }

        // How to query for sentences that contain a specified set of words(LINQ) (C#)
        private static void intersect()
        {

            //   How to query for sentences that contain a specified set of words(LINQ)(C#)


            string text = @"Historically, the world of data and the world of objects " +
            @"have not been well integrated. Programmers work in C# or Visual Basic " +
            @"and also in SQL or XQuery. On the one side are concepts such as classes, " +
            @"objects, fields, inheritance, and .NET APIs. On the other side " +
            @"are tables, columns, rows, nodes, and separate languages for dealing with " +
            @"them. Data types often require translation between the two worlds; there are " +
            @"different standard functions. Because the object world has no notion of query, a " +
            @"query can only be represented as a string without compile-time type checking or " +
            @"IntelliSense support in the IDE. Transferring data from SQL tables or XML trees to " +
            @"objects in memory is often tedious and error-prone.";

            // Split the text block into an array of sentences.  
            string[] sentences = text.Split(new char[] { '.', '?', '!' });

            // Define the search terms. This list could also be dynamically populated at run time.  
            string[] wordsToMatch = { "Historically", "data", "integrated" };

            // Find sentences that contain all the terms in the wordsToMatch array.  
            // Note that the number of terms to match is not specified at compile time.  
            var sentenceQuery = from sentence in sentences
                                let w = sentence.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' },
                                                        StringSplitOptions.RemoveEmptyEntries)
                                where w.Distinct().Intersect(wordsToMatch).Count() == wordsToMatch.Count() // llllllllllllllllllllllllllllllll
                                select sentence;

            // Execute the query. Note that you can explicitly type  
            // the iteration variable here even though sentenceQuery  
            // was implicitly typed.
            foreach (string str in sentenceQuery)
            {
                Console.WriteLine(str);
            }

            // Keep the console window open in debug mode.  
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

    }
}
