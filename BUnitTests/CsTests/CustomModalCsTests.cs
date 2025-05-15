using System.Net.Mime;
using Bunit;
using BUnitDemoProject.Components;
using Xunit;

namespace BUnitTests.CsTests;

public class CustomModalCsTests : TestContext
{
    [Fact]
    public void CustomModal_ShouldRenderAsExpected()
    {
        // Arrange
        var cut = RenderComponent<CustomModal>(parameters => parameters
            .Add(m => m.Title, "Test Modal")
            .Add(m => m.Body, "Body Text")
            .AddChildContent("<a>Lorem Ipsum</a>"));
            
        // Assert
        cut.MarkupMatches(@"<div class=""modal"" style=""display: none; width: 300px; height: 500px;"">
            <h1>Test Modal</h1>
            <p>Body Text</p>
            <a>Lorem Ipsum</a>
            <div class="""">
                <button class=""btn btn-primary"" ></button>
            </div>
            </div>");
    }
}