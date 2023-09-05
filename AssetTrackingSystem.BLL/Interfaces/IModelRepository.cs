using AssetTrackingSystem.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingSystem.BLL.Interfaces
{
    public interface IModelRepository
    {
        Task<IList<Model>> GetAllModels();
        Task<Model> GetModelsById(int id);
        Task<Model> AddModel(Model newModel);
        Task<Model> UpdateModel(Model updatedModel);
        Task<Model> DeleteModel(int id);

    }
}
