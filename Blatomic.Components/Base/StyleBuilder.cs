using Blatomic.Extensions;

namespace Blatomic.Base;

public class StyleBuilder
{
    private string cachedStyle = string.Empty;
    private bool dirty = false;

    private readonly HashSet<string> styles = new HashSet<string>();
    private readonly char delimeter;

    public StyleBuilder(char delimiter)
    {
        delimeter = delimiter;
    }

    public void AddStyle(string stylesToAdd)
    {
        if (stylesToAdd.IsNullOrEmpty())
        {
            return;
        }

        foreach (var style in FormatStyle(stylesToAdd))
        {
            if (styles.Add(style))
            {
                dirty = true;
            }
        }
    }    

    public void RemoveStyle(string stylesToRemove)
    {
        if (stylesToRemove.IsNullOrEmpty())
        {
            return;
        }

        foreach (var style in FormatStyle(stylesToRemove))
        {
            if (styles.Remove(style))
            {
                dirty = true;
            }
        } 
    }

    private IEnumerable<string> FormatStyle(string style)
    {
        style = style.Trim();
        if (style.StartsWith(delimeter))
        {
            style = style.Remove(0);
        }
        if (style.EndsWith(delimeter))
        {
            style = style.Remove(style.Length - 1);
        }
        return style.Split(delimeter);        
    }

    public string Build()
    {
        if (dirty)
        {
            cachedStyle = string.Join(delimeter, styles);
            dirty = false;
        }

        return cachedStyle;
    }
}
