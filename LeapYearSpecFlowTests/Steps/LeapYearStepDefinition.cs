using Bunit;
using LeapYearKata.Blazor;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using Xunit;
using Index = LeapYearKata.Blazor.Pages.Index;

namespace LeapYearSpecFlowTests.Steps;

[Binding]
public class LeapYearStepDefinition : IDisposable
{
   private readonly TestContext _ctx = new();
   private IRenderedComponent<Index> _page = null!;

   [Given(@"I am on the start page")]
   public void GivenIAmOnTheIndexPage()
   {
      _ctx.Services.AddSingleton<LeapYearService>();
      _page = _ctx.RenderComponent<Index>();
   } 
   
   [When(@"I enter year '(.*)' into the input")]
   public void WhenIEnterIntoTheYearInput(string year)
   {
      var yearInput = _page.Find("input[type='text']");
      yearInput.Change(year);
   }

   [When(@"I click the 'Check' button")]
   public void WhenIClickTheCheckButton()
   {
      var checkButton = _page.Find("button:contains('Check')");
      checkButton.Click();
   }

   [Then(@"I should see a red banner")]
   public void ThenIShouldSeeARedBanner()
   {
      var banner = _page.FindComponent<MudAlert>();
      Assert.NotNull(banner);
      Assert.Equal(Severity.Error,banner.Instance.Severity);
   }

   [Then(@"I should see a green banner")]
   public void ThenIShouldSeeAGreenBanner()
   {
      var banner = _page.FindComponent<MudAlert>();
      Assert.NotNull(banner);
      Assert.Equal(Severity.Success, banner.Instance.Severity);
   }
   
   [Then(@"the banner should read '(.*)'")]
   public void ThenTheBannerShouldRead(string expectedText)
   {
      var banner = _page.FindComponent<MudAlert>();
      var renderedContent = _ctx.Render(banner.Instance.ChildContent);
      Assert.Equal(expectedText, renderedContent.Markup.Trim());
   }
   public void Dispose()
   {
      _ctx.Dispose();
      _page.Dispose();
   }

}
