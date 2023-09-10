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
    public class SQLAssetTypeRepository : IAssetTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public SQLAssetTypeRepository(ApplicationDbContext context)
        {
            _context = context;

        }


        public Task<AssetType> AddAssetType(AssetType newAssetType)
        {
            throw new NotImplementedException();
        }

        public Task<AssetType> DeleteAssetType(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<AssetType>> GetAllAssetTypes()
        {
            throw new NotImplementedException();
        }

        public Task<AssetType> GetAssetTypesById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AssetType> UpdateAssetType(AssetType updatedAssetType)
        {
            throw new NotImplementedException();
        }
    }
}
