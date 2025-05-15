using Bunit;
using BUnitDemoProject.Components;
using Xunit;

namespace BUnitTests.CsTests;

public class CustomButtonCsTests : TestContext
{
    [Fact]
    public void CustomButton_ShouldRenderAsExpected()
    {
        // Arrange
        var cut = RenderComponent<CustomButton>(parameters => parameters
            .Add(cb => cb.Text, "Click me")
            .Add(cb => cb.ButtonCss, "btn-primary")
            .Add(cb => cb.Disabled, true));
        
        
        

        // Assert
        cut.MarkupMatches(@"<div class="""">
                                        <button disabled="""" class=""btn btn-primary"">Click me</button>
                                    </div>");
    }
    
    [Fact]
    public void CustomButton_ShouldExecuteExpectedMethod()
    {
        var test = 0;
        Action onClick = () => { test += 10; };

        var cut = RenderComponent<CustomButton>(parameters => parameters
            .Add(cb => cb.Text, "Click me")
            .Add(cb => cb.ButtonCss, "btn-primary")
            .Add(cb => cb.OnClick, onClick));
        
        cut.Find("button").Click();
        Assert.Equal(10, test);
        
        cut.Find("button").Click();
        cut.Find("button").Click();
        Assert.Equal(30, test);
        
        cut.Find("button").MarkupMatches(@"<button class=""btn btn-primary"">Click me</button>");
        
    }
}