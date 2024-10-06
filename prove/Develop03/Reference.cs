using System;

class Ref
{
    private string _book, _chapter, _verse;

    public Ref (string book, string chapter, string verse)
    {
        _book = book;
        _chapter  = chapter;
        _verse = verse;
    }

    public string toString()
    {
        return string.Format("{0} {1}:{2}", _book, _chapter, _verse);
    }
}