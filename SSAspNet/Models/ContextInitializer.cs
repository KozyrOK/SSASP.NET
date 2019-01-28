using System;
using System.Data.Entity;

namespace SSWPF.Model
{
    class ContextInitializer : DropCreateDatabaseAlways<SSWPFContext>
    {
        protected override void Seed(SSWPFContext db)
        {
            Price p = new Price();
            
            db.Prices.Add(p);            
            db.SaveChanges();
        }
    }
}
