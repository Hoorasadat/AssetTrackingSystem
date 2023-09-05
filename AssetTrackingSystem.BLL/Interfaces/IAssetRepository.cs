using AssetTrackingSystem.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingSystem.BLL.Interfaces
{
    public interface IAssetRepository
    {
        Task<IList<Asset>> GetAllAssets();
        Task<Asset> GetAssetsById(int id);
        Task<Asset> AddAsset(Asset newAsset);
        Task<Asset> UpdateAsset(Asset updatedAsset);
        Task<Asset> DeleteAsset(int id);

    }
}
