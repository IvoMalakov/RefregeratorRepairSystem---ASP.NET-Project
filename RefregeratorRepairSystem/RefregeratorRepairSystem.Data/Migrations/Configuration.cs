using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RefregeratorRepairSystem.Models.EntityModels;
using RefregeratorRepairSystem.Models.Enums;

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

        protected override void Seed(RefregeratorRepairSystem.Data.RefregeratorRepairSystemContext context)
        {
            if (!context.Roles.Any(role => role.Name == "Customer"))
            {
                var roleManager = new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(new RefregeratorRepairSystemContext()));
                var roleCreateResult = roleManager.Create(new IdentityRole("Customer"));

                if (!roleCreateResult.Succeeded)
                {
                    throw new Exception(string.Join("; ", roleCreateResult.Errors));
                }
            }

            if (!context.Roles.Any(role => role.Name == "Administrator"))
            {
                var roleManager = new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(new RefregeratorRepairSystemContext()));
                var roleCreateResult = roleManager.Create(new IdentityRole("Administrator"));

                if (!roleCreateResult.Succeeded)
                {
                    throw new Exception(string.Join("; ", roleCreateResult.Errors));
                }
            }

            if (!context.Roles.Any(role => role.Name == "Employee"))
            {
                var roleManager = new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(new RefregeratorRepairSystemContext()));
                var roleCreateResult = roleManager.Create(new IdentityRole("Employee"));

                if (!roleCreateResult.Succeeded)
                {
                    throw new Exception(string.Join("; ", roleCreateResult.Errors));
                }
            }
        }
    }
}