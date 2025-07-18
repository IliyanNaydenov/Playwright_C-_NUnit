using Microsoft.Playwright;

namespace HomeTest.PageObjects
{
    public class HomePage
    {
        public readonly IPage _page;
        public HomePage(IPage page)
        {
            _page = page;
        }

        private ILocator AcceptButton => _page.Locator("//button[@id='cookie-button']");
        private ILocator ProductModule => _page.Locator("//div[@class='row video-slider']");
        public ILocator PlayGameLink => _page.Locator("//h4[text()='Irish Wilds']/parent::div/parent::*//a[contains(@class, 'showreel') and contains(@class, 'play')]");

        public ILocator NextSlideArrow => _page.Locator("//div[@class=\"col-4 center current\"]//button[@aria-label='Next slide']");
        public async Task AcceptCookies()
        {
            if (await AcceptButton.IsVisibleAsync())
            {
                await AcceptButton.ClickAsync();
            }
        }

        public async Task GoToProductsModule()
        {
            await ProductModule.HoverAsync();
        }

        public async Task GotoIrishWildsGame()
        {
            await PlayGameLink.ClickAsync();
        }

        public async Task GotoIrishWildsGameMobile()
        {
            for (int i = 0; i < 50; i++)
            {
                if (await PlayGameLink.IsVisibleAsync())
                {
                    return;
                }
                await NextSlideArrow.ClickAsync();
                await Task.Delay(300);
            }
        }

    }
}
