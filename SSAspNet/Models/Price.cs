using System.ComponentModel;

namespace SSAspNet.Model
{
    public class Price : Pricelist, INotifyPropertyChanged
    {
        
        public int? PriceId { get; set; }

        public Price() { }

        public Price(int id)
        {
            using (SSAspNetContext priceContext = new SSAspNetContext())
            {                
                Price price = priceContext.Prices.Find(id);
                if (price != null)
                {
                    _carBody = price.CarBody;
                    _carWheels = price.CarWheels;
                    _carEngine = price.CarEngine;
                    _carBrakes = price.CarBrakes;
                    _carUndercarriage = price.CarUndercarriage;
                    _busSalon = price.BusSalon;
                    _busHandsrails = price.BusHandsrails;
                    _busUpholstery = price.BusUpholstery;
                    _pasCarwheelBalancing = price.PasCarwheelBalancing;
                    _truckHydraulics = price.TruckHydraulics;
                }                
            }
        }       

        public void EditPrice()
        {
            using (SSAspNetContext priceContext = new SSAspNetContext())
            {                
                Price price = priceContext.Prices.Find(1);
                if (price != null)
                {
                    price.CarBody = CarBody;
                    price.CarWheels = CarWheels;
                    price.CarEngine = CarEngine;
                    price.CarBrakes = CarBrakes;
                    price.CarUndercarriage = CarUndercarriage;
                    price.BusSalon = BusSalon;
                    price.BusHandsrails = BusHandsrails;
                    price.BusUpholstery = BusUpholstery;
                    price.PasCarwheelBalancing = PasCarwheelBalancing;
                    price.TruckHydraulics = TruckHydraulics;
                    priceContext.SaveChanges();
                }
            }            
        }
    }
}
