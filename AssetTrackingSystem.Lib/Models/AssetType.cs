using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingSystem.Lib.Models
{
    public class AssetType
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }

        public IList<Asset> Assets { get; set; }
    }
}
