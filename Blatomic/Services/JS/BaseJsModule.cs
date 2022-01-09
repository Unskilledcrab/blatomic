using Blatomic.Extensions;
using Microsoft.JSInterop;

namespace Blatomic.Services.JS
{
    public abstract class BaseJsModule
    {
        public BaseJsModule(object componentReference, IJSRuntime JSRuntime)
        {
            this.componentReference = componentReference;
            this.JSRuntime = JSRuntime;
            referenceCount++;
        }

        public BaseJsModule(string wwwrootpath, IJSRuntime JSRuntime)
        {
            this.wwwrootpath = wwwrootpath;
            this.JSRuntime = JSRuntime;
            referenceCount++;
        }

        protected IJSRuntime JSRuntime { get; set; }
        protected IJSObjectReference? module;

        private string? wwwrootpath;
        private object? componentReference;
        private static int referenceCount = 0;

        public async Task Import()
        {
            if (module is null)
            {
                if (wwwrootpath is not null)
                {
                    module = await JSRuntime.Import(wwwrootpath);

                    if (module is null)
                    {
                        throw new FileNotFoundException($"The JS file at ./_content/Blatomic/{wwwrootpath} could not be found");
                    }
                }
                else if (componentReference is not null)
                {
                    module = await JSRuntime.Import(componentReference);

                    if (module is null)
                    {
                        throw new FileNotFoundException($"The JS file for the component {componentReference} could not be found");
                    }
                }
                else
                {
                    throw new ArgumentNullException("wwwroootpath or componentReference", "Importing must have a reference to a path in wwwroot folder or a component so it can get it's JS code behind");
                }
            }
        }

        public async ValueTask DisposeAsync()
        {
            referenceCount--;
            if (referenceCount == 0 && module is not null)
            {
                await module.DisposeAsync();
            }
        }
    }
}
