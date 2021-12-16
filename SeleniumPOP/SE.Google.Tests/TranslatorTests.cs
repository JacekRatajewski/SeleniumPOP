using SE.Shared.POM.Google;

namespace SE.Google.Tests
{
    [TestFixture]
    public class TranslatorTests
    {
        public TranslatorPage TranslatorPage { get; private set; }

        [SetUp]
        public async Task SetUp()
        {
            TranslatorPage = new TranslatorPage();
            await TranslatorPage.GetData();
            TranslatorPage.Url("https://translate.google.com/");
            TranslatorPage.Maximize();
            TranslatorPage.MaxElementsAwaitTime(10);
        }

        [TearDown]
        public void TearDown()
        {
            TranslatorPage.Close();
        }

        [Test]
        public void WHEN_Writing_In_Translator_THEN_Word_Should_Be_Translated()
        {
            TranslatorPage.ApproveBtn.Click();
            TranslatorPage.SourceTextarea.SendKeys(TranslatorPage.Data.WordToTranslate);
            Assert.AreEqual(TranslatorPage.Data.WordToTranslate, TranslatorPage.SourceTextarea.GetDomProperty("value"));
            Assert.AreEqual(TranslatorPage.Data.TranslatedWord, TranslatorPage.ResultTextarea.Text);
        }
    }
}
