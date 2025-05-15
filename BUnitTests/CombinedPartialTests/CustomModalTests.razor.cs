using Bunit;
using BUnitDemoProject.Components;
using Xunit;

namespace BUnitTests.CombinedPartialTests;

public partial class CustomModalTests : TestContext
{
    [Fact]
    public void CustomModal_ShouldRenderAsExpected_WhenOpened()
    {
        var cut = RenderComponent<CustomModal>(parameters => parameters
            .Add(m => m.Title, "Test Modal")
            .Add(m => m.Body, "Body Text")
            .AddChildContent("<a>Lorem Ipsum</a>"));

        cut.InvokeAsync(() => cut.Instance.OpenModal());
        
        cut.MarkupMatches(@"<div class=""modal"" style=""display: block; width: 300px; height: 500px;"">
            <h1>Test Modal</h1>
            <p>Body Text</p>
            <a>Lorem Ipsum</a>
            <div class="""">
                <button class=""btn btn-primary"" ></button>
            </div>
            </div>");
    }
}