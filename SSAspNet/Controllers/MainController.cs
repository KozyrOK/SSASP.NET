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

        [HttpPost]
        public ViewResult Pricelist(Price price)
        {
            Price newprice = new Price
            {
                CarBody = price.CarBody,
                CarWheels = price.CarWheels,
                CarEngine = price.CarEngine,
                CarBrakes = price.CarBrakes,
                CarUndercarriage = price.CarUndercarriage,
                BusSalon = price.BusSalon,
                BusHandsrails = price.BusHandsrails,
                BusUpholstery = price.BusUpholstery,
                PasCarwheelBalancing = price.PasCarwheelBalancing,
                TruckHydraulics = price.TruckHydraulics
            };
            return View("~/Views/Main/PricelistEdit.cshtml", newprice);
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
