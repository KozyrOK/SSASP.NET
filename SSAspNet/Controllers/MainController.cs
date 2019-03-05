using System.Web.Mvc;
using SSAspNet.Model;

namespace SSAspNet.Controllers
{
    public class MainController : Controller
    {
        public ViewResult MainMenu()
        {            
            return View();
        }
        
        public ViewResult MainPricelist()
        {
            Price price = new Price(1);            
            return View(price);
        }

        [HttpGet]
        public ViewResult MainPricelistEdit()
        {
            Price price = new Price(1);
            return View(price);
        }

        [HttpPost]
        public ViewResult MainPricelistEdit(Price price)
        {
            price.EditPrice();
            return View("MainMenu");
        }

        public ViewResult MainInfo()
        {
            return View("MainInfo");
        }
    }
}
