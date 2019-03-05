using System.ComponentModel;

namespace SSAspNet.Model
{    
    public class PasCarServiceStation : CarServiceStation, INotifyPropertyChanged
    {
        protected int _pasCarwheelBalancingCondition;
        protected bool _pasCarwheelBalancingIsService;

        public PasCarServiceStation()
        {
            _pasCarwheelBalancingCondition = 100;
            _pasCarwheelBalancingIsService = false;
        }

        public int PasCarwheelBalancingCondition
        {
            get { return _pasCarwheelBalancingCondition; }
            set
            {
                _pasCarwheelBalancingCondition = value;
                OnPropertyChanged("PasCarwheelBalancing");
            }
        }

        public bool PasCarwheelBalancingIsService
        {
            get { return _pasCarwheelBalancingIsService; }
            set
            {
                _pasCarwheelBalancingIsService = value;
                OnPropertyChanged("PasCarwheelBalancing");
            }
        }

        public override int TotalSumCarCondition()
        {
            int sum = base.TotalSumCarCondition();
            int totalSum = 0;            
            totalSum = sum;
            return totalSum;
        }

        public override int GetAveragedCarCondition()
        {
            int totalSum = TotalSumCarCondition();
            int averagedCarCondition = totalSum / 5;
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
            if (PasCarwheelBalancingIsService)
            {
                decimal pasCarwheelBalancing = 0;
                pasCarwheelBalancing = price.PasCarwheelBalancing;
                cost += pasCarwheelBalancing;
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


