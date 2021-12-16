using SE.Shared.Data.Models;

namespace SE.Shared.POM.Google
{
    public class SearchPage : Page<SearchData>
    {
        public SearchPage() : base(Path.GetFullPath("..\\..\\..\\..\\SE.Shared\\Data\\Files\\SearchPage.json"))
        {
        }

        public IWebElement SearchBox => Driver.FindElement(By.CssSelector("[aria-label='Szukaj']"));
        public IWebElement ApproveBtn => Driver.FindElement(By.Id("L2AGLb"));
        public IWebElement SearchBtn => Driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[3]/center/input[1]"));
        public IWebElement ResultStats => Driver.FindElement(By.Id("result-stats"));
    }
}
