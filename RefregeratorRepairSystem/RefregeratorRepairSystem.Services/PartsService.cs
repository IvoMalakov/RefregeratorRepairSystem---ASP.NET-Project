using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RefregeratorRepairSystem.Models.BindingModels;
using RefregeratorRepairSystem.Models.EntityModels;
using RefregeratorRepairSystem.Models.ViewModels.Items;
using RefregeratorRepairSystem.Models.ViewModels.Parts;

namespace RefregeratorRepairSystem.Services
{
    public class PartsService : Service
    {
        public IEnumerable<ListPartsViewModel> GetAllParts()
        {
            IEnumerable<Part> parts = this.Context
                .Parts
                .OrderBy(p => p.Name)
                .ThenByDescending(p => p.Price)
                .ToList();

            IEnumerable<ListPartsViewModel> viewModels =
                Mapper.Map<IEnumerable<Part>, IEnumerable<ListPartsViewModel>>(parts);

            return viewModels;
        }

        public AddPartViewModel GetPartDetailsForAdd()
        {
            AddPartViewModel viewModel = new AddPartViewModel();
            var items = this.Context.Items.ToList();

            foreach (var item in items)
            {
                ItemForPartViewModel itemForPartView = Mapper.Map<ItemForPartViewModel>(item);
                viewModel.Items.Add(itemForPartView);
            }

            return viewModel;
        }

        public void AddPart(AddPartBindingModel bindingModel)
        {
            Part part = Mapper.Map<Part>(bindingModel);

            Item item = this.Context.Items.Find(bindingModel.ItemId);
            part.Items.Add(item);

            this.Context.Parts.Add(part);
            this.Context.SaveChanges();
        }

        public DetailedPartViewModel GetPartDetails(int id)
        {
            Part part = this.Context.Parts.Find(id);
            DetailedPartViewModel viewModel = Mapper.Map<DetailedPartViewModel>(part);

            return viewModel;
        }

        public EditPartViewModel GetPartForEdition(int id)
        {
            Part part = this.Context.Parts.Find(id);
            EditPartViewModel viewModel = Mapper.Map<EditPartViewModel>(part);

            return viewModel;
        }

        public void EditPart(EditPartBindingModel bindingModel)
        {
            Part part = this.Context.Parts.Find(bindingModel.Id);

            if (part != null)
            {
                part.Price = bindingModel.Price;
                part.Quantity = bindingModel.Quantity;

                this.Context.SaveChanges();
            }
        }

        public DeletePartViewModel GetPartForDeletion(int id)
        {
            Part part = this.Context.Parts.Find(id);
            DeletePartViewModel viewModel = Mapper.Map<DeletePartViewModel>(part);

            return viewModel;
        }

        public void DeletePart(DeletePartBindingModel bindingModel)
        {
            Part part = this.Context.Parts.Find(bindingModel.Id);

            if (part != null)
            {
                this.Context.Parts.Remove(part);
                this.Context.SaveChanges();
            }
        }
    }
}
