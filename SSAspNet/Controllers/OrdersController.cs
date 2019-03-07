using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SSAspNet.Model;

namespace SSAspNet.Controllers
{
    public class OrdersController : Controller
    {

        public ActionResult FindOrderForId()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EditOrder(int? id)
        {
            if (id != null)
            {
                Order order = new Order(id);
                return View(order);
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
            SSAspNetContext db = new SSAspNetContext();
            return View(db.Orders.ToList());
        }

        public ActionResult DoneOrders()
        {
            SSAspNetContext db = new SSAspNetContext();
            return View(db.Orders.ToList());
        }        
    }
}
