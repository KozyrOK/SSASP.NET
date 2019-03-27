using SSAspNet.Model;
using System.Web.Mvc;

namespace SSAspNet.Controllers
{
    public class NewOrderController : Controller
    {
        [HttpGet]
        public ActionResult SelectNewOrder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SelectNewOrder(FormCollection coll)
        {
            string car = coll["Car"].ToString();
            if (car == "PasCar")                           
                return View("~/Views/NewOrder/NewOrderPasCar.cshtml");                            
            else if (car == "Truck")
                return View("~/Views/NewOrder/NewOrderTruck.cshtml");
            else if (car == "Bus")
                return View("~/Views/NewOrder/NewOrderBus.cshtml");
            else
                return View();
        }

        [HttpPost]
        public ActionResult NewOrderPasCar(PasCarServiceStation car)
        {            
            Order order = new Order();
            car.FillOrder(ref order);
            order.AddNewOrder();
            order.GetLastOrderId();
            return View("~/Views/NewOrder/OrderResult.cshtml", order);
        }
        
        [HttpPost]
        public ActionResult NewOrderTruck(TruckCarServiceStation car)
        {
            Order order = new Order();
            car.FillOrder(ref order);
            order.AddNewOrder();
            order.GetLastOrderId();
            return View("~/Views/NewOrder/OrderResult.cshtml", order);
        }        

        [HttpPost]
        public ActionResult NewOrderBus(BusCarServiceStation car)
        {
            Order order = new Order();
            car.FillOrder(ref order);
            order.AddNewOrder();
            order.GetLastOrderId();
            return View("~/Views/NewOrder/OrderResult.cshtml", order);
        }
    }
}
