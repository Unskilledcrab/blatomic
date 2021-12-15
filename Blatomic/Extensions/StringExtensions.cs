namespace Blatomic.Extensions;

public static class StringExtensions
{
    public static bool IsNullOrEmpty(this string source)
    {
        return source == null || source.Trim().Length == 0;
    }
}
