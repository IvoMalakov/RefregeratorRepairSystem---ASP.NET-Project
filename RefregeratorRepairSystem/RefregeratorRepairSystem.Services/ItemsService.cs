using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RefregeratorRepairSystem.Models.BindingModels;
using RefregeratorRepairSystem.Models.EntityModels;
using RefregeratorRepairSystem.Models.Enums;
using RefregeratorRepairSystem.Models.ViewModels.Items;
using RefregeratorRepairSystem.Models.ViewModels.Parts;

namespace RefregeratorRepairSystem.Services
{
    public class ItemsService : Service
    {
        public AddItemViewModel GetItemDetailsForAdd()
        {
            AddItemViewModel viewModel = new AddItemViewModel();

            var allItemTypes = Enum.GetNames(typeof (ItemType));

            foreach (var itemType in allItemTypes)
            {
                viewModel.Types.Add(itemType);
            }

            var allParts = this.Context.Parts.ToList();

            foreach (var part in allParts)
            {
                PartForItemViewModel partForItemViewModel = Mapper.Map<PartForItemViewModel>(part);
                viewModel.Parts.Add(partForItemViewModel);
            }

            return viewModel;
        }

        public void AddItem(AddItemBindingModel bindingModel)
        {
            Item item = Mapper.Map<Item>(bindingModel);

            Part part1 = this.Context.Parts.Find(bindingModel.Part1);

            if (part1 != null)
            {
                item.Parts.Add(part1);
            }

            Part part2 = this.Context.Parts.Find(bindingModel.Part2);

            if (part2 != null)
            {
                item.Parts.Add(part2);
            }

            Part part3 = this.Context.Parts.Find(bindingModel.Part3);

            if (part3 != null)
            {
                item.Parts.Add(part3);
            }

            this.Context.Items.Add(item);
            this.Context.SaveChanges();
        }

        public IEnumerable<ListItemsViewModel> GetAllItems()
        {
            IEnumerable<Item> items = this.Context
                .Items
                .OrderBy(i => i.Make)
                .ThenBy(i => i.Model)
                .ToList();

            IEnumerable<ListItemsViewModel> viewModels =
                Mapper.Map<IEnumerable<Item>, IEnumerable<ListItemsViewModel>>(items);

            return viewModels;
        }

        public EditItemViewModel GetItemForEdition(int id)
        {
            Item item = this.Context.Items.Find(id);
            EditItemViewModel viewModel = Mapper.Map<EditItemViewModel>(item);

            return viewModel;
        }

        public void EditItem(EditItemBindingModel bindingModel)
        {
            Item item = this.Context.Items.Find(bindingModel.Id);

            if (item != null)
            {
                item.Make = bindingModel.Make;
                item.Model = bindingModel.Model;
                this.Context.SaveChanges();
            }
        }

        public DeleteItemViewModel GetItemForDeletion(int id)
        {
            Item item = this.Context.Items.Find(id);

            DeleteItemViewModel viewModel = Mapper.Map<DeleteItemViewModel>(item);
            return viewModel;
        }

        public void DeleteItem(DeleteItemBindingModel bimBindingModel)
        {
            Item item = this.Context.Items.Find(bimBindingModel.Id);

            if (item != null)
            {
                this.Context.Items.Remove(item);
                this.Context.SaveChanges();
            }
        }

        public DetailedItemViewModel GetItemDetails(int id)
        {
            Item item = this.Context.Items.Find(id);
            DetailedItemViewModel viewModel = Mapper.Map<DetailedItemViewModel>(item);

            return viewModel;
        }
    }
}
