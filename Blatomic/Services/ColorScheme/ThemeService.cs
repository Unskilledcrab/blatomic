using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blatomic.Services.ColorScheme
{
    public class ThemeService
    {
        private ITheme theme;

        public ThemeService(ITheme theme)
        {
            this.theme = theme;
        }

        public Action<bool>? OnModeToggle { get; set; }
        public Func<ITheme,Task>? OnSaveTheme { get; set; }
        public bool IsDarkMode { get; set; } = true;
        public void DarkMode()
        {
            if (IsDarkMode)
            {
                return;
            }
            IsDarkMode = true;
            OnModeToggle?.Invoke(true);
        }

        public void LightMode()
        {
            if (!IsDarkMode)
            {
                return;
            }
            IsDarkMode = false;
            OnModeToggle?.Invoke(false);
        }

        public void ToggleMode()
        {
            IsDarkMode = !IsDarkMode;
            OnModeToggle?.Invoke(IsDarkMode);
        }

        public Task UpdateTheme(Action<ITheme> action)
        {
            action(theme);
            return SaveThemeAsync(theme);
        }

        public Task SaveThemeAsync(ITheme theme)
        {
            if (OnSaveTheme is not null)
            {
                return OnSaveTheme.Invoke(theme);
            }
            return Task.CompletedTask;
        }
    }
}
