using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReviewerProject.Models
{
    public class Equipment
    {
        public enum EquipmentType
        {
            Sword,
            Daggers,
            Knuckles,
            Bow,
            Axe,
            Spear,
            Scythe,
            Ninjato,
            Katana,
            Club,
            Stave,
            Rod,
            Tome,
            Bell,
            Instrument,
            Firearm,
            Shield,
            Head,
            Torso,
            Legs,
            Accessory
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public EquipmentType Type { get; set; }
        public int LoadBonus { get; set; }
        public int Price { get; set; }
        public List<Material> Recipie { get; set; }
    }
}