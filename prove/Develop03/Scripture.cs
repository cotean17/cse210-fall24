using System;

class Scripture
{
    private string _scriptureText;
    private Ref _scriptureRef;

    public Scripture (Ref scriptureRef, string scriptureText)
    {
        _scriptureRef = scriptureRef;
        _scriptureText = scriptureText;
    }

    public string toString()
    {
        return string.Format("{0}", _scriptureText);
    }
}