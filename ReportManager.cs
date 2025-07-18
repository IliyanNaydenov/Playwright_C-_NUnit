using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace HomeTest
{
    public static class ReportManager
    {
        private static ExtentReports _extent;
        private static ExtentTest _test;

        public static void InitReport()
        {
            var projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\.."));
            var reportsDir = Path.Combine(projectRoot, "Reports");
            Directory.CreateDirectory(reportsDir);

            var reportPath = Path.Combine(reportsDir, "TestReport.html");



            var sparkReporter = new ExtentSparkReporter(reportPath);
            sparkReporter.Config.DocumentTitle = "Playwright Test Report - Iliyan Naydenov";
            sparkReporter.Config.ReportName = "Test Execution Summary";

            _extent = new ExtentReports();
            _extent.AttachReporter(sparkReporter);
        }

        public static void CreateTest(string testName)
        {
            _test = _extent.CreateTest(testName);
        }

        public static void LogInfo(string message)
        {
            _test?.Info(message);
        }

        public static void LogPass(string message)
        {
            _test?.Pass(message);
        }

        public static void LogFailWithScreenshot(string message, string relativeScreenshotPath)
        {
            _test?.Fail(message)
                  .AddScreenCaptureFromPath(relativeScreenshotPath);
        }

        public static void FlushReport()
        {
            _extent?.Flush();
        }
    }
}
