using HomeTest.Helpers;
using HomeTest.PageObjects;
using HomeTest.Tests;
using Microsoft.Playwright;

namespace HomeTest
{
    [TestFixture]
    [Category("Desktop")]
    public class WinLostDesktopTest : BaseTest
    {
        private HomePage _homePage;

        [SetUp]
        public async Task InitAsync()
        {
            _homePage = new HomePage(Page);
            await NavigateToHomePage();
            await _homePage.AcceptCookies();
        }

        private async Task NavigateToHomePage()
        {
            await Page.GotoAsync(TestConstants.BaseUrl);
            await Expect(Page).ToHaveURLAsync(TestConstants.ExpectedHomeUrl);
        }

        [Test]
        public async Task verifyBalanceWhenBettingSingleSpin()
        {
            await _homePage.GoToProductsModule();

            var newTab = await WaitForNewTab(() => _homePage.GotoIrishWildsGame());
            var gamePage = new GamePage(newTab);

            await gamePage.WaitForGameToLoad();
            await Expect(gamePage.Page).ToHaveTitleAsync(TestConstants.GameName);

            await gamePage.ClickOnPlayButton();

            await Expect(gamePage.Balance).ToHaveTextAsync(TestConstants.DefaultBalance);
            await Expect(gamePage.WinAmount).ToHaveTextAsync(TestConstants.DefaultWinValue);
            await Expect(gamePage.Stake).ToHaveTextAsync(TestConstants.DefaultStakeValue);

            double balanceValue = await GetDouble(gamePage.Balance);

            balanceValue = await PerformSpinAndValidateBalance(gamePage.SpinButton, gamePage.AutoSpinButton, gamePage.Balance, gamePage.Stake, gamePage.WinAmount, balanceValue);
        }


        [Test]
        public async Task verifyBalanceWhenBettingMulti()
        {
            await _homePage.GoToProductsModule();

            var newTab = await WaitForNewTab(() => _homePage.GotoIrishWildsGame());
            var gamePage = new GamePage(newTab);

            await gamePage.WaitForGameToLoad();
            await Expect(gamePage.Page).ToHaveTitleAsync(TestConstants.GameName);

            await gamePage.ClickOnPlayButton();

            await Expect(gamePage.Balance).ToHaveTextAsync(TestConstants.DefaultBalance);
            await Expect(gamePage.WinAmount).ToHaveTextAsync(TestConstants.DefaultWinValue);
            await Expect(gamePage.Stake).ToHaveTextAsync(TestConstants.DefaultStakeValue);

            double balanceValue = await GetDouble(gamePage.Balance);

            balanceValue = await PerformSpinAndValidateBalance(gamePage.SpinButton, gamePage.AutoSpinButton, gamePage.Balance, gamePage.Stake, gamePage.WinAmount, balanceValue);

            for (int i = 0; i < 5; i++)
            {
                balanceValue = await PerformSpinAndValidateBalance(gamePage.SpinButton, gamePage.AutoSpinButton, gamePage.Balance, gamePage.Stake, gamePage.WinAmount, balanceValue);
            }
        }

        [Test]
        public async Task verifyBalanceWhenBettingWithIncreasedStake()
        {
            await _homePage.GoToProductsModule();

            var newTab = await WaitForNewTab(() => _homePage.GotoIrishWildsGame());
            var gamePage = new GamePage(newTab);

            await gamePage.WaitForGameToLoad();
            await Expect(gamePage.Page).ToHaveTitleAsync(TestConstants.GameName);

            await gamePage.ClickOnPlayButton();
            await gamePage.IcreaseStake();

            await Expect(gamePage.Balance).ToHaveTextAsync(TestConstants.DefaultBalance);
            await Expect(gamePage.WinAmount).ToHaveTextAsync(TestConstants.DefaultWinValue);
            await Expect(gamePage.Stake).ToHaveTextAsync("$2.50");

            double balanceValue = await GetDouble(gamePage.Balance);

            balanceValue = await PerformSpinAndValidateBalance(gamePage.SpinButton, gamePage.AutoSpinButton, gamePage.Balance, gamePage.Stake, gamePage.WinAmount, balanceValue);
        }

        [Test]
        public async Task verifyBalanceWhenBettingWithDecreasedStake()
        {
            await _homePage.GoToProductsModule();

            var newTab = await WaitForNewTab(() => _homePage.GotoIrishWildsGame());
            var gamePage = new GamePage(newTab);

            await gamePage.WaitForGameToLoad();
            await Expect(gamePage.Page).ToHaveTitleAsync(TestConstants.GameName);

            await gamePage.ClickOnPlayButton();
            await gamePage.DecreaseStake();

            await Expect(gamePage.Balance).ToHaveTextAsync(TestConstants.DefaultBalance);
            await Expect(gamePage.WinAmount).ToHaveTextAsync(TestConstants.DefaultWinValue);
            await Expect(gamePage.Stake).ToHaveTextAsync(TestConstants.DecreasedStakeValue);

            double balanceValue = await GetDouble(gamePage.Balance);

            balanceValue = await PerformSpinAndValidateBalance(gamePage.SpinButton, gamePage.AutoSpinButton, gamePage.Balance, gamePage.Stake, gamePage.WinAmount, balanceValue);
        }

