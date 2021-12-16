using SE.Shared.POM.Google;

namespace SE.Google.Tests
{
    [TestFixture]
    public class SearchTests
    {
        internal SearchPage SearchPage { get; private set; }

        [SetUp]
        public async Task SetUp()
        {
            SearchPage = new SearchPage();
            await SearchPage.GetData();
            SearchPage.Url("https://www.google.com/");
            SearchPage.Maximize();
            SearchPage.MaxElementsAwaitTime(10);
        }

        [TearDown]
        public void TearDown()
        {
            SearchPage.Close();
        }

        [Test]
        public void WHEN_Writing_Word_In_Search_Box_AND_Clicking_Search_Btn_THEN_Results_Should_Appear()
        {
            SearchPage.ApproveBtn.Click();
            SearchPage.SearchBox.SendKeys(SearchPage.Data.SearchFraze);
            Assert.AreEqual(SearchPage.SearchBox.GetDomProperty("value"), SearchPage.Data.SearchFraze);
            SearchPage.SearchBtn.Click();
            Assert.That(SearchPage.ResultStats.Text, Is.Not.Null);
        }
    }
}
