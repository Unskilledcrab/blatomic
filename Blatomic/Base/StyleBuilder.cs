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

    public string Build()
    {
        if (dirty)
        {
            cachedStyle = string.Join(delimeter, styles);
            dirty = false;
        }

        return cachedStyle;
    }

    public bool AddStyle(string stylesToAdd)
    {
        return UpdateStyle(stylesToAdd, false);
    }    

    public bool RemoveStyle(string stylesToRemove)
    {
        return UpdateStyle(stylesToRemove, true);
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

    private bool UpdateStyle(string stylesToAdd, bool shouldRemove)
    {
        if (stylesToAdd.IsNullOrEmpty())
        {
            return false;
        }

        foreach (var style in FormatStyle(stylesToAdd))
        {
            if (shouldRemove)
            {
                if (styles.Remove(style))
                {
                    dirty = true;
                }
            }
            else
            {
                if (styles.Add(style))
                {
                    dirty = true;
                }
            }
        }
        return dirty;
    }
}
