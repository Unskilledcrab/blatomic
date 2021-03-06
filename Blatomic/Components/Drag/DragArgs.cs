using Microsoft.AspNetCore.Components.Web;

namespace Blatomic.Components.Drag
{
    public class DragArgs<TData> : EventArgs
    {
        public DragArgs(TData? data)
        {
            Data = data;
        }
        public DragArgs(TData? data, TouchEventArgs? touchArgs, DragEventArgs? dragArgs)
        {
            Data = data;
            TouchEventArgs = touchArgs;
            DragEventArgs = dragArgs;
        }
        public DragArgs(TouchEventArgs e, TData? data)
        {
            TouchEventArgs = e;
            Data = data;
        }
        public DragArgs(DragEventArgs e, TData? data)
        {
            DragEventArgs = e;
            Data = data;
        }
        public TData? Data { get; set; }
        public DragEventArgs? DragEventArgs { get; set; }
        public TouchEventArgs? TouchEventArgs { get; set; }
    }

    public static class DragArgsExtensions
    {
        public static DragArgs<TData> Create<TData>(this DragEventArgs args, TData data)
        {
            return new DragArgs<TData>(args, data);            
        }
    }
}
