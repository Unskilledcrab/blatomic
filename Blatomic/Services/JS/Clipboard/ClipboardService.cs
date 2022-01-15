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
            return Run<string>("CopyToClipboard", content);
        }
    }
}
