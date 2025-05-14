using Bunit;
using BUnitDemoProject.Pages;
using Xunit;

namespace BUnitTests.CsTests;

public class HomeCsTests : TestContext
{
    [Fact]
    public void Home_ShouldRenderAsExpected()
    {
        // Arrange
        // cut == "Component Under Test"
        var cut = RenderComponent<Home>();

        // Assert
        cut.MarkupMatches(@"
                            <h1>Hello, world!</h1>
                            Welcome to your new app.");
    }

    [Fact]
    public void Home2_ShouldRenderAsExpected()
    {
        // Arrange
        var cut = RenderComponent<Home2>();

        // Assert
        cut.MarkupMatches(@"
                            <h1>Counter</h1>
                            <p role=""status"">Current count: 0</p>
                            <button class=""btn btn-primary"" >Click me</button>
                            <h1>Hello, world!</h1>
                            Welcome to your new app.");
    }
}