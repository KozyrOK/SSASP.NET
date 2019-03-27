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

        [HttpGet]
        public ViewResult Pricelist()
        {
            Price price = new Price(1);
            return View(price);
        }
        
        [HttpGet]
        public ViewResult PricelistEdit()
        {
            Price price = new Price(1);                     
            return View(price);
        }

        [HttpPost]
        public ViewResult PricelistEdit(Price price)
        {
            price.EditPrice();           
            return View("MainMenu");
        }

        public ViewResult Info()
        {
            return View();
        }
    }
}