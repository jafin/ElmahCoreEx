namespace ElmahCore.Mvc;

public struct HtmlChunk
{
    public HtmlChunk(int index, int end, string html)
    {
        Index = index;
        End = end;
        Html = html;
    }

    public int Index { get; set; }

    public int End { get; set; }

    public string Html { get; set; }
}