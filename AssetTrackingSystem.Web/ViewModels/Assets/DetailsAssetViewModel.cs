using AssetTrackingSystem.Lib.Models;

namespace AssetTrackingSystem.Web.ViewModels.Assets
{
    public class DetailsAssetViewModel
    {
        public Asset Asset { get; set; }

        public string EmployeeFullName { get; set; }

        public string? PageHeader { get; set; }
    }
}
