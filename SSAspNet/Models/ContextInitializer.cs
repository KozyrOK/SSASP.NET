using System.Data.Entity;

namespace SSAspNet.Model
{
    class ContextInitializer : DropCreateDatabaseIfModelChanges<SSAspNetContext>
    {
        protected override void Seed(SSAspNetContext db)
        {
            Price price = new Price
            {               
                CarBody = 100,
                CarWheels = 100,
                CarEngine = 100,
                CarBrakes = 100,
                CarUndercarriage = 100,
                BusSalon = 100,
                BusHandsrails = 100,
                BusUpholstery = 300,
                PasCarwheelBalancing = 100,
                TruckHydraulics = 100
            };           
            
            db.Prices.Add(price);            
            db.SaveChanges();
        }
    }
}
