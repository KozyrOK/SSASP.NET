using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SSWPF.Model
{
    abstract class CarService : INotifyPropertyChanged
    {
        private bool _carBody;
        private bool _carWheels;
        private bool _carEngine;
        private bool _carBrakes;
        private bool _carUndercarriage;

        public CarService()
        {           
            _carBody = false;
            _carWheels = false;
            _carEngine = false;
            _carBrakes = false;
            _carUndercarriage = false;
        }

        public bool CarBody
        {
            get { return _carBody; }
            set
            {
                _carBody = value;
                OnPropertyChanged("CarBody");
            }
        }

        public bool CarWheels
        {
            get { return _carWheels; }
            set
            {
                _carWheels = value;
                OnPropertyChanged("CarWheels");
            }
        }

        public bool CarEngine
        {
            get { return _carEngine; }
            set
            {
                _carEngine = value;
                OnPropertyChanged("CarEngine");
            }
        }

        public bool CarBrakes
        {
            get { return _carBrakes; }
            set
            {
                _carBrakes = value;
                OnPropertyChanged("CarBrakes");
            }
        }

        public bool CarUndercarriage
        {
            get { return _carUndercarriage; }
            set
            {
                _carUndercarriage = value;
                OnPropertyChanged("CarUndercarriage");
            }
        }       

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }        
    }
}
