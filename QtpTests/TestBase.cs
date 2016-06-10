using Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QtpTests
{
    [TestClass]
    public class TestBase
    {
        [TestInitialize]
        public void Initialize()
        {
            Browser.Initialize();
        }

        [TestCleanup]
        public void Cleanup()
        {
            Browser.Close();
            Browser.Quit();
        }
    }
}
