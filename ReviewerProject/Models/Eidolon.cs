using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReviewerProject.Models
{
    public class Eidolon
    {
        [Key]
        public int ID { get; set; }

        [Display(Name="Eidolon Name")]
        [StringLength(20)]
        public string EidolonName { get; set; }

        [Display(Name = "Description")]
        [StringLength(100)]
        public string Description { get; set; }

        [Display(Name = "Magicite")]
        public Material Magicite { get; set; }

        [Display(Name="Magicite Ability")]
        [StringLength(100)]
        public string MagiciteAbilty { get; set; }

        [Display(Name="Quests Found")]
        public List<Quest> QuestsFound { get; set; }
    }
}