using Microsoft.JSInterop;

namespace Blatomic.Extensions
{
    internal static class JSRuntimeExtensions
    {
        internal static async Task<IJSObjectReference> Import<T>(this IJSRuntime jsRuntime, T instance)
        {
            var path = instance!.GetType().FullName!.Replace('.', '/');
            var module = await jsRuntime.InvokeAsync<IJSObjectReference>(
                "import",
                Path.Combine($"./_content/", $"{path}.razor.js")
            );
            return module;
        }

        internal static async Task<IJSObjectReference> Import(this IJSRuntime jsRuntime, string wwwrootpath)
        {
            var module = await jsRuntime.InvokeAsync<IJSObjectReference>(
                "import",
                Path.Combine($"./_content/Blatomic/", wwwrootpath)
            );
            return module;
        }
    }
}
