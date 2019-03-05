using System.ComponentModel;

namespace SSAspNet.Model
{
    
    public abstract class CarServiceStation : Car, INotifyPropertyChanged
    {
        protected int _carBodyCondition;
        protected bool _carBodyIsService;
        protected int _carWheelsCondition;
        protected bool _carWheelsIsService;
        protected int _carEngineCondition;
        protected bool _carEngineIsService;
        protected int _carBrakesCondition;
        protected bool _carBrakesIsService;
        protected int _carUndercarriageCondition;
        protected bool _carUndercarriageIsService;
        
        public CarServiceStation()
        {
            _carBodyCondition = 100;
            _carBodyIsService = false;
            _carWheelsCondition = 100;
            _carWheelsIsService = false;
            _carEngineCondition = 100;
            _carEngineIsService = false;
            _carBrakesCondition = 100;
            _carBrakesIsService = false;
            _carUndercarriageCondition = 100;
            _carUndercarriageIsService = false;
        }

        public int CarBodyCondition
        {
            get { return _carBodyCondition; }
            set
            {
                _carBodyCondition = value;
                OnPropertyChanged("CarBody");
            }
        }

        public bool CarBodyIsService
        {
            get { return _carBodyIsService; }
            set
            {
                _carBodyIsService = value;
                OnPropertyChanged("CarBody");
            }
        }

        public int CarWheelsCondition
        {
            get { return _carWheelsCondition; }
            set
            {
                _carWheelsCondition = value;
                OnPropertyChanged("CarWheels");
            }
        }

        public bool CarWheelsIsService
        {
            get { return _carWheelsIsService; }
            set
            {
                _carWheelsIsService = value;
                OnPropertyChanged("CarWheels");
            }
        }

        public int CarEngineCondition
        {
            get { return _carEngineCondition; }
            set
            {
                _carEngineCondition = value;
                OnPropertyChanged("CarEngine");
            }
        }

        public bool CarEngineIsService
        {
            get { return _carEngineIsService; }
            set
            {
                _carEngineIsService = value;
                OnPropertyChanged("CarEngine");
            }
        }

        public int CarBrakesCondition
        {
            get { return _carBrakesCondition; }
            set
            {
                _carBrakesCondition = value;
                OnPropertyChanged("CarBrakes");
            }
        }

        public bool CarBrakesIsService
        {
            get { return _carBrakesIsService; }
            set
            {
                _carBrakesIsService = value;
                OnPropertyChanged("CarBrakes");
            }
        }

        public int CarUndercarriageCondition
        {
            get { return _carUndercarriageCondition; }
            set
            {
                _carUndercarriageCondition = value;
                OnPropertyChanged("CarUndercarriage");
            }
        }

        public bool CarUndercarriageIsService
        {
            get { return _carUndercarriageIsService; }
            set
            {
                _carUndercarriageIsService = value;
                OnPropertyChanged("CarUndercarriage");
            }
        }

        public virtual int TotalSumCarCondition() 
        {
            int totalSum = 0;
            totalSum =
            (CarBodyCondition +
            CarWheelsCondition +
            CarEngineCondition +
            CarBrakesCondition +
            CarUndercarriageCondition);            
            return totalSum;
        }

        public abstract int GetAveragedCarCondition();
        public abstract decimal CalculateCost(Price price);
        public abstract void FillOrder(ref Order order);
    }
}
