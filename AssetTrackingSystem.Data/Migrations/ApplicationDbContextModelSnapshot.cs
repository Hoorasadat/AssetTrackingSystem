﻿// <auto-generated />
using AssetTrackingSystem.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AssetTrackingSystem.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AssetTrackingSystem.Lib.Models.Asset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AssetTypeId")
                        .HasColumnType("int");

                    b.Property<string>("AssignedTo")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TagNumber")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AssetTypeId");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("ModelId");

                    b.ToTable("Assets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AssetTypeId = 1,
                            AssignedTo = "EMP001",
                            Description = "Dell Inspiron Desktop",
                            ManufacturerId = 1,
                            ModelId = 1,
                            SerialNumber = "SN001",
                            TagNumber = "TAG001"
                        },
                        new
                        {
                            Id = 2,
                            AssetTypeId = 1,
                            AssignedTo = "EMP002",
                            Description = "Dell XPS Desktop",
                            ManufacturerId = 1,
                            ModelId = 2,
                            SerialNumber = "SN002",
                            TagNumber = "TAG002"
                        },
                        new
                        {
                            Id = 3,
                            AssetTypeId = 1,
                            AssignedTo = "EMP003",
                            Description = "HP Elite Desktop",
                            ManufacturerId = 2,
                            ModelId = 3,
                            SerialNumber = "SN003",
                            TagNumber = "TAG003"
                        },
                        new
                        {
                            Id = 4,
                            AssetTypeId = 1,
                            AssignedTo = "EMP004",
                            Description = "Acer Aspire Desktop",
                            ManufacturerId = 3,
                            ModelId = 4,
                            SerialNumber = "SN004",
                            TagNumber = "TAG004"
                        },
                        new
                        {
                            Id = 5,
                            AssetTypeId = 2,
                            AssignedTo = "EMP001",
                            Description = "Dell Latitude E4550 Laptop",
                            ManufacturerId = 1,
                            ModelId = 5,
                            SerialNumber = "SN005",
                            TagNumber = "TAG005"
                        },
                        new
                        {
                            Id = 6,
                            AssetTypeId = 2,
                            AssignedTo = "EMP002",
                            Description = "Dell Latitude E5550 Laptop",
                            ManufacturerId = 1,
                            ModelId = 6,
                            SerialNumber = "SN006",
                            TagNumber = "TAG006"
                        },
                        new
                        {
                            Id = 7,
                            AssetTypeId = 2,
                            AssignedTo = "EMP003",
                            Description = "Apple MacBook Air Laptop",
                            ManufacturerId = 4,
                            ModelId = 7,
                            SerialNumber = "SN007",
                            TagNumber = "TAG007"
                        },
                        new
                        {
                            Id = 8,
                            AssetTypeId = 2,
                            AssignedTo = "EMP004",
                            Description = "Apple MacBook Pro Laptop",
                            ManufacturerId = 4,
                            ModelId = 8,
                            SerialNumber = "SN008",
                            TagNumber = "TAG008"
                        },
                        new
                        {
                            Id = 9,
                            AssetTypeId = 3,
                            AssignedTo = "EMP001",
                            Description = "Apple iPad mini Tablet",
                            ManufacturerId = 4,
                            ModelId = 10,
                            SerialNumber = "SN009",
                            TagNumber = "TAG009"
                        },
                        new
                        {
                            Id = 10,
                            AssetTypeId = 3,
                            AssignedTo = "EMP002",
                            Description = "Apple iPad Air Tablet",
                            ManufacturerId = 4,
                            ModelId = 11,
                            SerialNumber = "SN010",
                            TagNumber = "TAG010"
                        },
                        new
                        {
                            Id = 11,
                            AssetTypeId = 3,
                            AssignedTo = "EMP003",
                            Description = "Samsung Galaxy Tab3 Tablet",
                            ManufacturerId = 5,
                            ModelId = 12,
                            SerialNumber = "SN011",
                            TagNumber = "TAG011"
                        },
                        new
                        {
                            Id = 12,
                            AssetTypeId = 4,
                            AssignedTo = "EMP004",
                            Description = "Acer S200 Monitor",
                            ManufacturerId = 3,
                            ModelId = 13,
                            SerialNumber = "SN012",
                            TagNumber = "TAG012"
                        },
                        new
                        {
                            Id = 13,
                            AssetTypeId = 4,
                            AssignedTo = "EMP001",
                            Description = "Acer STQ414 Monitor",
                            ManufacturerId = 3,
                            ModelId = 14,
                            SerialNumber = "SN013",
                            TagNumber = "TAG013"
                        },
                        new
                        {
                            Id = 14,
                            AssetTypeId = 4,
                            AssignedTo = "EMP002",
                            Description = "LG 22MP Monitor",
                            ManufacturerId = 6,
                            ModelId = 15,
                            SerialNumber = "SN014",
                            TagNumber = "TAG014"
                        },
                        new
                        {
                            Id = 15,
                            AssetTypeId = 4,
                            AssignedTo = "EMP003",
                            Description = "HP Pavilion Monitor",
                            ManufacturerId = 2,
                            ModelId = 16,
                            SerialNumber = "SN015",
                            TagNumber = "TAG015"
                        },
                        new
                        {
                            Id = 16,
                            AssetTypeId = 5,
                            AssignedTo = "EMP004",
                            Description = "Apple iPhone 5",
                            ManufacturerId = 4,
                            ModelId = 17,
                            SerialNumber = "SN016",
                            TagNumber = "TAG016"
                        },
                        new
                        {
                            Id = 17,
                            AssetTypeId = 5,
                            AssignedTo = "EMP001",
                            Description = "Apple iPhone 6",
                            ManufacturerId = 4,
                            ModelId = 18,
                            SerialNumber = "SN017",
                            TagNumber = "TAG017"
                        },
                        new
                        {
                            Id = 18,
                            AssetTypeId = 5,
                            AssignedTo = "EMP002",
                            Description = "Samsung Galaxy S4",
                            ManufacturerId = 5,
                            ModelId = 19,
                            SerialNumber = "SN018",
                            TagNumber = "TAG018"
                        },
                        new
                        {
                            Id = 19,
                            AssetTypeId = 5,
                            AssignedTo = "EMP003",
                            Description = "Samsung Galaxy S5",
                            ManufacturerId = 5,
                            ModelId = 20,
                            SerialNumber = "SN019",
                            TagNumber = "TAG019"
                        },
                        new
                        {
                            Id = 20,
                            AssetTypeId = 5,
                            AssignedTo = "EMP004",
                            Description = "Samsung Galaxy Note5",
                            ManufacturerId = 5,
                            ModelId = 21,
                            SerialNumber = "SN020",
                            TagNumber = "TAG020"
                        },
                        new
                        {
                            Id = 21,
                            AssetTypeId = 6,
                            AssignedTo = "EMP001",
                            Description = "Avaya 9612G Desk Phone",
                            ManufacturerId = 7,
                            ModelId = 22,
                            SerialNumber = "SN021",
                            TagNumber = "TAG021"
                        },
                        new
                        {
                            Id = 22,
                            AssetTypeId = 6,
                            AssignedTo = "EMP002",
                            Description = "Polycom SoundPoint331 Desk Phone",
                            ManufacturerId = 8,
                            ModelId = 23,
                            SerialNumber = "SN022",
                            TagNumber = "TAG022"
                        },
                        new
                        {
                            Id = 23,
                            AssetTypeId = 6,
                            AssignedTo = "EMP003",
                            Description = "Cisco SPA525G2 Desk Phone",
                            ManufacturerId = 9,
                            ModelId = 23,
                            SerialNumber = "SN023",
                            TagNumber = "TAG023"
                        });
                });

            modelBuilder.Entity("AssetTrackingSystem.Lib.Models.AssetType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("AssetTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Desktop PC"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Laptop"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Tablet"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Monitor"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Mobile Phone"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Desk Phone"
                        });
                });

            modelBuilder.Entity("AssetTrackingSystem.Lib.Models.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Manufacturers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Dell"
                        },
                        new
                        {
                            Id = 2,
                            Name = "HP"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Acer"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Apple"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Samsung"
                        },
                        new
                        {
                            Id = 6,
                            Name = "LG"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Avaya"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Polycom"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Cisco"
                        });
                });

            modelBuilder.Entity("AssetTrackingSystem.Lib.Models.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ManufacturerID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerID");

                    b.ToTable("Models");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ManufacturerID = 1,
                            Name = "Dell Inspiron"
                        },
                        new
                        {
                            Id = 2,
                            ManufacturerID = 1,
                            Name = "Dell XPS"
                        },
                        new
                        {
                            Id = 3,
                            ManufacturerID = 2,
                            Name = "HP Elite"
                        },
                        new
                        {
                            Id = 4,
                            ManufacturerID = 3,
                            Name = "Acer Aspire"
                        },
                        new
                        {
                            Id = 5,
                            ManufacturerID = 1,
                            Name = "Dell Latitude E4550"
                        },
                        new
                        {
                            Id = 6,
                            ManufacturerID = 1,
                            Name = "Dell Latitude E5550"
                        },
                        new
                        {
                            Id = 7,
                            ManufacturerID = 4,
                            Name = "Apple MacBook Air"
                        },
                        new
                        {
                            Id = 8,
                            ManufacturerID = 4,
                            Name = "Apple MacBook Pro"
                        },
                        new
                        {
                            Id = 9,
                            ManufacturerID = 4,
                            Name = "Apple iPad mini"
                        },
                        new
                        {
                            Id = 10,
                            ManufacturerID = 4,
                            Name = "Apple iPad Air"
                        },
                        new
                        {
                            Id = 11,
                            ManufacturerID = 5,
                            Name = "Samsung Galaxy Tab3"
                        },
                        new
                        {
                            Id = 12,
                            ManufacturerID = 3,
                            Name = "Acer S200"
                        },
                        new
                        {
                            Id = 13,
                            ManufacturerID = 3,
                            Name = "Acer STQ414"
                        },
                        new
                        {
                            Id = 14,
                            ManufacturerID = 6,
                            Name = "LG 22MP"
                        },
                        new
                        {
                            Id = 15,
                            ManufacturerID = 2,
                            Name = "HP Pavilion"
                        },
                        new
                        {
                            Id = 16,
                            ManufacturerID = 4,
                            Name = "Apple iPhone 5"
                        },
                        new
                        {
                            Id = 17,
                            ManufacturerID = 4,
                            Name = "Apple iPhone 6"
                        },
                        new
                        {
                            Id = 18,
                            ManufacturerID = 5,
                            Name = "Samsung Galaxy S4"
                        },
                        new
                        {
                            Id = 19,
                            ManufacturerID = 5,
                            Name = "Samsung Galaxy S5"
                        },
                        new
                        {
                            Id = 20,
                            ManufacturerID = 5,
                            Name = "Samsung Galaxy Note5"
                        },
                        new
                        {
                            Id = 21,
                            ManufacturerID = 7,
                            Name = "Avaya 9612G"
                        },
                        new
                        {
                            Id = 22,
                            ManufacturerID = 8,
                            Name = "Polycom SoundPoint331"
                        },
                        new
                        {
                            Id = 23,
                            ManufacturerID = 9,
                            Name = "Cisco SPA525G2"
                        });
                });

            modelBuilder.Entity("AssetTrackingSystem.Lib.Models.Asset", b =>
                {
                    b.HasOne("AssetTrackingSystem.Lib.Models.AssetType", "AssetType")
                        .WithMany("Assets")
                        .HasForeignKey("AssetTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssetTrackingSystem.Lib.Models.Manufacturer", "Manufacturer")
                        .WithMany("Assets")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssetTrackingSystem.Lib.Models.Model", "Model")
                        .WithMany("Assets")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AssetType");

                    b.Navigation("Manufacturer");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("AssetTrackingSystem.Lib.Models.Model", b =>
                {
                    b.HasOne("AssetTrackingSystem.Lib.Models.Manufacturer", "Manufacturer")
                        .WithMany("Models")
                        .HasForeignKey("ManufacturerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("AssetTrackingSystem.Lib.Models.AssetType", b =>
                {
                    b.Navigation("Assets");
                });

            modelBuilder.Entity("AssetTrackingSystem.Lib.Models.Manufacturer", b =>
                {
                    b.Navigation("Assets");

                    b.Navigation("Models");
                });

            modelBuilder.Entity("AssetTrackingSystem.Lib.Models.Model", b =>
                {
                    b.Navigation("Assets");
                });
#pragma warning restore 612, 618
        }
    }
}
