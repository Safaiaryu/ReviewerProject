using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Key]
        public int ID { get; set; }

        [Display(Name = "Equipment Name")]
        [StringLength(30)]
        public string Name { get; set; }

        [Display(Name="Equipment Type")]
        public EquipmentType Type { get; set; }

        [Display(Name="Load Bonus")]
        [Range(0,15)]
        public int LoadBonus { get; set; }

        [Display(Name = "Price")]
        [Range(0,20000)]
        public int Price { get; set; }

        [Display(Name = "Build Recipie")]
        public List<Material> Recipie { get; set; }

        
    }
}