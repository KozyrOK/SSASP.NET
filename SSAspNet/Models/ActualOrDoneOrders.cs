using System.Collections.Generic;
using System.Linq;

namespace SSWPF.Model
{
    class ActualOrDoneOrders
    {
        private List<Order> orders;

        public List<Order> Orders { get => orders; set => orders = value; }

        public List<Order> GetActualOrders()
        {
            using (var context = new SSWPFContext())
            {
                return context.Orders.Where(p => p.StateOrder == "actual").OrderBy(p => p.OrderId).ToList<Order>();
            }
        }

        public List<Order> GetDoneOrders()
        {
            using (var context = new SSWPFContext())
            {
                return context.Orders.Where(p => p.StateOrder == "done").OrderBy(p => p.OrderId).ToList<Order>();
            }
        }
    }
}
