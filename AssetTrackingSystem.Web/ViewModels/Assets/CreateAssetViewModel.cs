using AssetTrackingSystem.Lib.Models;
using System.ComponentModel.DataAnnotations;

namespace AssetTrackingSystem.Web.ViewModels.Assets
{
    public class CreateAssetViewModel
    {
        [Display(Name = "Tag Number")]
        public string? TagNumber { get; set; }


        [Display(Name = "Asset Type")]
        [Required(ErrorMessage = "Asset Type is required!")]
        public int AssetTypeId { get; set; }


        [Display(Name = "Manufacturer")]
        [Required(ErrorMessage = "Manufacturer is required!")]
        public int ManufacturerId { get; set; }


        [Display(Name = "Model")]
        [Required(ErrorMessage = "Model is required!")]
        public int ModelId { get; set; }


        public string? Description { get; set; }


        [Display(Name = "Assigned To")]
        public string? AssignedTo { get; set; }


        [Display(Name = "Serial Number")]
        [Required(ErrorMessage = "Serial Number is required!")]
        public string SerialNumber { get; set; }


        public AssetType? AssetType { get; set; }
        public Manufacturer? Manufacturer { get; set; }
        public Model? Model { get; set; }
    }
}
