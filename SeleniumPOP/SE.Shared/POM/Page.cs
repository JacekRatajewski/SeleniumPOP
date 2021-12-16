using GenericDispatcher.Core;
using OpenQA.Selenium.Chrome;
using System.Text;

namespace SE.Shared.POM
{
    public class Page<T>
    {
        public IWebDriver Driver;
        private string _dataPath;

        public T? Data { get; private set; }

        public Page(string dataPath)
        {
            ArgumentNullException.ThrowIfNull(dataPath);
            Driver = new ChromeDriver(new ChromeOptions { AcceptInsecureCertificates = true, PageLoadStrategy = PageLoadStrategy.Eager }); ;
            _dataPath = dataPath;
        }
        public void MaxElementsAwaitTime(int seconds) => Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        public void Close() => Driver.Dispose();
        public void Url(string url) => Driver.Url = url;
        public void Maximize() => Driver.Manage().Window.FullScreen();
        public async Task<T> GetData() => Data = await GDispatcher<T>.Dispatch(_dataPath, Encoding.UTF8);
    }
}
