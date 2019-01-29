using System.Data.Entity;

namespace SSWPF.Model
{
    class SSASPContext : DbContext
    {
        static SSASPContext() { Database.SetInitializer<SSASPContext>(new ContextInitializer()); }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Price> Prices { get; set; }
    }
}
