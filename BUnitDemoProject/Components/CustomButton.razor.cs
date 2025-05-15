using Microsoft.AspNetCore.Components;

namespace BUnitDemoProject.Components;

public partial class CustomButton
{
    [Parameter] public string Text { get; set; } = string.Empty;
    [Parameter] public string ButtonCss { get; set; } = string.Empty;
    
    [Parameter] public string ContainerCss { get; set; } = string.Empty;
    
    [Parameter] public EventCallback OnClick { get; set; }
    
    [Parameter] public bool Disabled { get; set; }
    
    private async Task HandleClick()
    {
        if (OnClick.HasDelegate)
        {
            await OnClick.InvokeAsync();
        }
    }
}