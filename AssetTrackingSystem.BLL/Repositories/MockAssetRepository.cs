using AssetTrackingSystem.BLL.Interfaces;
using AssetTrackingSystem.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingSystem.BLL.Repositories
{
    public class MockAssetRepository : IAssetRepository
    {

        public MockAssetRepository() { }
        public Task<Asset> AddAsset(Asset newAsset)
        {
            throw new NotImplementedException();
        }

        public Task<Asset> DeleteAsset(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Asset>> GetAllAssets()
        {
            throw new NotImplementedException();
        }

        public Task<Asset> GetAssetsById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Asset> UpdateAsset(Asset updatedAsset)
        {
            throw new NotImplementedException();
        }
    }
}
