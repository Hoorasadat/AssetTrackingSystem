using AssetTrackingSystem.Lib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingSystem.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { }


        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Model> Models { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the cascade behavior for the Assets table
            modelBuilder.Entity<Asset>()
                .HasOne(a => a.Model)
                .WithMany(m => m.Assets)
                .HasForeignKey(a => a.ModelId)
                .OnDelete(DeleteBehavior.NoAction); // Specify ON DELETE NO ACTION or another behavior

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Asset>().HasData(
                new Asset()
                {
                    Id = 1,
                    TagNumber = "TAG001",
                    AssetTypeId = 1, // Desktop PC
                    ManufacturerId = 1, // Dell
                    ModelId = 1, // Dell Inspiron
                    Description = "Dell Inspiron Desktop",
                    AssignedTo = "EMP001",
                    SerialNumber = "SN001"
                },

                new Asset()
                {
                    Id = 2,
                    TagNumber = "TAG002",
                    AssetTypeId = 1, // Desktop PC
                    ManufacturerId = 1, // Dell
                    ModelId = 2, // Dell XPS
                    Description = "Dell XPS Desktop",
                    AssignedTo = "EMP002",
                    SerialNumber = "SN002"
                },

                new Asset()
                {
                    Id = 3,
                    TagNumber = "TAG003",
                    AssetTypeId = 1, // Desktop PC
                    ManufacturerId = 2, // HP
                    ModelId = 3, // HP Elite
                    Description = "HP Elite Desktop",
                    AssignedTo = "EMP003",
                    SerialNumber = "SN003"
                },

                new Asset()
                {
                    Id = 4,
                    TagNumber = "TAG004",
                    AssetTypeId = 1, // Desktop PC
                    ManufacturerId = 3, // Acer
                    ModelId = 4, // Acer Aspire
                    Description = "Acer Aspire Desktop",
                    AssignedTo = "EMP004",
                    SerialNumber = "SN004"
                },

                new Asset()
                {
                    Id = 5,
                    TagNumber = "TAG005",
                    AssetTypeId = 2, // Laptop
                    ManufacturerId = 1, // Dell
                    ModelId = 5, // Dell Latitude E4550
                    Description = "Dell Latitude E4550 Laptop",
                    AssignedTo = "EMP001",
                    SerialNumber = "SN005"
                },

                new Asset()
                {
                    Id = 6,
                    TagNumber = "TAG006",
                    AssetTypeId = 2, // Laptop
                    ManufacturerId = 1, // Dell
                    ModelId = 6, // Dell Latitude E5550
                    Description = "Dell Latitude E5550 Laptop",
                    AssignedTo = "EMP002",
                    SerialNumber = "SN006"
                },

                new Asset()
                {
                    Id = 7,
                    TagNumber = "TAG007",
                    AssetTypeId = 2, // Laptop
                    ManufacturerId = 4, // Apple
                    ModelId = 7, // Apple MacBook Air
                    Description = "Apple MacBook Air Laptop",
                    AssignedTo = "EMP003",
                    SerialNumber = "SN007"
                },

                new Asset()
                {
                    Id = 8,
                    TagNumber = "TAG008",
                    AssetTypeId = 2, // Laptop
                    ManufacturerId = 4, // Apple
                    ModelId = 8, // Apple MacBook Pro
                    Description = "Apple MacBook Pro Laptop",
                    AssignedTo = "EMP004",
                    SerialNumber = "SN008"
                },

                new Asset()
                {
                    Id = 9,
                    TagNumber = "TAG009",
                    AssetTypeId = 3, // Tablet
                    ManufacturerId = 4, // Apple
                    ModelId = 10, // Apple iPad mini
                    Description = "Apple iPad mini Tablet",
                    AssignedTo = "EMP001",
                    SerialNumber = "SN009"
                },

                new Asset()
                {
                    Id = 10,
                    TagNumber = "TAG010",
                    AssetTypeId = 3, // Tablet
                    ManufacturerId = 4, // Apple
                    ModelId = 11, // Apple iPad Air
                    Description = "Apple iPad Air Tablet",
                    AssignedTo = "EMP002",
                    SerialNumber = "SN010"
                },

                new Asset()
                {
                    Id = 11,
                    TagNumber = "TAG011",
                    AssetTypeId = 3, // Tablet
                    ManufacturerId = 5, // Samsung
                    ModelId = 12, // Samsung Galaxy Tab3
                    Description = "Samsung Galaxy Tab3 Tablet",
                    AssignedTo = "EMP003",
                    SerialNumber = "SN011"
                },

                new Asset()
                {
                    Id = 12,
                    TagNumber = "TAG012",
                    AssetTypeId = 4, // Monitor
                    ManufacturerId = 3, // Acer
                    ModelId = 13, // Acer S200
                    Description = "Acer S200 Monitor",
                    AssignedTo = "EMP004",
                    SerialNumber = "SN012"
                },

                new Asset()
                {
                    Id = 13,
                    TagNumber = "TAG013",
                    AssetTypeId = 4, // Monitor
                    ManufacturerId = 3, // Acer
                    ModelId = 14, // Acer STQ414
                    Description = "Acer STQ414 Monitor",
                    AssignedTo = "EMP001",
                    SerialNumber = "SN013"
                },

                new Asset()
                {
                    Id = 14,
                    TagNumber = "TAG014",
                    AssetTypeId = 4, // Monitor
                    ManufacturerId = 6, // LG
                    ModelId = 15, // LG 22MP
                    Description = "LG 22MP Monitor",
                    AssignedTo = "EMP002",
                    SerialNumber = "SN014"
                },

                new Asset()
                {
                    Id = 15,
                    TagNumber = "TAG015",
                    AssetTypeId = 4, // Monitor
                    ManufacturerId = 2, // HP
                    ModelId = 16, // HP Pavilion
                    Description = "HP Pavilion Monitor",
                    AssignedTo = "EMP003",
                    SerialNumber = "SN015"
                },

                new Asset()
                {
                    Id = 16,
                    TagNumber = "TAG016",
                    AssetTypeId = 5, // Mobile Phone
                    ManufacturerId = 4, // Apple
                    ModelId = 17, // Apple iPhone 5
                    Description = "Apple iPhone 5",
                    AssignedTo = "EMP004",
                    SerialNumber = "SN016"
                },

                new Asset()
                {
                    Id = 17,
                    TagNumber = "TAG017",
                    AssetTypeId = 5, // Mobile Phone
                    ManufacturerId = 4, // Apple
                    ModelId = 18, // Apple iPhone 6
                    Description = "Apple iPhone 6",
                    AssignedTo = "EMP001",
                    SerialNumber = "SN017"
                },

                new Asset()
                {
                    Id = 18,
                    TagNumber = "TAG018",
                    AssetTypeId = 5, // Mobile Phone
                    ManufacturerId = 5, // Samsung
                    ModelId = 19, // Samsung Galaxy S4
                    Description = "Samsung Galaxy S4",
                    AssignedTo = "EMP002",
                    SerialNumber = "SN018"
                },

                new Asset()
                {
                    Id = 19,
                    TagNumber = "TAG019",
                    AssetTypeId = 5, // Mobile Phone
                    ManufacturerId = 5, // Samsung
                    ModelId = 20, // Samsung Galaxy S5
                    Description = "Samsung Galaxy S5",
                    AssignedTo = "EMP003",
                    SerialNumber = "SN019"
                },

                new Asset()
                {
                    Id = 20,
                    TagNumber = "TAG020",
                    AssetTypeId = 5, // Mobile Phone
                    ManufacturerId = 5, // Samsung
                    ModelId = 21, // Samsung Galaxy Note5
                    Description = "Samsung Galaxy Note5",
                    AssignedTo = "EMP004",
                    SerialNumber = "SN020"
                },

                new Asset()
                {
                    Id = 21,
                    TagNumber = "TAG021",
                    AssetTypeId = 6, // Desk Phone
                    ManufacturerId = 7, // Avaya
                    ModelId = 22, // Avaya 9612G
                    Description = "Avaya 9612G Desk Phone",
                    AssignedTo = "EMP001",
                    SerialNumber = "SN021"
                },

                new Asset()
                {
                    Id = 22,
                    TagNumber = "TAG022",
                    AssetTypeId = 6, // Desk Phone
                    ManufacturerId = 8, // Polycom
                    ModelId = 23, // Polycom SoundPoint331
                    Description = "Polycom SoundPoint331 Desk Phone",
                    AssignedTo = "EMP002",
                    SerialNumber = "SN022"
                },

                new Asset()
                {
                    Id = 23,
                    TagNumber = "TAG023",
                    AssetTypeId = 6, // Desk Phone
                    ManufacturerId = 9, // Cisco
                    ModelId = 23, // Cisco SPA525G2
                    Description = "Cisco SPA525G2 Desk Phone",
                    AssignedTo = "EMP003",
                    SerialNumber = "SN023"
                }
            );

            modelBuilder.Entity<AssetType>().HasData(

                new { Id = 1, Name = "Desktop PC" },
                new { Id = 2, Name = "Laptop" },
                new { Id = 3, Name = "Tablet" },
                new { Id = 4, Name = "Monitor" },
                new { Id = 5, Name = "Mobile Phone" },
                new { Id = 6, Name = "Desk Phone" }
            );

            modelBuilder.Entity<Manufacturer>().HasData(
                new { Id = 1, Name = "Dell" },
                new { Id = 2, Name = "HP" },
                new { Id = 3, Name = "Acer" },
                new { Id = 4, Name = "Apple" },
                new { Id = 5, Name = "Samsung" },
                new { Id = 6, Name = "LG" },
                new { Id = 7, Name = "Avaya" },
                new { Id = 8, Name = "Polycom" },
                new { Id = 9, Name = "Cisco" }
            );

            modelBuilder.Entity<Model>().HasData(
                new { Id = 1, Name = "Dell Inspiron", ManufacturerID = 1 },
                new { Id = 2, Name = "Dell XPS", ManufacturerID = 1 },
                new { Id = 3, Name = "HP Elite", ManufacturerID = 2 },
                new { Id = 4, Name = "Acer Aspire", ManufacturerID = 3 },
                new { Id = 5, Name = "Dell Latitude E4550", ManufacturerID = 1 },
                new { Id = 6, Name = "Dell Latitude E5550", ManufacturerID = 1 },
                new { Id = 7, Name = "Apple MacBook Air", ManufacturerID = 4 },
                new { Id = 8, Name = "Apple MacBook Pro", ManufacturerID = 4 },
                new { Id = 9, Name = "Apple iPad mini", ManufacturerID = 4 },
                new { Id = 10, Name = "Apple iPad Air", ManufacturerID = 4 },
                new { Id = 11, Name = "Samsung Galaxy Tab3", ManufacturerID = 5 },
                new { Id = 12, Name = "Acer S200", ManufacturerID = 3 },
                new { Id = 13, Name = "Acer STQ414", ManufacturerID = 3 },
                new { Id = 14, Name = "LG 22MP", ManufacturerID = 6 },
                new { Id = 15, Name = "HP Pavilion", ManufacturerID = 2 },
                new { Id = 16, Name = "Apple iPhone 5", ManufacturerID = 4 },
                new { Id = 17, Name = "Apple iPhone 6", ManufacturerID = 4 },
                new { Id = 18, Name = "Samsung Galaxy S4", ManufacturerID = 5 },
                new { Id = 19, Name = "Samsung Galaxy S5", ManufacturerID = 5 },
                new { Id = 20, Name = "Samsung Galaxy Note5", ManufacturerID = 5 },
                new { Id = 21, Name = "Avaya 9612G", ManufacturerID = 7 },
                new { Id = 22, Name = "Polycom SoundPoint331", ManufacturerID = 8 },
                new { Id = 23, Name = "Cisco SPA525G2", ManufacturerID = 9 }
            );

        }
    }
}
