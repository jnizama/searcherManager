using System;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

//**********************************/
//Author: Jorge Nizama
//Date: March 25, 2018
//Detail: Implementation for Google using generic search class
//        it use HtmlAgilityPack library to extract result.
//**********************************/
public class SearchGoogle : SearchGeneric
{
    public string strEngine = "Google";
    private string UrlOfEngine {get;set;}
    public SearchGoogle(string keyword = "") : base(keyword)
    {
        this.UrlOfEngine = @"https://www.google.com/search?dcr=0&source=hp&q=XXX&oq=XXX";
        base.Keyword = keyword;
    }
    ///Search in enginner search information of results using HtmlAgilityPack library
    
    public override string Search(string keyword) 
    {
        
            this.UrlOfEngine = UrlOfEngine.Replace("XXX", keyword);
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(UrlOfEngine);
            var resultNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@id='resultStats']"); //I use a markup HTML identifier
            string[] valueResult = Regex.Split (resultNode.InnerText, @"[^0-9\.]+"); //replace XXX by the keyword provider by user
            Points = Convert.ToInt64(FormatResult(valueResult));  //I use Integer64 to support biggest number result
            var finalResult = strEngine + ": " + FormatResult(valueResult);
            return finalResult;
        
        
        
    }
    
}