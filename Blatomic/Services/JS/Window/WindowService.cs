using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blatomic.Services.JS
{
    public class WindowService : BaseJsModule
    {
        public WindowService(IJSRuntime jSRuntime) : base("WindowService.js", jSRuntime)
        {
        }

        public ValueTask DisableTouchScroll()
        {
            return Run("DisableTouchScroll");
        }

        public ValueTask EnableTouchScroll()
        {
            return Run("EnableTouchScroll");
        }

        public ValueTask TouchDragScrollPrevention(ElementReference element)
        {
            return Run("TouchDragScrollPrevention", element);
        }
    }
}
