namespace RailwayApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RailwayApp.TicketConfig>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "RailwayApp.TicketConfig";
        }

        protected override void Seed(RailwayApp.TicketConfig context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
