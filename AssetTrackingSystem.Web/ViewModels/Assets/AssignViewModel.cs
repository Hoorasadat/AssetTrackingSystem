using AssetTrackingSystem.Lib.Models;
using System.ComponentModel.DataAnnotations;

namespace AssetTrackingSystem.Web.ViewModels.Assets
{
    public class AssignViewModel
    {
        [Display(Name = "Asset")]
        [Required(ErrorMessage = "Asset selection is required!")]
        public string? AssetItem { get; set; }


        [Display(Name = "Employee")]
        [Required(ErrorMessage = "Employee selection is required!")]
        public string? AssignedTo { get; set; }
    }
}
