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
        }

        public BaseJsModule(string wwwrootpath, IJSRuntime JSRuntime)
        {
            this.wwwrootpath = wwwrootpath;
            this.JSRuntime = JSRuntime;
        }

        protected IJSRuntime JSRuntime { get; set; }
        protected IJSObjectReference? module;

        private readonly string? wwwrootpath;
        private readonly object? componentReference;

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

        public async ValueTask Run(string identifier, params object?[]? args)
        {
            await Import();
#pragma warning disable CS8604 // Possible null reference argument.
            await module.InvokeVoidAsync(identifier, args);
#pragma warning restore CS8604 // Possible null reference argument.
        }

        public async ValueTask Run(string identifier, CancellationToken cancellationToken, params object?[]? args)
        {
            await Import();
#pragma warning disable CS8604 // Possible null reference argument.
            await module.InvokeVoidAsync(identifier, cancellationToken, args);
#pragma warning restore CS8604 // Possible null reference argument.
        }

        public async ValueTask Run(string identifier, TimeSpan timeout, params object?[]? args)
        {
            await Import();
#pragma warning disable CS8604 // Possible null reference argument.
            await module.InvokeVoidAsync(identifier, timeout, args);
#pragma warning restore CS8604 // Possible null reference argument.
        }

        public async ValueTask<TValue> Run<TValue>(string identifier, params object?[]? args)
        {
            await Import();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return await module.InvokeAsync<TValue>(identifier, args);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

        public async ValueTask<TValue> Run<TValue>(string identifier, CancellationToken cancellationToken, params object?[]? args)
        {
            await Import();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return await module.InvokeAsync<TValue>(identifier, cancellationToken, args);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

        public async ValueTask<TValue> Run<TValue>(string identifier, TimeSpan timeout, params object?[]? args)
        {
            await Import();
#pragma warning disable CS8604 // Possible null reference argument.
            return await module.InvokeAsync<TValue>(identifier, timeout, args);
#pragma warning restore CS8604 // Possible null reference argument.
        }

        public async ValueTask DisposeAsync()
        {
            if (module is not null)
            {
                await module.DisposeAsync();
            }
        }
    }
}
