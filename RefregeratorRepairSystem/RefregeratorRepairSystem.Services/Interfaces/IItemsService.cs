using System.Collections.Generic;
using RefregeratorRepairSystem.Data;
using RefregeratorRepairSystem.Models.BindingModels;
using RefregeratorRepairSystem.Models.ViewModels.Items;

namespace RefregeratorRepairSystem.Services.Interfaces
{
    public interface IItemsService
    {
        AddItemViewModel GetItemDetailsForAdd();
        void AddItem(AddItemBindingModel bindingModel);
        IEnumerable<ListItemsViewModel> GetAllItems();
        EditItemViewModel GetItemForEdition(int id);
        void EditItem(EditItemBindingModel bindingModel);
        DeleteItemViewModel GetItemForDeletion(int id);
        void DeleteItem(DeleteItemBindingModel bimBindingModel);
        DetailedItemViewModel GetItemDetails(int id);
        RefregeratorRepairSystemContext Context { get; set; }
    }
}