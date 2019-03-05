using System.ComponentModel;

namespace SSAspNet.Model
{
    public class TruckCarServiceStation : CarServiceStation, INotifyPropertyChanged
    {       
        protected int _truckHydraulicsCondition;
        protected bool _truckHydraulicsIsService;

        public TruckCarServiceStation ()
        {
            _truckHydraulicsCondition = 100;
            _truckHydraulicsIsService = false;
        }
               
        public int TruckHydraulicsCondition
        {
            get { return _truckHydraulicsCondition; }
            set
            {
                _truckHydraulicsCondition = value;
                OnPropertyChanged("TruckHydraulics");
            }
        }

        public bool TruckHydraulicsIsService
        {
            get { return _truckHydraulicsIsService; }
            set
            {
                _truckHydraulicsIsService = value;
                OnPropertyChanged("TruckHydraulics");
            }
        }

        public override int TotalSumCarCondition()
        {
            int totalSum = 0;
            int sum = base.TotalSumCarCondition();
            totalSum = sum + TruckHydraulicsCondition;
            return totalSum;
        }

        public override int GetAveragedCarCondition()
        {
            int totalSum = TotalSumCarCondition();
            int averagedCarCondition = totalSum / 6;
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
                carBrakes = price.CarBrakes / 100 * (100 - CarEngineCondition);
                cost += carBrakes;
            }
            if (CarUndercarriageIsService)
            {
                decimal carUndercarriage = 0;
                carUndercarriage = price.CarUndercarriage / 100 * (100 - CarUndercarriageCondition);
                cost += carUndercarriage;
            }
            if (TruckHydraulicsIsService)
            {
                decimal truckHydraulics = 0;
                truckHydraulics = price.TruckHydraulics / 100 * (100 - TruckHydraulicsCondition);
                cost += truckHydraulics;
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
