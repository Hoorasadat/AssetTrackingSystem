using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingSystem.Lib.Models
{
    public class Asset
    {
        public int Id { get; set; }
        public string? TagNumber { get; set; }
        public int AssetTypeId { get; set; }
        public int ManufacturerId { get; set; }
        public int ModelId { get; set; }
        public string? Description { get; set; }
        public string? AssignedTo { get; set; }
        public string SerialNumber { get; set; }
        public AssetType AssetType { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public Model Model { get; set; }
    }
}