using Bunit;
using BUnitDemoProject.Pages;
using Xunit;

namespace BUnitTests.CsTests;

public class CounterCsTests : TestContext
{
    public class CounterTests : TestContext
    {
        [Fact]
        public void IncrementCount_ShouldIncrementCurrentCount()
        {
            // Arrange
            var cut = RenderComponent<Counter>();

            // Act
            cut.Find("button").Click();

            // Assert
            var countText = cut.Find("[role='status']").TextContent;
            Assert.Equal("Current count: 1", countText);
        }

        [Fact]
        public void Counter_ShouldRender_AsExpected()
        {
            // Arrange
            var cut = RenderComponent<Counter>();

            // Assert
            cut.MarkupMatches(@"
                <h1>Counter</h1>
                <p role=""status"">Current count: 0</p>
                <button class=""btn btn-primary"">Click me</button>");
        }

        [Fact]
        public void Counter2_ShouldRender_AsExpected()
        {
            // Arrange
            var cut = RenderComponent<Counter2>();

            // Assert
            cut.MarkupMatches(@"
                    <div>
                      <h1>Counter</h1>
                      <p role=""status"">Current count: 0</p>
                      <button class=""btn btn-primary"">Click me</button>
                    </div>");
        }
    }
}