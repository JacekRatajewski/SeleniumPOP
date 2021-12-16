
# SeleniumPOP
Me presenting usage of Page Object Pattern with [SeleniumWebdriver](https://www.selenium.dev/documentation/webdriver/) and [NUnit](https://nunit.org/)
Testing Google basic functions of searching fraze and transleting text with:

    WHEN_Writing_Word_In_Search_Box_AND_Clicking_Search_Btn_THEN_Results_Should_Appear()

And

    WHEN_Writing_In_Translator_THEN_Word_Should_Be_Translated()

Used new C# 10 features of:

 - `ArgumentNullException.ThrowIfNull()`
 - `global using`

## What is Page Object Pattern?
Simlpy known as POP, Page Object Pattern is an architecture for getting elements of DOM with high ratio of responsivnes, low cost of maintaining and high reusiblity.

First we create base class called Page witch looks like that:

    public abstract class Page
    {
        public IWebDriver Driver;
        public Page()
        {
            Driver = new ChromeDriver(new ChromeOptions { AcceptInsecureCertificates = true, PageLoadStrategy = PageLoadStrategy.Eager }); ;
        }
        public void Close() => Driver.Dispose();
        public void Url(string url) => Driver.Url = url;
        public void Maximize() => Driver.Manage().Window.FullScreen();
    }
We want to encapsulate functions of IWebDriver, doing it this safe us a lot of refactor and technical debt if our driver changes. Thanks to our Page class we only need to adapt changes here. 

Second we crate class that is called Page Object Model:

    public class SearchPage : Page
    {
        public IWebElement SearchBox => Driver.FindElement(By.CssSelector("[aria-label='Szukaj']"));
        public IWebElement ApproveBtn => Driver.FindElement(By.Id("L2AGLb"));
        public IWebElement SearchBtn => Driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[3]/center/input[1]"));
        public IWebElement ResultStats => Driver.FindElement(By.Id("result-stats"));
    }
Page Object Model is a representation of DOM, it should contain only proparties of IWebElements, and sometimes if our POM is bigger we can encapsulate some methods for accesing specific elements.

With this we can use it inside our test case:

    [TestFixture]
    public class SearchTests
    {
        internal SearchPage SearchPage { get; private set; }

        [SetUp]
        public async Task SetUp()
        {
            SearchPage = new SearchPage();
            SearchPage.Url("https://www.google.com/");
            SearchPage.Maximize();
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
            SearchPage.SearchBox.SendKeys("Test fraze");
            Assert.AreEqual(SearchPage.SearchBox.GetDomProperty("value"), "Test fraze");
            SearchPage.SearchBtn.Click();
            Assert.That(SearchPage.ResultStats.Text, Is.Not.Null);
        }
    }
It's simple example of using Page Object Pattern with SeleniumWebdriver, for more advanced examples, look inside my project ^^

I also implemanted getting data from external json file using my other project: [GenericDispatcher](https://github.com/JacekRatajewski/GenericDispatcher). 
Also other functions like implicit wait for elements usibility.
