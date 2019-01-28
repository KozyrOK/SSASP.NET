using System.ComponentModel;

namespace SSWPF.Model
{
    class TruckCarCondition : CarCondition, INotifyPropertyChanged
    {
        public int _truckHydraulics;

        public TruckCarCondition()
        {
            _truckHydraulics = 100;
        }

        public int TruckHydraulics
        {
            get { return _truckHydraulics; }
            set
            {
                _truckHydraulics = value;
                OnPropertyChanged("TruckHydraulics");
            }
        }       
        
        public override int TotalCondition()
        {
            int total = 0;
            total =
            (CarBody +
            CarWheels +
            CarEngine +
            CarBrakes +
            CarUndercarriage +
            TruckHydraulics) / 6;
            return total;
        }
    }
}
