namespace Blatomic.Effects
{
    public abstract class BaseEffect<T>
    {
        public T? Effect { get; set; }
        public string CachedStyle { get; set; } = string.Empty;
        public abstract string GetStyle { get; }
        public void UpdateCache()
        {
            CachedStyle = GetStyle;
        }
    }
}
