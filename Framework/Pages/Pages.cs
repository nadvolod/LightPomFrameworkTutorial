using OpenQA.Selenium.Support.PageObjects;

namespace Framework.Pages
{

    public static class Pages
    {
                                     //constraint on a parameter   
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

        public static EditProfilePage EditProfile
        {
            get { return GetPage<EditProfilePage>(); }
        }
    }
}