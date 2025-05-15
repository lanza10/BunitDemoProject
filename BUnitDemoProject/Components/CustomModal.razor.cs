
using Microsoft.AspNetCore.Components;

namespace BUnitDemoProject.Components;

public partial class CustomModal
{
    private bool _isClosed = true;
    [Parameter]
    public string Title { get; set; } = string.Empty;
    [Parameter]
    public string Body { get; set; } = string.Empty;
    
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    public void OpenModal()
    {
        _isClosed = false;
        StateHasChanged();
    }
    private void CloseModal()
    {
        _isClosed = true;
    }
}