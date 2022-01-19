using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Blatomic.Services.ColorScheme
{
    public class TypeMappingConverter<TType, TImplementation> : JsonConverter<TType>
  where TImplementation : TType
    {
        [return: MaybeNull]
        public override TType Read(
          ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
            JsonSerializer.Deserialize<TImplementation>(ref reader, options);

        public override void Write(
          Utf8JsonWriter writer, TType value, JsonSerializerOptions options) =>
            JsonSerializer.Serialize(writer, (TImplementation)value!, options);
    }

    [JsonConverter(typeof(TypeMappingConverter<ITheme,TwTheme>))]
    public interface ITheme
    {
        Palette Primary { get; set; }
        Palette Light { get; set; }
        Palette Secondary { get; set; }
        Palette Success { get; set; }
        Palette Danger { get; set; }
        Palette Warning { get; set; }
        Palette Info { get; set; }
        Palette Dark { get; set; }
        CustomTheme Custom { get; set; }
        Palette PrimaryOutline { get; set; }
        Palette SecondaryOutline { get; set; }
        Palette SuccessOutline { get; set; }
        Palette DangerOutline { get; set; }
        Palette WarningOutline { get; set; }
        Palette InfoOutline { get; set; }
        Palette LightOutline { get; set; }
        Palette DarkOutline { get; set; }
        Palette Form { get; set; }
        string SaveKey { get; set; }

        void Update(ITheme theme);
    }

    public static class ThemeExtensions
    {
        public static Palette? Get(this ITheme theme, string themeName)
        {
            return theme.Custom.Get(themeName);
        }
        public static ITheme Add(this ITheme theme, string themeName, Palette themePalette)
        {
            theme.Custom.Add(themeName, themePalette);
            return theme;
        }

        public static IEnumerable<(string name, Palette palette)> GetMainPalettes(this ITheme theme)
        {
            yield return (nameof(ITheme.Primary),theme.Primary);
            yield return (nameof(ITheme.Secondary),theme.Secondary);
            yield return (nameof(ITheme.Success),theme.Success);
            yield return (nameof(ITheme.Danger),theme.Danger);
            yield return (nameof(ITheme.Warning),theme.Warning);
            yield return (nameof(ITheme.Info),theme.Info);
            yield return (nameof(ITheme.Light),theme.Light);
            yield return (nameof(ITheme.Dark),theme.Dark);
            yield return (nameof(ITheme.Form), theme.Form);
        }

        public static IEnumerable<(string name, Palette palette)> GetOutlinePalettes(this ITheme theme)
        {
            yield return (nameof(ITheme.PrimaryOutline),theme.PrimaryOutline);
            yield return (nameof(ITheme.SecondaryOutline),theme.SecondaryOutline);
            yield return (nameof(ITheme.SuccessOutline),theme.SuccessOutline);
            yield return (nameof(ITheme.DangerOutline),theme.DangerOutline);
            yield return (nameof(ITheme.WarningOutline),theme.WarningOutline);
            yield return (nameof(ITheme.InfoOutline),theme.InfoOutline);
            yield return (nameof(ITheme.LightOutline),theme.LightOutline);
            yield return (nameof(ITheme.DarkOutline),theme.DarkOutline);
        }

        public static IEnumerable<(string name, Palette palette)> GetCustomPalettes(this ITheme theme)
        {
            return theme.Custom.GetPalettes();
        }

        public static IEnumerable<(string name, Palette palette)> GetAllPalettes(this ITheme theme)
        {
            foreach (var palette in theme.GetMainPalettes())
            {
                yield return palette;
            }
            foreach (var palette in theme.GetOutlinePalettes())
            {
                yield return palette;
            }
            foreach (var palette in theme.GetCustomPalettes())
            {
                yield return palette;
            }
        }

        public static string GetPaletteName(this ITheme theme, Palette? palette)
        {
            if (palette is null)
            {
                return string.Empty;
            }

            foreach (var (name,themePalette) in theme.GetAllPalettes())
            {
                if (themePalette == palette)
                {
                    return name;
                }
            }
            return string.Empty;
        }
    }
}