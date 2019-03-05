using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SSAspNet.Model
{
    public class Order : Orderlist, INotifyPropertyChanged
    {
        static readonly object locker = new object();
        public int? OrderId { get; set; }

        public Order() { }

        public Order(int id)
        {
            using (SSAspNetContext ordersContext = new SSAspNetContext())
            {
                var or = ordersContext.Orders.Find(id);
                if (or != null)
                {
                    OrderId = or.OrderId;
                    _dateTimeOrder = or.DateTimeOrder;
                    _modelCar = or.ModelCar;
                    _numberCar = or.NumberCar;
                    _stateOrder = or.StateOrder;
                    _costOrder = or.CostOrder;
                    _orderPaid = or.OrderPaid;
                    _conditionCar = or.ConditionCar;
                }
            }
        }

        public void AddNewOrder()
        {
            using (SSAspNetContext ordersContext = new SSAspNetContext())
            {
                ordersContext.Orders.Add(this);
                ordersContext.SaveChanges();
            }
        }

        public int GetLastOrderId()
        {
            lock (locker)
            {
                using (SSAspNetContext ordersContext = new SSAspNetContext())
                {
                    int id = ordersContext.Orders.Count();
                    return id;
                }
            }
        }

        public void EditOrder()
        {
            lock (locker)
            {
                int? id = OrderId;
                using (SSAspNetContext ordersContext = new SSAspNetContext())
                {
                    Order newOrder = ordersContext.Orders.Find(id);

                    newOrder.OrderId = OrderId;
                    newOrder.DateTimeOrder = DateTimeOrder;
                    newOrder.ModelCar = ModelCar;
                    newOrder.NumberCar = NumberCar;
                    newOrder.StateOrder = StateOrder;
                    newOrder.CostOrder = CostOrder;
                    newOrder.OrderPaid = OrderPaid;
                    newOrder.ConditionCar = ConditionCar;

                    ordersContext.SaveChanges();
                }
            }
        }        

        public List<Orderlist> GetActualOrders()
        {
            using (SSAspNetContext context = new SSAspNetContext())
            {
                return context.Orders.Where(p => p.StateOrder == 0).OrderBy(p => p.OrderId).ToList<Orderlist>();
            }
        }

        public List<Orderlist> GetDoneOrders()
        {
            using (SSAspNetContext context = new SSAspNetContext())
            {
                return context.Orders.Where(p => p.StateOrder == (StateOrder)1).OrderBy(p => p.OrderId).ToList<Orderlist>();
            }
        }
    }
}
