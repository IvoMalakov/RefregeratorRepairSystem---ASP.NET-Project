namespace RefregeratorRepairSystem.Services
{
    using System.Linq;
    using RefregeratorRepairSystem.Data;
    using RefregeratorRepairSystem.Models.ViewModels.Account;
    using RefregeratorRepairSystem.Models.EntityModels;
    using RefregeratorRepairSystem.Services.Interfaces;
    using AutoMapper;
    public class AccountService : Service, IAccountService
    {
        public void CreateCustomer(ApplicationUser user, RegisterViewModel model)
        {
            Customer customer = Mapper.Map<Customer>(model);
            ApplicationUser currentUser = this.Context.Users.Find(user.Id);

            if (currentUser != null)
            {
                customer.ApplicationUser = currentUser;
            }

            this.Context.Customers.Add(customer);
            this.Context.SaveChanges();
        }

        public int CheckUsersCount()
        {
            return this.Context.Users.Count();
        }
    }
}
