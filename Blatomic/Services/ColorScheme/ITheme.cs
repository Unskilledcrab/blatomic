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
    }
}