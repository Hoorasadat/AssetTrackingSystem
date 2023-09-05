using AssetTrackingSystem.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingSystem.BLL.Interfaces
{
    public interface IAssetTypeRepository
    {
        Task<IList<AssetType>> GetAllAssetTypes();
        Task<AssetType> GetAssetTypesById(int id);
        Task<AssetType> AddAssetType(AssetType newAssetType);
        Task<AssetType> UpdateAssetType(AssetType updatedAssetType);
        Task<AssetType> DeleteAssetType(int id);

    }
}
