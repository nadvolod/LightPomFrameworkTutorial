using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Xml;
using OpenQA.Selenium.Support.PageObjects;

namespace Framework.Pages
{

    public static class Pages
    {
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(Browser.Driver, page);
            return page;
        }

        public static LoginPage Login
        {
            get { return GetPage<LoginPage>(); }
        }

        public static MyMembershipPage MyMembership
        {
            get { return GetPage<MyMembershipPage>(); }
        }
    }
}