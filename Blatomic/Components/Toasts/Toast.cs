using Blatomic.Services.ColorScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blatomic.Components.Toasts
{
    public class Toast
    {
        public Palette? Palette { get; set; } = null;
        public string Header { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
