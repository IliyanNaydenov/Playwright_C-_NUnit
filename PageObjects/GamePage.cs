using Microsoft.Playwright;

namespace HomeTest.PageObjects
{
    public class GamePage
    {
        private readonly IPage _page;
        public IPage Page
        {
            get { return _page; }
        }
        public GamePage(IPage page)
        {
            _page = page;
        }
        public ILocator PlayButton => _page.Locator("(//*[@type='button'])[2]");
        public ILocator Balance => _page.Locator("//div[@class='display balance display__wrapper']//span[@class='amount']");
        public ILocator WinAmount => _page.Locator("//div[@class='display win display__wrapper align-center _display-bg-black']//span[@class='amount']");
        public ILocator Stake => _page.Locator("//div[@class='display stake display__wrapper align-center']//span[@class='amount']");
        public ILocator SpinButton => _page.Locator("//button[@class='button button__rounded-xl arrows-spin-button']");
        public ILocator AutoSpinButton => _page.Locator("//button//span[contains(text(),'AUTO')]");
        public ILocator StakeIncrease => _page.Locator("//button[contains(@class, 'button__stake')][2]");
        public ILocator StakeDecrease => _page.Locator("//button[contains(@class, 'button__stake')][1]");


        public async Task ClickOnPlayButton()
        {
            await PlayButton.WaitForAsync(new LocatorWaitForOptions
            {
                State = WaitForSelectorState.Visible,
                Timeout = 50000
            });
            await PlayButton.ClickAsync();
        }

        public async Task WaitForGameToLoad()
        {
            await _page.WaitForLoadStateAsync();
        }

        public async Task IcreaseStake()
        {
            await StakeIncrease.ClickAsync();
        }

        public async Task DecreaseStake()
        {
            await StakeDecrease.ClickAsync();
        }
    }
}
