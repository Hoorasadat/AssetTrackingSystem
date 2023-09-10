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
    public class SQLModelRepository : IModelRepository
    {
        private readonly ApplicationDbContext _context;

        public SQLModelRepository(ApplicationDbContext context)
        {
            _context = context;

        }


        public Task<Model> AddModel(Model newModel)
        {
            throw new NotImplementedException();
        }

        public Task<Model> DeleteModel(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Model>> GetAllModels()
        {
            throw new NotImplementedException();
        }

        public Task<Model> GetModelsById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Model> UpdateModel(Model updatedModel)
        {
            throw new NotImplementedException();
        }
    }
}
