using Framework.Pages;
using NUnit.Framework;

namespace QtpTests
{
    [TestFixture]
    public class SmokeTests : TestBase
    {
        [Test]
        [Category("loginPage")]
        public void TestMethod1()
        {
            Pages.Login.Goto();
            Assert.IsTrue(false);
        }

        [Test]
        public void Test2()
        {
            Pages.Login.Goto();
            Pages.Login.LoginWithoutClef("test", "test");
        }

        [Test]
        public void Test3()
        {
            Pages.Login.Goto();
            Pages.Login.LoginWithoutClef("seleniumTestUser", "Test12345!!$");
        }
    }
}
