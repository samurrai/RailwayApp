namespace RailwayApp
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TicketConfig : DbContext
    {
        public TicketConfig()
            : base("name=TicketConfig")
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Ticket> Tickets{ get; set; }
    }
}