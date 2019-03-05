using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SSAspNet.Model
{
    public abstract class Car : INotifyPropertyChanged
    {
        protected string _modelCar;
        protected string _numberCar;

        public Car() 
        {
            _modelCar = "";
            _numberCar = "";
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
