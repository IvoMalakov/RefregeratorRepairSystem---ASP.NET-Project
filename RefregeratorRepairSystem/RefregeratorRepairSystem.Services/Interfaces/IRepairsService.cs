using System.Collections.Generic;
using RefregeratorRepairSystem.Data;
using RefregeratorRepairSystem.Models.BindingModels;
using RefregeratorRepairSystem.Models.ViewModels.Repairs;
using RefregeratorRepairSystem.Models.ViewModels.Repairs.AddRepairsViewModels;

namespace RefregeratorRepairSystem.Services.Interfaces
{
    public interface IRepairsService
    {
        IEnumerable<ListRepairsViewModel> GetAllRepairs();
        AddRepairViewModel GetAllRepairDetailsForAdd();
        void AddRepair(AddRepairBindingModel model);
        DetailedRepairViewModel GetRepairDetails(int id);
        EditRepairViewModel GetEditedRepair(int id);
        void EditRepair(EditRepairBindingModel model);
        DeleteRepairViewModel GetRepairForDeletion(int id);
        void DeleteRepair(DeleteRepairBindingModel model);
        RefregeratorRepairSystemContext Context { get; set; }
    }
}