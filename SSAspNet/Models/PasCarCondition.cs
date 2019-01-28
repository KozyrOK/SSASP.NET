using System.ComponentModel;

namespace SSWPF.Model
{
    class PasCarCondition : CarCondition, INotifyPropertyChanged
    {
        public int _pasCarwheelBalancing;

        public PasCarCondition()
        {            
            _pasCarwheelBalancing = 100;            
        }

        public int PasCarwheelBalancing
        {
            get { return _pasCarwheelBalancing; }
            set
            {
                _pasCarwheelBalancing = value;
                OnPropertyChanged("PasCarwheelBalancing");
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
            CarUndercarriage) / 5;
            return total;
        }
    }
}
