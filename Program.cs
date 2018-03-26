using System;
using System.IO;
using System.Net;
using System.Text;
using HtmlAgilityPack;

namespace searcherLanguage
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0) 
                Console.WriteLine("You should write some programming language to search its ranking");

            try{
            var resultPopularityProgrammingLanguages = SearchManager.PrintPopularityProgrammingLanguages(args);
            Console.WriteLine(resultPopularityProgrammingLanguages);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }
    }
}
