using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace HomeTest.Tests
{
    public class BaseTest : PageTest
    {
        [OneTimeSetUp]
        public void GlobalSetup()
        {
            ReportManager.InitReport();
        }

        [SetUp]
        public void BeforeEach()
        {
            ReportManager.CreateTest(TestContext.CurrentContext.Test.Name);
            ReportManager.LogInfo("Test started.");
        }

        [TearDown]
        public async Task AfterEachAsync()
        {
            var outcome = TestContext.CurrentContext.Result.Outcome.Status;
            var testName = TestContext.CurrentContext.Test.Name;

            if (outcome == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                var screenshotsDir = Path.Combine("Reports", "Screenshots");
                Directory.CreateDirectory(screenshotsDir);

                var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                var screenshotFileName = $"{testName}_{timestamp}.png";
                var screenshotPath = Path.Combine(screenshotsDir, screenshotFileName);

                await Page.ScreenshotAsync(new PageScreenshotOptions
                {
                    Path = screenshotPath,
                    FullPage = true
                });
                var relativeScreenshotPath = Path.Combine("Screenshots", screenshotFileName);
                ReportManager.LogFailWithScreenshot("Test failed. See screenshot.", relativeScreenshotPath);
            }
            else if (outcome == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                ReportManager.LogPass("Test passed.");
            }
            else
            {
                ReportManager.LogInfo($"Test finished with status: {outcome}");
            }

            ReportManager.FlushReport();
        }

        public override BrowserNewContextOptions ContextOptions()
        {
            var deviceMode = Environment.GetEnvironmentVariable("DEVICE_MODE")?.ToLower();

            if (deviceMode == "mobile")
            {
                return new BrowserNewContextOptions
                {
                    ViewportSize = new ViewportSize { Width = 390, Height = 844 },
                    UserAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 15_0 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/15.0 Mobile/15E148 Safari/604.1",
                    IsMobile = true,
                    HasTouch = true
                };
            }

            return new BrowserNewContextOptions
            {
                ViewportSize = null
            };
        }
    }
}
