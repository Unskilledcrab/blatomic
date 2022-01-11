using Blazored.LocalStorage;

namespace Blatomic.Services.ColorScheme
{
    public class ColorPair
    {
        private ILocalStorageService? localStorageService;
        private readonly string key;
        private string lightKey => $"l{key}";
        private string darkKey => $"d{key}";

        public ColorPair()
        {
            key = Guid.NewGuid().ToString();
        }

        public ColorPair(string light, string dark)
        {
            key = $"{light}{dark}";
            this.light = light;
            this.dark = dark;
        }

        private string light = string.Empty;
        public string Light { get => light; }
        private string dark = string.Empty;
        public string Dark { get => dark; }

        public async Task InitalizeAsync(ILocalStorageService localStorageService)
        {
            this.localStorageService = localStorageService;

            if (await localStorageService.ContainKeyAsync(lightKey))
            {
                light = await localStorageService.GetItemAsStringAsync(lightKey);
            }

            if (await localStorageService.ContainKeyAsync(darkKey))
            {
                dark = await localStorageService.GetItemAsStringAsync(darkKey);
            }
        }

        public async Task UpdateLightAsync(string lightClasses)
        {
            if (HasInitalized())
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                await localStorageService.SetItemAsync(lightKey, lightClasses);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
            light = lightClasses;
        }

        public async Task UpdateDarkAsync(string darkClasses)
        {
            if (HasInitalized())
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                await localStorageService.SetItemAsync(darkKey, darkClasses);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
            dark = darkClasses;
        }

        public async Task ResetLightAsync()
        {
            if (HasInitalized())
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                await localStorageService.RemoveItemAsync(lightKey);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
        }

        public async Task ResetDarkAsync()
        {
            if (HasInitalized())
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                await localStorageService.RemoveItemAsync(darkKey);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
        }

        public async Task ResetAsync()
        {
            await ResetLightAsync();
            await ResetDarkAsync();
        }

        private bool HasInitalized()
        {
            if (localStorageService is not null)
            {
                return true;
            }
            throw new NullReferenceException($"{nameof(localStorageService)} has not been initalized. Please initalize this color pair before using or disposing.");
        }

        public override string ToString()
        {
            return $"{Light} {Dark}";
        }
    }
}
