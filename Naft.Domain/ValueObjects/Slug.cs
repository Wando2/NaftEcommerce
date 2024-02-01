namespace Naft.Domain.ValueObjects;

public class Slug
{
    public Slug(string slug)
    {
        SlugText = slug;
    }
    
    public string SlugText { get; private set; }
}