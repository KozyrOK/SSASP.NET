using System.Data.Entity;

namespace SSAspNet.Model
{
    class SSAspNetContext : DbContext
    {
        static SSAspNetContext() { Database.SetInitializer(new ContextInitializer()); }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Price> Prices { get; set; }
    }
}
