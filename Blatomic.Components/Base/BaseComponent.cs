using Blatomic.Extensions;
using Microsoft.AspNetCore.Components;

namespace Blatomic.Base;
public abstract class BaseComponent : ComponentBase
{
    protected string style => styleBuilder.Build();
    protected string css => cssBuilder.Build();

    protected StyleBuilder styleBuilder = new StyleBuilder(';');
    protected StyleBuilder cssBuilder = new StyleBuilder(' ');

    [Parameter] public string Styles { get; set; } = string.Empty;
    [Parameter] public string Css { get; set; } = string.Empty;

    protected override void OnParametersSet()
    {
        styleBuilder.Add(Styles);
        cssBuilder.Add(Css);
        base.OnParametersSet();
    }
}
