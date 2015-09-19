namespace Framework.Pages
{
    public class MyMembershipPage
    {
        public bool IsAt()
        {
            return Browser.Title.Contains("My Membership");
        }
    }
}