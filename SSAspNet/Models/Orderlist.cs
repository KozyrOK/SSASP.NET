using SSAspNet.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SSAspNet.Model
{
    public class Orderlist : INotifyPropertyChanged
    {        
        protected DateTime _dateTimeOrder;
        protected string _modelCar;
        protected string _numberCar;
        protected StateOrder _stateOrder;
        protected decimal _costOrder;
        protected decimal _orderPaid;
        protected int _conditionCar;        

        public Orderlist()
        {            
            _dateTimeOrder = DateTime.Now;
            _modelCar = null;
            _numberCar = null;
            _stateOrder = 0;
            _costOrder = 0;
            _orderPaid = 0;
            _conditionCar = 0;
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

        public StateOrder StateOrder
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
                
    }
}
