namespace RefregeratorRepairSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RefregeratorRepairSystem.Data.RefregeratorRepairSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        //protected override void Seed(RefregeratorRepairSystem.Data.RefregeratorRepairSystemContext context)
        //{

        //}
    }
}
