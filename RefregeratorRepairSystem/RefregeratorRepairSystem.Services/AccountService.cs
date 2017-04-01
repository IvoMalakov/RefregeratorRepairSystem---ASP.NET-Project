namespace RefregeratorRepairSystem.Services
{
    using RefregeratorRepairSystem.Data;
    using RefregeratorRepairSystem.Models.ViewModels.Account;
    using RefregeratorRepairSystem.Models.EntityModels;
    using AutoMapper;
    public class AccountService : Service
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
    }
}
