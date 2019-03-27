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
                    CarBody = price.CarBody;
                    CarWheels = price.CarWheels;
                    CarEngine = price.CarEngine;
                    CarBrakes = price.CarBrakes;
                    CarUndercarriage = price.CarUndercarriage;
                    BusSalon = price.BusSalon;
                    BusHandsrails = price.BusHandsrails;
                    BusUpholstery = price.BusUpholstery;
                    PasCarwheelBalancing = price.PasCarwheelBalancing;
                    TruckHydraulics = price.TruckHydraulics;
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