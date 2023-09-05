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
        public async Task<Asset> AddAsset(Asset asset)
        {
            var newAsset = await _context.AddAsync(asset);
            await _context.SaveChangesAsync();

            return newAsset.Entity;
        }

        public async Task<Asset> DeleteAsset(int id)
        {
            Asset deletedAsset = await _context.Assets.FirstOrDefaultAsync(x => x.Id == id);
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

        public async Task<Asset> UpdateAsset(Asset asset)
        {
            Asset AssetToUpdate = await _context.Assets.FirstOrDefaultAsync(x => x.Id == asset.Id);

            AssetToUpdate.TagNumber = asset.TagNumber;
            AssetToUpdate.AssetTypeId = asset.AssetTypeId;
            AssetToUpdate.ManufacturerId = asset.ManufacturerId;
            AssetToUpdate.ModelId = asset.ModelId;
            AssetToUpdate.Description = asset.Description;
            AssetToUpdate.AssignedTo = asset.AssignedTo;
            AssetToUpdate.SerialNumber = asset.SerialNumber;

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
