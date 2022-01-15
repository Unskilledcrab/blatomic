﻿using Microsoft.AspNetCore.Components;
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
            return Run<BoundingClientRect>("GetBoundingClientRect", element);
        }
    }
}
