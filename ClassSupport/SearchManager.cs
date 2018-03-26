using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

//**********************************/
//Author: Jorge Nizama
//Date: March 25, 2018
//Detail: class to handle engines searchs objects. Some objects are handle with LINQ for objects
//**********************************/
public class SearchManager
{
    //Save in a StrinBuilder object the results  (in this case programming languages)
    public static string PrintPopularityProgrammingLanguages(string[] keywords)
    {
        var response = new StringBuilder();
        var searchResult = new List<SearchResult>(); //containing results of searches.
        try{
        foreach(var keyword in keywords)
        {
            var searchGoogle = new SearchGoogle();
            var searchMsn = new SearchMsn();
            var resultGoogle = searchGoogle.Search(keyword);
            var resultMsn = searchMsn.Search(keyword);
            response.AppendLine(keyword + ": " + resultGoogle + " " + resultMsn); //we can use concat c# function string too
            searchResult.Add(new SearchResult(searchGoogle.strEngine, keyword, searchGoogle.Points));
            searchResult.Add(new SearchResult(searchMsn.strEngine, keyword, searchMsn.Points));
        }
        
        var enginers = searchResult.Select(x=>x.Engine).Distinct();
        foreach(var engine in enginers)
        {
            var winner = searchResult.Select(i=> new { i.Keyword, i.Points, i.Engine }).Where(x=>x.Engine == engine).OrderByDescending(m=>m.Points).FirstOrDefault().Keyword;
            response.AppendLine(engine + " winner: " + winner );
            winner = searchResult.Select(i=> new { i.Keyword, i.Points, i.Engine }).OrderByDescending(m=>m.Points).FirstOrDefault().Keyword;
            response.AppendLine("Total winner: " + winner );

        }
        }catch(Exception ){
            response.Clear();
            response.Append("You should provide valid keywords");
        }
        
        return response.ToString();
        
    }
}