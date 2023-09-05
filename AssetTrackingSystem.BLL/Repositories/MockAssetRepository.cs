using AssetTrackingSystem.BLL.Interfaces;
using AssetTrackingSystem.Data.Data;
using AssetTrackingSystem.Lib.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Asset> AddAsset(Asset newAsset)
        {
            var asset = await _context.AddAsync(newAsset);
            await _context.SaveChangesAsync();

            return asset.Entity;
        }

        public async Task<Asset> DeleteAsset(int id)
        {
            Asset deletedAsset = await _context.Assets.FirstOrDefaultAsync(x => x.Id == id);

            if (deletedAsset == null)
            {
                return null;
            }

            _context.Assets.Remove(deletedAsset);
            await _context.SaveChangesAsync();

            return deletedAsset;
        }

        public async Task<IList<Asset>> GetAllAssets()
        {
            return await _context.Assets.ToListAsync();
        }

        public async Task<Asset> GetAssetsById(int id)
        {
            return await _context.Assets.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Asset> UpdateAsset(Asset updatedAsset)
        {
            Asset AssetToUpdate = await _context.Assets.FirstOrDefaultAsync(x => x.Id == updatedAsset.Id);

            if (AssetToUpdate == null)
            {
                return null;
            }

            AssetToUpdate.TagNumber = updatedAsset.TagNumber;
            AssetToUpdate.AssetTypeId = updatedAsset.AssetTypeId;
            AssetToUpdate.ManufacturerId = updatedAsset.ManufacturerId;
            AssetToUpdate.ModelId = updatedAsset.ModelId;
            AssetToUpdate.Description = updatedAsset.Description;
            AssetToUpdate.AssignedTo = updatedAsset.AssignedTo;
            AssetToUpdate.SerialNumber = updatedAsset.SerialNumber;

            _context.Assets.Update(AssetToUpdate);
            await _context.SaveChangesAsync();
            return AssetToUpdate;
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
