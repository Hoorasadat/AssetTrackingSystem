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
    public class SQLAssetRepository : IAssetRepository
    {
        private readonly ApplicationDbContext _context;

        public SQLAssetRepository(ApplicationDbContext context) 
        { 
            _context = context;
            
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
            /*return await _context.Assets.Include(a => a.AssetType).Include(a => a.Model).Include(a => a.Manufacturer).ToListAsync();*/
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

    }
}
