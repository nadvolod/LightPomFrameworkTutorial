using Framework;
using NUnit;
using NUnit.Framework;

namespace QtpTests
{
    [TestFixture]
    public class TestBase
    {
        [SetUp]
        public static void Setup()
        {
            Browser.Initialize();
        }

        [TearDown]
        public static void Cleanup()
        {
            Browser.Close();
            Browser.Quit();
        }

        [OneTimeTearDown]
        public static void FinalClean()
        {
            Browser.Quit();
        }
    }
}
