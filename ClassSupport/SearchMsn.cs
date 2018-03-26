using System;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

//**********************************/
//Author: Jorge Nizama
//Date: March 25, 2018
//Detail: Implementation for Msn using generic search class
//**********************************/

public class SearchMsn : SearchGeneric
{
    public string strEngine = "MSN Search";
    private string UrlOfEngine {get;set;}
    public SearchMsn(string keyword= "") : base(keyword)
    {
        this.UrlOfEngine = @"https://www.bing.com/search?q=XXX"; //MSN
        base.Keyword = keyword;
        
    }
    public override string Search(string keyword) 
    {
        this.UrlOfEngine = UrlOfEngine.Replace("XXX", keyword);
        HtmlWeb web = new HtmlWeb();
        var htmlDoc = web.Load(UrlOfEngine);
        var resultNode = htmlDoc.DocumentNode.SelectNodes("//div/span[@class=\"sb_count\"]");
        string[] valueResult = Regex.Split (resultNode[0].InnerText, @"[^0-9]+");
        Points = Convert.ToInt64(FormatResult(valueResult));
        var finalResult = strEngine + ": " + Points.ToString();
        return finalResult;
    }
   
}