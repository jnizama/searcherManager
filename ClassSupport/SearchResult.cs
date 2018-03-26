using System;

public class SearchResult
{
    public SearchResult(string Engine,string Keyword,Int64 Points)
    {
        this.Engine = Engine;
        this.Keyword = Keyword;
        this.Points = Points;
    }
    public Int64 Points {get;set;}
    public string Keyword {get;set;}
    public string Engine {get;set;}
}