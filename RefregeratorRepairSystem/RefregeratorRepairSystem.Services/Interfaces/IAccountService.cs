using RefregeratorRepairSystem.Data;
using RefregeratorRepairSystem.Models.EntityModels;
using RefregeratorRepairSystem.Models.ViewModels.Account;

namespace RefregeratorRepairSystem.Services.Interfaces
{
    public interface IAccountService
    {
        void CreateCustomer(ApplicationUser user, RegisterViewModel model);
        int CheckUsersCount();
        RefregeratorRepairSystemContext Context { get; set; }
    }
}