using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SSWPF.Model
{
    class BusCarService : CarService, INotifyPropertyChanged
    {
        private bool _busSalon;
        private bool _busHandsrails;
        private bool _busUpholstery;

        public BusCarService()
        {
            _busSalon = false;
            _busHandsrails = false;
            _busUpholstery = false;
        }

        public bool BusSalon
        {
            get { return _busSalon; }
            set
            {
                _busSalon = value;
                OnPropertyChanged("BusSalon");
            }
        }

        public bool BusHandsrails
        {
            get { return _busHandsrails; }
            set
            {
                _busHandsrails = value;
                OnPropertyChanged("BusHandsrails");
            }
        }

        public bool BusUpholstery
        {
            get { return _busUpholstery; }
            set
            {
                _busUpholstery = value;
                OnPropertyChanged("BusUpholstery");
            }
        }
        
    }
}
