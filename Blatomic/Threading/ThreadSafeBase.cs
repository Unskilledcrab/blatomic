namespace Blatomic.Threading
{
    public class ThreadSafeBase
    {
        protected readonly object _lock = new object();
    }
}