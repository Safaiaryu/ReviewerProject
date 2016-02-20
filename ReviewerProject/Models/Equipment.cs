using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReviewerProject.Models
{
    public class Equipment
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public EquipmentTypesEnum.EquipmentType Type { get; set; }
        public int LoadBonus { get; set; }
        public int Price { get; set; }
        public List<Material> Recipie { get; set; }
    }
}