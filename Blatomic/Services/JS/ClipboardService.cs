using Microsoft.JSInterop;

namespace Blatomic.Services.JS
{
    public class ClipboardService : BaseJsModule
    {
        public ClipboardService(IJSRuntime jSRuntime) : base("ClipboardService.js", jSRuntime)
        {
        }

        public ValueTask<string> CopyToClipboard(string content)
        {
            if (module is not null)
            {
                return module.InvokeAsync<string>("CopyToClipboard", content);
            }

            throw new NullReferenceException("The javascript module you are referencing is null");
        }
    }
}
