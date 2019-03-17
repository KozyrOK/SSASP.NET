using System.ComponentModel;

namespace SSAspNet.Model
{
    public class BusCarServiceStation : PasCarServiceStation, INotifyPropertyChanged
    {
        protected int _busSalonCondition;
        protected bool _busSalonIsService;
        protected int _busHandsrailsCondition;
        protected bool _busHandsrailsIsService;
        protected int _busUpholsteryCondition;
        protected bool _busUpholsteryIsService;

        public BusCarServiceStation()
        {
            _busSalonCondition = 100;
            _busSalonIsService = false;
            _busHandsrailsCondition = 100;
            _busHandsrailsIsService = false;
            _busUpholsteryCondition = 100;
            _busUpholsteryIsService = false;
        }

        public int BusSalonCondition
        {
            get { return _busSalonCondition; }
            set
            {
                _busSalonCondition = value;
                OnPropertyChanged("BusSalon");
            }
        }

        public bool BusSalonIsService
        {
            get { return _busSalonIsService; }
            set
            {
                _busSalonIsService = value;
                OnPropertyChanged("BusSalon");
            }
        }        

        public int BusHandsrailsCondition
        {
            get { return _busHandsrailsCondition; }
            set
            {
                _busHandsrailsCondition = value;
                OnPropertyChanged("BusHandsrails");
            }
        }

        public bool BusHandsrailsIsService
        {
            get { return _busHandsrailsIsService; }
            set
            {
                _busHandsrailsIsService = value;
                OnPropertyChanged("BusHandsrails");
            }
        }
        public int BusUpholsteryCondition
        {
            get { return _busUpholsteryCondition; }
            set
            {
                _busUpholsteryCondition = value;
                OnPropertyChanged("BusUpholstery");
            }
        }

        public bool BusUpholsteryIsService
        {
            get { return _busUpholsteryIsService; }
            set
            {
                _busUpholsteryIsService = value;
                OnPropertyChanged("BusUpholstery");
            }
        }

        public override int TotalSumCarCondition()
        {
            int totalSum = 0;
            int sum = base.TotalSumCarCondition();
            totalSum = sum + BusSalonCondition + BusHandsrailsCondition;
            return totalSum;
        }

        public override int GetAveragedCarCondition()
        {
            int totalSum = TotalSumCarCondition();
            int averagedCarCondition = totalSum / 7;
            return averagedCarCondition;
        }

        public override decimal CalculateCost(Price price)
        {   
            decimal cost = 0;
            if (CarBodyIsService)
            {
                decimal carBody = 0;
                carBody = price.CarBody / 100 * (100 - CarBodyCondition);
                cost += carBody;
            }
            if (CarWheelsIsService)
            {
                decimal carWheels = 0;
                carWheels = price.CarWheels / 100 * (100 - CarWheelsCondition);
                cost += carWheels;
            }
            if (CarEngineIsService)
            {
                decimal carEngine = 0;
                carEngine = price.CarEngine / 100 * (100 - CarEngineCondition);
                cost += carEngine;
            }
            if (CarBrakesIsService)
            {
                decimal carBrakes = 0;
                carBrakes = price.CarBrakes / 100 * (100 - CarBrakesCondition);
                cost += carBrakes;
            }
            if (CarUndercarriageIsService)
            {
                decimal carUndercarriage = 0;
                carUndercarriage = price.CarUndercarriage / 100 * (100 - CarUndercarriageCondition);
                cost += carUndercarriage;
            }
            if (BusHandsrailsIsService)
            {
                decimal busHandsrails = 0;
                busHandsrails = price.BusHandsrails / 100 * (100 - BusHandsrailsCondition);
                cost += busHandsrails;
            }
            if (BusSalonIsService)
            {
                decimal busSalon = 0;
                busSalon = price.BusSalon / 100 * (100 - BusSalonCondition);
                cost += busSalon;
            }
            if (BusUpholsteryIsService)
            {
                decimal busUpholstery = 0;
                busUpholstery = price.BusUpholstery;
                cost += busUpholstery;
            }
            return cost;
        }

        public override void FillOrder(ref Order order)
        {
            order.ModelCar = ModelCar;
            order.NumberCar = NumberCar;
            Price price = new Price(1);            
            order.CostOrder = CalculateCost(price);
            order.ConditionCar = GetAveragedCarCondition();
        }
    }
}
