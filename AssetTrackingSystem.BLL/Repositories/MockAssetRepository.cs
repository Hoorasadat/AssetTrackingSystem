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
                    TagNumber = "TAG001",
                    AssetTypeId = 1, // Desktop PC
                    ManufacturerId = 1, // Dell
                    ModelId = 1, // Dell Inspiron
                    Description = "Dell Inspiron Desktop",
                    AssignedTo = "EMP001",
                    SerialNumber = "SN001"
                };

                Asset asset2 = new Asset()
                {
                    Id = 2,
                    TagNumber = "TAG002",
                    AssetTypeId = 1, // Desktop PC
                    ManufacturerId = 1, // Dell
                    ModelId = 2, // Dell XPS
                    Description = "Dell XPS Desktop",
                    AssignedTo = "EMP002",
                    SerialNumber = "SN002"
                };

                Asset asset3 = new Asset()
                {
                    Id = 3,
                    TagNumber = "TAG003",
                    AssetTypeId = 1, // Desktop PC
                    ManufacturerId = 2, // HP
                    ModelId = 3, // HP Elite
                    Description = "HP Elite Desktop",
                    AssignedTo = "EMP003",
                    SerialNumber = "SN003"
                };

                Asset asset4 = new Asset()
                {
                    Id = 4,
                    TagNumber = "TAG004",
                    AssetTypeId = 1, // Desktop PC
                    ManufacturerId = 3, // Acer
                    ModelId = 4, // Acer Aspire
                    Description = "Acer Aspire Desktop",
                    AssignedTo = "EMP004",
                    SerialNumber = "SN004"
                };

                Asset asset5 = new Asset()
                {
                    Id = 5,
                    TagNumber = "TAG005",
                    AssetTypeId = 2, // Laptop
                    ManufacturerId = 1, // Dell
                    ModelId = 5, // Dell Latitude E4550
                    Description = "Dell Latitude E4550 Laptop",
                    AssignedTo = "EMP001",
                    SerialNumber = "SN005"
                };

                Asset asset6 = new Asset()
                {
                    Id = 6,
                    TagNumber = "TAG006",
                    AssetTypeId = 2, // Laptop
                    ManufacturerId = 1, // Dell
                    ModelId = 6, // Dell Latitude E5550
                    Description = "Dell Latitude E5550 Laptop",
                    AssignedTo = "EMP002",
                    SerialNumber = "SN006"
                };

                Asset asset7 = new Asset()
                {
                    Id = 7,
                    TagNumber = "TAG007",
                    AssetTypeId = 2, // Laptop
                    ManufacturerId = 4, // Apple
                    ModelId = 7, // Apple MacBook Air
                    Description = "Apple MacBook Air Laptop",
                    AssignedTo = "EMP003",
                    SerialNumber = "SN007"
                };

                Asset asset8 = new Asset()
                {
                    Id = 8,
                    TagNumber = "TAG008",
                    AssetTypeId = 2, // Laptop
                    ManufacturerId = 4, // Apple
                    ModelId = 8, // Apple MacBook Pro
                    Description = "Apple MacBook Pro Laptop",
                    AssignedTo = "EMP004",
                    SerialNumber = "SN008"
                };

                Asset asset9 = new Asset()
                {
                    Id = 9,
                    TagNumber = "TAG009",
                    AssetTypeId = 3, // Tablet
                    ManufacturerId = 4, // Apple
                    ModelId = 10, // Apple iPad mini
                    Description = "Apple iPad mini Tablet",
                    AssignedTo = "EMP001",
                    SerialNumber = "SN009"
                };

                Asset asset10 = new Asset()
                {
                    Id = 10,
                    TagNumber = "TAG010",
                    AssetTypeId = 3, // Tablet
                    ManufacturerId = 4, // Apple
                    ModelId = 11, // Apple iPad Air
                    Description = "Apple iPad Air Tablet",
                    AssignedTo = "EMP002",
                    SerialNumber = "SN010"
                };

                Asset asset11 = new Asset()
                {
                    Id = 11,
                    TagNumber = "TAG011",
                    AssetTypeId = 3, // Tablet
                    ManufacturerId = 5, // Samsung
                    ModelId = 12, // Samsung Galaxy Tab3
                    Description = "Samsung Galaxy Tab3 Tablet",
                    AssignedTo = "EMP003",
                    SerialNumber = "SN011"
                };

                Asset asset12 = new Asset()
                {
                    Id = 12,
                    TagNumber = "TAG012",
                    AssetTypeId = 4, // Monitor
                    ManufacturerId = 3, // Acer
                    ModelId = 13, // Acer S200
                    Description = "Acer S200 Monitor",
                    AssignedTo = "EMP004",
                    SerialNumber = "SN012"
                };

                Asset asset13 = new Asset()
                {
                    Id = 13,
                    TagNumber = "TAG013",
                    AssetTypeId = 4, // Monitor
                    ManufacturerId = 3, // Acer
                    ModelId = 14, // Acer STQ414
                    Description = "Acer STQ414 Monitor",
                    AssignedTo = "EMP001",
                    SerialNumber = "SN013"
                };

                Asset asset14 = new Asset()
                {
                    Id = 14,
                    TagNumber = "TAG014",
                    AssetTypeId = 4, // Monitor
                    ManufacturerId = 6, // LG
                    ModelId = 15, // LG 22MP
                    Description = "LG 22MP Monitor",
                    AssignedTo = "EMP002",
                    SerialNumber = "SN014"
                };

                Asset asset15 = new Asset()
                {
                    Id = 15,
                    TagNumber = "TAG015",
                    AssetTypeId = 4, // Monitor
                    ManufacturerId = 2, // HP
                    ModelId = 16, // HP Pavilion
                    Description = "HP Pavilion Monitor",
                    AssignedTo = "EMP003",
                    SerialNumber = "SN015"
                };

                Asset asset16 = new Asset()
                {
                    Id = 16,
                    TagNumber = "TAG016",
                    AssetTypeId = 5, // Mobile Phone
                    ManufacturerId = 4, // Apple
                    ModelId = 17, // Apple iPhone 5
                    Description = "Apple iPhone 5",
                    AssignedTo = "EMP004",
                    SerialNumber = "SN016"
                };

                Asset asset17 = new Asset()
                {
                    Id = 17,
                    TagNumber = "TAG017",
                    AssetTypeId = 5, // Mobile Phone
                    ManufacturerId = 4, // Apple
                    ModelId = 18, // Apple iPhone 6
                    Description = "Apple iPhone 6",
                    AssignedTo = "EMP001",
                    SerialNumber = "SN017"
                };

                Asset asset18 = new Asset()
                {
                    Id = 18,
                    TagNumber = "TAG018",
                    AssetTypeId = 5, // Mobile Phone
                    ManufacturerId = 5, // Samsung
                    ModelId = 19, // Samsung Galaxy S4
                    Description = "Samsung Galaxy S4",
                    AssignedTo = "EMP002",
                    SerialNumber = "SN018"
                };

                Asset asset19 = new Asset()
                {
                    Id = 19,
                    TagNumber = "TAG019",
                    AssetTypeId = 5, // Mobile Phone
                    ManufacturerId = 5, // Samsung
                    ModelId = 20, // Samsung Galaxy S5
                    Description = "Samsung Galaxy S5",
                    AssignedTo = "EMP003",
                    SerialNumber = "SN019"
                };

                Asset asset20 = new Asset()
                {
                    Id = 20,
                    TagNumber = "TAG020",
                    AssetTypeId = 5, // Mobile Phone
                    ManufacturerId = 5, // Samsung
                    ModelId = 21, // Samsung Galaxy Note5
                    Description = "Samsung Galaxy Note5",
                    AssignedTo = "EMP004",
                    SerialNumber = "SN020"
                };

                Asset asset21 = new Asset()
                {
                    Id = 21,
                    TagNumber = "TAG021",
                    AssetTypeId = 6, // Desk Phone
                    ManufacturerId = 7, // Avaya
                    ModelId = 22, // Avaya 9612G
                    Description = "Avaya 9612G Desk Phone",
                    AssignedTo = "EMP001",
                    SerialNumber = "SN021"
                };

                Asset asset22 = new Asset()
                {
                    Id = 22,
                    TagNumber = "TAG022",
                    AssetTypeId = 6, // Desk Phone
                    ManufacturerId = 8, // Polycom
                    ModelId = 23, // Polycom SoundPoint331
                    Description = "Polycom SoundPoint331 Desk Phone",
                    AssignedTo = "EMP002",
                    SerialNumber = "SN022"
                };

                Asset asset23 = new Asset()
                {
                    Id = 23,
                    TagNumber = "TAG023",
                    AssetTypeId = 6, // Desk Phone
                    ManufacturerId = 9, // Cisco
                    ModelId = 24, // Cisco SPA525G2
                    Description = "Cisco SPA525G2 Desk Phone",
                    AssignedTo = "EMP003",
                    SerialNumber = "SN023"
                };

                _context.Assets.AddRange(
                    asset1, asset2, asset3, asset4, asset5, asset6, asset7, asset8, asset9, asset10,
                    asset11, asset12, asset13, asset14, asset15, asset16, asset17, asset18, asset19, asset20,
                    asset21, asset22, asset23
                );
                _context.SaveChanges();
            }
        }
    }
}
