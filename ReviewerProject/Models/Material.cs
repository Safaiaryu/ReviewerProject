using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Key]
        public int ID { get; set; }

        [Display(Name="Material Name")]
        [StringLength(30)]
        public string MaterialName { get; set; }

        [Display(Name = "Description")]
        [StringLength(250)]
        public string Description { get; set; }

        [Display(Name = "Type")]
        public MaterialType Type { get; set; }
    }
}