        [Test]
        public async Task verifyBalanceWhenBettingTwoSpinsWithDifferentStake()
        {
            await _homePage.GoToProductsModule();

            var newTab = await WaitForNewTab(() => _homePage.GotoIrishWildsGame());
            var gamePage = new GamePage(newTab);

            await gamePage.WaitForGameToLoad();
            await Expect(gamePage.Page).ToHaveTitleAsync(TestConstants.GameName);

            await gamePage.ClickOnPlayButton();

            await Expect(gamePage.Balance).ToHaveTextAsync(TestConstants.DefaultBalance);
            await Expect(gamePage.WinAmount).ToHaveTextAsync(TestConstants.DefaultWinValue);
            await Expect(gamePage.Stake).ToHaveTextAsync(TestConstants.DefaultStakeValue);

            double balanceValue = await GetDouble(gamePage.Balance);

            balanceValue = await PerformSpinAndValidateBalance(gamePage.SpinButton, gamePage.AutoSpinButton, gamePage.Balance, gamePage.Stake, gamePage.WinAmount, balanceValue);

            await gamePage.DecreaseStake();

            await Expect(gamePage.Stake).ToHaveTextAsync(TestConstants.DecreasedStakeValue);

            balanceValue = await PerformSpinAndValidateBalance(gamePage.SpinButton, gamePage.AutoSpinButton, gamePage.Balance, gamePage.Stake, gamePage.WinAmount, balanceValue);
        }

        [Test]
        public async Task verifyBalanceWhenBettingThreeSpinsWithDifferentStake()
        {
            await _homePage.GoToProductsModule();

            var newTab = await WaitForNewTab(() => _homePage.GotoIrishWildsGame());
            var gamePage = new GamePage(newTab);

            await gamePage.WaitForGameToLoad();
            await Expect(gamePage.Page).ToHaveTitleAsync(TestConstants.GameName);

            await gamePage.ClickOnPlayButton();

            await Expect(gamePage.Balance).ToHaveTextAsync(TestConstants.DefaultBalance);
            await Expect(gamePage.WinAmount).ToHaveTextAsync(TestConstants.DefaultWinValue);
            await Expect(gamePage.Stake).ToHaveTextAsync(TestConstants.DefaultStakeValue);

            double balanceValue = await GetDouble(gamePage.Balance);

            balanceValue = await PerformSpinAndValidateBalance(gamePage.SpinButton, gamePage.AutoSpinButton, gamePage.Balance, gamePage.Stake, gamePage.WinAmount, balanceValue);

            await gamePage.DecreaseStake();

            await Expect(gamePage.Stake).ToHaveTextAsync(TestConstants.DecreasedStakeValue);

            balanceValue = await PerformSpinAndValidateBalance(gamePage.SpinButton, gamePage.AutoSpinButton, gamePage.Balance, gamePage.Stake, gamePage.WinAmount, balanceValue);

            await gamePage.DecreaseStake();

            await Expect(gamePage.Stake).ToHaveTextAsync("$1.00");

            balanceValue = await PerformSpinAndValidateBalance(gamePage.SpinButton, gamePage.AutoSpinButton, gamePage.Balance, gamePage.Stake, gamePage.WinAmount, balanceValue);

        }

        public async Task<double> GetDouble(ILocator locator)
        {
            string text = await locator.InnerTextAsync();
            string cleanedText = text.Replace("$", "")
                                     .Replace(",", "")
                                     .Trim();

            if (double.TryParse(cleanedText, System.Globalization.NumberStyles.Any,
                                System.Globalization.CultureInfo.InvariantCulture, out double result))
            {
                return result;
            }
            throw new FormatException($"Failed to parse double from text: '{text}'");
        }

        public async Task<double> PerformSpinAndValidateBalance(
    ILocator spinButton,
    ILocator autoSpinButton,
    ILocator balance,
    ILocator stake,
    ILocator winAmount,
    double previousBalance)
        {
            await spinButton.ClickAsync();
            await Expect(autoSpinButton).ToBeEnabledAsync(new LocatorAssertionsToBeEnabledOptions
            {
                Timeout = 25000
            });
            double stakeValue = await GetDouble(stake);
            double winAmountValue = await GetDouble(winAmount);
            if (winAmountValue != 0.00)
            {
                Console.WriteLine($"You Win! : ${winAmountValue:N2}");
            }
            double currentBalance = await GetDouble(balance);
            double expectedBalance = previousBalance - stakeValue + winAmountValue;
            await Expect(balance).ToHaveTextAsync($"${expectedBalance:N2}");

            return expectedBalance;
        }

        public async Task<IPage> WaitForNewTab(Func<Task> actionToOpenTab)
        {
            IPage newTab = null;
            Page.Context.Page += (_, page) => newTab = page;
            await _homePage.GotoIrishWildsGame();

            for (int i = 0; i < 20; i++)
            {
                if (newTab != null) break;
                await Task.Delay(100);
            }
            if (newTab == null)
                throw new Exception("New tab did not open.");

            await newTab.WaitForLoadStateAsync();
            return newTab;
        }
    }
}