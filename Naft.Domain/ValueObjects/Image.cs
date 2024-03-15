namespace Naft.Domain.ValueObjects;

public class Image : ValueObject
{
    public Image(string url)
    {
        Url = url;
    }
    
    public string Url { get; private set; }
}