using Microsoft.AspNetCore.Components.Web;

namespace Blatomic.Components.Drag
{
    public class DragArgs<TData> : EventArgs
    {
        public DragArgs(TData data)
        {
            Data = data;
        }
        public DragArgs(DragEventArgs e, TData data)
        {
            DragEventArgs = e;
            Data = data;
        }
        public TData? Data { get; set; }
        public DragEventArgs? DragEventArgs { get; set; }
    }

    public static class DragArgsExtensions
    {
        public static DragArgs<TData> Create<TData>(this DragEventArgs args, TData data)
        {
            return new DragArgs<TData>(args, data);            
        }
    }
}
