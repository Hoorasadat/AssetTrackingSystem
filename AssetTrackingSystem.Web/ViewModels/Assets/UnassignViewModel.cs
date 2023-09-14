using AssetTrackingSystem.Lib.Models;
using System.ComponentModel.DataAnnotations;

namespace AssetTrackingSystem.Web.ViewModels.Assets
{
    public class UnassignViewModel
    {
        [Display(Name = "Asset")]
        [Required(ErrorMessage = "Asset selection is required!")]
        public string? AssetItem { get; set; }

        public string? AssignedTo { get; set; }
    }
}
