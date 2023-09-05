using AssetTrackingSystem.BLL.Interfaces;
using AssetTrackingSystem.Data.Data;
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
        private readonly MemoryDbContext _context;

        public MockAssetRepository(MemoryDbContext context) 
        { 
            _context = context;
            SeedData();
        }
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

        private void SeedData()
        {
            if(!_context.Assets.Any())
            {
                Asset asset1 = new Asset()
                {
                    Id = 1,
                    TagNumber = "1000",
                    AssetTypeId = 1,
                    ManufacturerId = 1,
                    ModelId = 111,
                    SerialNumber = "ABC",
                };

                Asset asset2 = new Asset()
                {
                    Id = 2,
                    TagNumber = "2000",
                    AssetTypeId = 2,
                    ManufacturerId = 2,
                    ModelId = 222,
                    SerialNumber = "DEF",
                };

                _context.Assets.AddRange(asset1, asset2);
                _context.SaveChanges();
            }
        }
    }
}
