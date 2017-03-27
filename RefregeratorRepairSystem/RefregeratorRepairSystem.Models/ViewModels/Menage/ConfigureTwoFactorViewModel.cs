namespace RefregeratorRepairSystem.Models.ViewModels.Menage
{
    using System.Collections.Generic;

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}
