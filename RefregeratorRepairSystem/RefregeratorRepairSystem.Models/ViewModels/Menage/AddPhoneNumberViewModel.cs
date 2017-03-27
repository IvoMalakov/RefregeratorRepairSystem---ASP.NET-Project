using System.ComponentModel.DataAnnotations;

namespace RefregeratorRepairSystem.Models.ViewModels.Menage
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }
}
