namespace RefregeratorRepairSystem.Services
{
    using RefregeratorRepairSystem.Models.ViewModels.Account;
    using RefregeratorRepairSystem.Models.EntityModels;
    using AutoMapper;
    public class AccountService : Service
    {
        public void CreateCustomer(ApplicationUser user, RegisterViewModel model)
        {
            Customer customer = Mapper.Map<Customer>(model);
            customer.ApplicationUser = user;

            this.Context.Customers.Add(customer);
            this.Context.SaveChanges();
        }
    }
}
