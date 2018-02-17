
using NUnit.Framework;

namespace SauceLabs
{
    [TestFixture]
    [Category("SimpleParallelTestClasses")]
    [Parallelizable]
    public class ParallelSauceExample1 : FirstBaseTest
    {
        [Test]
        public void Test1()
        {
            SetGenderTypes(Gender.Female, Gender.Female);

            SampleAppPage.GoTo();

            SampleAppPage.FillOutEmergencyContactForm(EmergencyContactUser);
            var ultimateQAHomePage = SampleAppPage.FillOutPrimaryContactFormAndSubmit(TheTestUser);
            AssertPageVisible(ultimateQAHomePage);
        }
        [Test]
        public void Test2()
        {
            SetGenderTypes(Gender.Other, Gender.Other);

            SampleAppPage.GoTo();
            SampleAppPage.FillOutEmergencyContactForm(EmergencyContactUser);
            var ultimateQAHomePage = SampleAppPage.FillOutPrimaryContactFormAndSubmit(TheTestUser);
            AssertPageVisibleVariation2(ultimateQAHomePage);
        }
        [Test]
        public void Test3()
        {
            SetGenderTypes(Gender.Other, Gender.Other);

            SampleAppPage.GoTo();
            SampleAppPage.FillOutEmergencyContactForm(EmergencyContactUser);
            var ultimateQAHomePage = SampleAppPage.FillOutPrimaryContactFormAndSubmit(TheTestUser);
            AssertPageVisibleVariation2(ultimateQAHomePage);
        }

    }
    [TestFixture]
    [Category("SimpleParallelTestClasses")]
    [Parallelizable]
    public class ParallelSauceExample2 : FirstBaseTest
    {
        [Test]
        public void Test1()
        {
            SetGenderTypes(Gender.Female, Gender.Female);

            SampleAppPage.GoTo();
            SampleAppPage.FillOutEmergencyContactForm(EmergencyContactUser);
            var ultimateQAHomePage = SampleAppPage.FillOutPrimaryContactFormAndSubmit(TheTestUser);
            AssertPageVisible(ultimateQAHomePage);
        }
        [Test]
        public void Test2()
        {
            SetGenderTypes(Gender.Other, Gender.Other);

            SampleAppPage.GoTo();
            SampleAppPage.FillOutEmergencyContactForm(EmergencyContactUser);
            var ultimateQAHomePage = SampleAppPage.FillOutPrimaryContactFormAndSubmit(TheTestUser);
            AssertPageVisibleVariation2(ultimateQAHomePage);
        }
        [Test]
        public void Test3()
        {
            SetGenderTypes(Gender.Other, Gender.Other);

            SampleAppPage.GoTo();
            SampleAppPage.FillOutEmergencyContactForm(EmergencyContactUser);
            var ultimateQAHomePage = SampleAppPage.FillOutPrimaryContactFormAndSubmit(TheTestUser);
            AssertPageVisibleVariation2(ultimateQAHomePage);
        }

    }

    [TestFixture]
    [Category("SimpleParallelTestClasses")]
    [Parallelizable]
    public class ParallelSauceExample3 : FirstBaseTest
    {
        [Test]
        public void Test1()
        {
            SetGenderTypes(Gender.Female, Gender.Female);

            SampleAppPage.GoTo();
            SampleAppPage.FillOutEmergencyContactForm(EmergencyContactUser);
            var ultimateQAHomePage = SampleAppPage.FillOutPrimaryContactFormAndSubmit(TheTestUser);
            AssertPageVisible(ultimateQAHomePage);
        }
    }
    [TestFixture]
    [Category("SimpleParallelTestClasses")]
    [Parallelizable]
    public class ParallelSauceExample4 : FirstBaseTest
    {
        [Test]
        public void Test1()
        {
            SetGenderTypes(Gender.Female, Gender.Female);

            SampleAppPage.GoTo();
            SampleAppPage.FillOutEmergencyContactForm(EmergencyContactUser);
            var ultimateQAHomePage = SampleAppPage.FillOutPrimaryContactFormAndSubmit(TheTestUser);
            AssertPageVisible(ultimateQAHomePage);
        }
    }
}
