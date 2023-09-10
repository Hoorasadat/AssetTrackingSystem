using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingSystem.Lib.Models
{
    public class Model
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        public int ManufacturerID { get; set; }

        public IList<Asset> Assets { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}
