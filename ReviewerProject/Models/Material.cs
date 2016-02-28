using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReviewerProject.Models
{
    public class Material
    {
        public enum MaterialType
        {
            Rarity1, 
            Rarity2, 
            Rarity3,
            Atmaliths, 
            Magicite
        }

        public int ID { get; set; }
        public string MaterialName { get; set; }
        public string Description { get; set; }
        public MaterialType Type { get; set; }
    }
}