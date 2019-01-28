using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Telerik.Windows.Data;

namespace SSWPF.Model
{
    public class Order : INotifyPropertyChanged
    {
        public int? OrderId { get; set; }
        public DateTime _dateTimeOrder;
        public string _modelCar;
        public string _numberCar;
        public string _stateOrder;
        public decimal _costOrder;
        public decimal _orderPaid;
        public int _conditionCar;

        static readonly object locker = new object();

        public Order()
        {
            OrderId = null;
            _dateTimeOrder = DateTime.Now;
            _modelCar = null;
            _numberCar = null;
            _stateOrder ="actual";
            _costOrder = 0;
            _orderPaid = 0;
            _conditionCar = 0;
        }

        public Order(int id)
        {
            using (SSWPFContext ordersContext = new SSWPFContext())
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

        public DateTime DateTimeOrder
        {
            get { return _dateTimeOrder; }
            set
            {
                _dateTimeOrder = value;
                OnPropertyChanged("DateOrder");
            }
        }

        public string ModelCar
        {
            get { return _modelCar; }
            set
            {
                _modelCar = value;
                OnPropertyChanged("ModelCar");
            }
        }

        public string NumberCar
        {
            get { return _numberCar; }
            set
            {
                _numberCar = value;
                OnPropertyChanged("NumberCar");
            }
        }

        public string StateOrder
        {
            get { return _stateOrder; }
            set
            {
                _stateOrder = value;
                OnPropertyChanged("StateOrder");
            }
        } 
        
        public decimal CostOrder
        {
            get { return _costOrder; }
            set
            {
                _costOrder = value;
                OnPropertyChanged("CostOrder");
            }
        }

        public decimal OrderPaid
        {
            get { return _orderPaid; }
            set
            {
                _orderPaid = value;
                OnPropertyChanged("OrderPaid");
            }
        }

        public int ConditionCar
        {
            get { return _conditionCar; }
            set
            {
                _conditionCar = value;
                OnPropertyChanged("ConditionCar");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        
        public void AddNewOrder()
        {
            using (SSWPFContext ordersContext = new SSWPFContext())
            {
                ordersContext.Orders.Add(this);
                ordersContext.SaveChanges();
            }
        }

        public void LastOrderId() 
        {
            lock (locker)
            {

                using (SSWPFContext ordersContext = new SSWPFContext())
                {
                    int id = ordersContext.Orders.Count();
                    OrderId = id;
                }
            }
        }
        
        public void EditOrderInBase()
        {
            lock (locker)
            {
                var id = OrderId;
                using (SSWPFContext ordersContext = new SSWPFContext())
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
    }
}
