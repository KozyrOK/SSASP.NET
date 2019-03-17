using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SSAspNet.Model;

namespace SSAspNet.Controllers
{
    public class OrdersController : Controller
    {

        [HttpGet]
        public ActionResult FindOrderForId()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FindOrderForId(int? id)
        {
            if (id > 0 && id != null)
            {
                Order order = new Order(id);
                if (order.OrderId != null )
                return View("~/Views/Orders/EditOrder.cshtml", order);
            }
            return View("~/Views/Main/MainMenu.cshtml");
        }

        [HttpPost]
        public ActionResult EditOrder(Order order)
        {
            order.EditOrder();
            return View("~/Views/Main/MainMenu.cshtml");
        }

        public ActionResult ActualOrders()
        {
            Order ActualOrders = new Order();
            List<Order> orders = ActualOrders.GetActualOrders();
            return View(orders);
        }

        public ActionResult DoneOrders()
        {
            Order DoneOrders = new Order();
            List<Order> orders = DoneOrders.GetDoneOrders();
            return View(orders);
        }        
    }
}
