using AssetTrackingSystem.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingSystem.BLL.Interfaces
{
    public interface IManufacturerRepository
    {
        Task<IList<Manufacturer>> GetAllManufacturers();
        Task<Manufacturer> GetManufacturersById(int id);
        Task<Manufacturer> AddManufacturer(Manufacturer newManufacturer);
        Task<Manufacturer> UpdateManufacturer(Manufacturer updatedManufacturer);
        Task<Manufacturer> DeleteManufacturer(int id);

    }
}
