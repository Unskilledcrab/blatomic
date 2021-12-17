using Blatomic.Effects;
using Blatomic.Extensions;
using Microsoft.AspNetCore.Components;

namespace Blatomic.Base;
public abstract class BaseComponent : ComponentBase
{
    protected string style => styleBuilder.Build();
    protected string css => cssBuilder.Build();

    private StyleBuilder styleBuilder = new StyleBuilder(';');
    private StyleBuilder cssBuilder = new StyleBuilder(' ');

    [Parameter] public string Styles { get; set; } = string.Empty;
    private string cachedStyles { get; set; } = string.Empty;
    [Parameter] public string Css { get; set; } = string.Empty;
    private string cachedCss { get; set; } = string.Empty;

    [Parameter] public HoverEffect HoverEffect { get; set; }
    private HoverEffect cachedHoverEffect { get; set; }
    [Parameter] public RoundedStyle RoundedStyle { get; set; }
    private RoundedStyle cachedRoundedStyle { get; set; }

    protected override void OnParametersSet()
    {
        UpdateInlineStyle(cachedStyles, Styles);
        UpdateCssStyle(cachedCss, Css);

        UpdateCssStyle(cachedHoverEffect.HoverStyle(), HoverEffect.HoverStyle());
        UpdateCssStyle(cachedRoundedStyle.RoundedStyle(), RoundedStyle.RoundedStyle());

        UpdateCache();

        base.OnParametersSet();
    }

    private void UpdateCache()
    {
        cachedStyles = Styles;
        cachedCss = Css;
        cachedHoverEffect = HoverEffect;
        cachedRoundedStyle = RoundedStyle;
    }

    private void AddStyle(StyleBuilder builder, string style)
    {
        if (builder.AddStyle(style))
        {
            StateHasChanged();
        }
    }
    private void RemoveStyle(StyleBuilder builder, string style)
    {
        if (builder.RemoveStyle(style))
        {
            StateHasChanged();
        }
    }

    private void UpdateStyle(StyleBuilder builder, string previousStyle, string updatedStyle)
    {
        if (previousStyle != updatedStyle)
        {
            builder.Remove(previousStyle);
            builder.Add(updatedStyle);
            StateHasChanged();
        }
    }

    public void AddCssStyle(string style)
    {
        AddStyle(cssBuilder, style);
    }

    public void RemoveCssStyle(string style)
    {
        RemoveStyle(cssBuilder, style);
    }

    public void UpdateCssStyle(string previousStyle, string updatedStyle)
    {
        UpdateStyle(cssBuilder, previousStyle, updatedStyle);
    }

    public void AddInlineStyle(string style)
    {
        AddStyle(styleBuilder, style);
    }

    public void RemoveInlineStyle(string style)
    {
        RemoveStyle(styleBuilder, style);
    }

    public void UpdateInlineStyle(string previousStyle, string updatedStyle)
    {
        UpdateStyle(styleBuilder, previousStyle, updatedStyle);
    }
}
