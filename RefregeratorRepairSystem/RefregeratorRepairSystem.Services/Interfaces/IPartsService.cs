using System.Collections.Generic;
using RefregeratorRepairSystem.Data;
using RefregeratorRepairSystem.Models.BindingModels;
using RefregeratorRepairSystem.Models.ViewModels.Parts;

namespace RefregeratorRepairSystem.Services.Interfaces
{
    public interface IPartsService
    {
        IEnumerable<ListPartsViewModel> GetAllParts();
        AddPartViewModel GetPartDetailsForAdd();
        void AddPart(AddPartBindingModel bindingModel);
        DetailedPartViewModel GetPartDetails(int id);
        EditPartViewModel GetPartForEdition(int id);
        void EditPart(EditPartBindingModel bindingModel);
        DeletePartViewModel GetPartForDeletion(int id);
        void DeletePart(DeletePartBindingModel bindingModel);
        RefregeratorRepairSystemContext Context { get; set; }
    }
}