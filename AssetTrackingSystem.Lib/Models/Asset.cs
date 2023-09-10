using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingSystem.Lib.Models
{
    public class Asset
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string? TagNumber { get; set; }

        public int AssetTypeId { get; set; }

        public int ManufacturerId { get; set; }

        public int ModelId { get; set; }

        [MaxLength(100)]
        public string? Description { get; set; }

        [MaxLength(20)]
        public string? AssignedTo { get; set; }

        [MaxLength(100)]
        public string SerialNumber { get; set; }

        public AssetType? AssetType { get; set; }
        public Manufacturer? Manufacturer { get; set; }
        public Model? Model { get; set; }
    }
}