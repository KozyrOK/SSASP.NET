using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SSWPF.Model
{
    class TruckCarService : CarService, INotifyPropertyChanged
    {
        private bool _truckHydraulics;

        public TruckCarService()
        {
            _truckHydraulics = false;
        }

        public bool TruckHydraulics
        {
            get { return _truckHydraulics; }
            set
            {
                _truckHydraulics = value;
                OnPropertyChanged("TruckHydraulics");
            }
        }
        
    }
}
