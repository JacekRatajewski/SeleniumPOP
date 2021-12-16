using SE.Shared.Data.Models;

namespace SE.Shared.POM.Google
{
    public class TranslatorPage : Page<TranslatorData>
    {
        public TranslatorPage() : base(Path.GetFullPath("..\\..\\..\\..\\SE.Shared\\Data\\Files\\TranslatorPage.json"))
        {
        }

        public IWebElement ApproveBtn => Driver.FindElement(By.XPath("//*[@id='yDmH0d']/c-wiz/div/div/div/div[2]/div[1]/div[4]/form/div/div/button/span"));
        public IWebElement SourceTextarea => Driver.FindElement(By.CssSelector("[aria-label='Tekst źródłowy']"));
        public IWebElement ResultTextarea => Driver.FindElement(By.CssSelector("[jsname='W297wb']"));
    }
}
