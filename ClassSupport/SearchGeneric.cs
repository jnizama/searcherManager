using System;
//**********************************/
//Author: Jorge Nizama
//Date: March 25, 2018
//Detail: Abstract class to search in enginers search
//**********************************/

public abstract class SearchGeneric
{
    
    public string Keyword {get;set;}
    public string ResultRatio  {get;set;} //Search's Result
    public Int64 Points;
    public SearchGeneric(string keyword )
    {
        this.ResultRatio = "";
        this.Keyword = keyword;
    }
    public virtual string Search(string keyword) //we must override this method
    {
        if(keyword == null)
            keyword = this.Keyword;
        if(keyword == null) throw new Exception("You Should Indicate Keywords to Search");
        
        return "";
    }
    //format text from array
    public string FormatResult(string[] valueResult)
    {
        var resultText = "";
        foreach(var digit in valueResult)
        {
            resultText = resultText + digit;
        }
        return resultText;
    }
}
