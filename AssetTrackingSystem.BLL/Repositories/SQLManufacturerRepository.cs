﻿using AssetTrackingSystem.BLL.Interfaces;
using AssetTrackingSystem.Data.Data;
using AssetTrackingSystem.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingSystem.BLL.Repositories
{
    public class SQLManufacturerRepository : IManufacturerRepository
    {

        private readonly ApplicationDbContext _context;

        public SQLManufacturerRepository(ApplicationDbContext context)
        {
            _context = context;

        }


        public Task<Manufacturer> AddManufacturer(Manufacturer newManufacturer)
        {
            throw new NotImplementedException();
        }

        public Task<Manufacturer> DeleteManufacturer(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Manufacturer>> GetAllManufacturers()
        {
            throw new NotImplementedException();
        }

        public Task<Manufacturer> GetManufacturersById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Manufacturer> UpdateManufacturer(Manufacturer updatedManufacturer)
        {
            throw new NotImplementedException();
        }
    }
}
