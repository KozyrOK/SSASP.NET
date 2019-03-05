using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SSAspNet.Model;

namespace SSAspNet.Controllers
{
    public class OrdersController : Controller
    {
        private SSAspNetContext db = new SSAspNetContext();

        [HttpGet]
        public ActionResult FindOrderForId()
        {
            return View();
        }
                
        public ActionResult ActualOrders()
        {
            return View(db.Orders.ToList());
        }

        public ActionResult DoneOrders()
        {
            return View(db.Orders.ToList());
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,DateTimeOrder,ModelCar,NumberCar,StateOrder,CostOrder,OrderPaid,ConditionCar")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }
       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
