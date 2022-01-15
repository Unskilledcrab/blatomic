using Blatomic.Components.Toasts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blatomic.Services.Toasts
{
    public class ToastService
    {
        public Action<Toast>? OnAddToast;

        public void AddToast(Toast toast)
        {
            OnAddToast?.Invoke(toast);
        }
    }
}
