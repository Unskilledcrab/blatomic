using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blatomic.Services.JS
{
    public class ElementService : BaseJsModule
    {
        public ElementService(IJSRuntime jSRuntime) : base("ElementService.js", jSRuntime)
        {
        }

        public ValueTask<BoundingClientRect> GetBoundingClientRect(ElementReference element)
        {
            if (module is not null)
            {
                return module.InvokeAsync<BoundingClientRect>("GetBoundingClientRect", element);
            }

            throw new NullReferenceException("The javascript module you are referencing is null");
        }
    }
}
