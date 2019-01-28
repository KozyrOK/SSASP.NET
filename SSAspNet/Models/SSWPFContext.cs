using System.Data.Entity;

namespace SSWPF.Model
{
    class SSWPFContext : DbContext
    {
        static SSWPFContext() { Database.SetInitializer<SSWPFContext>(new ContextInitializer()); }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Price> Prices { get; set; }
    }
}
