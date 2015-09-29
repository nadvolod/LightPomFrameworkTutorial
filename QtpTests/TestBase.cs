using Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QtpTests
{
    public class TestBase
    {
        [TestInitialize]
        public static void Initialize()
        {
            Browser.Initialize();
        }

        [TestCleanup]
        public static void Cleanup()
        {
            Browser.Close();
            //Browser.Quit();
        }
    }
}
