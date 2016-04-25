using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReviewerProject.Models
{
    public class Job
    {
        public enum Proficiencies
        {
            Sword,
            Knuckle,
            Bow,
            Katana,
            Spear,
            Axe,
            White,
            Black,
            Time,
            Advanced,
            Basic,
            Intermediate,
            Blue,
            Dagger,
            Club,
            Firearm,
            Recovery,
            Support,
            Artillery
        }

        [Key]
        public int ID { get; set; }

        [Display(Name="Job Name")]
        [StringLength(20)]
        public string JobName { get; set; }

        [Display(Name="Base HP")]
        [Range(0,5000)]
        public int BaseHP { get; set; }

        [Display(Name = "Base AP")]
        [Range(0,5000)]
        public int BaseAP { get; set; }

        [Display(Name = "Base Load")]
        [Range(100,300)]
        public int BaseLoad { get; set; }

        [Display(Name = "Description")]
        [StringLength(250)]
        public string Description {get; set;}

        [Display(Name = "Usable Equipment")]
        public List<Equipment> UsableEquipment { get; set; }

        [Display(Name = "Job Proficiencies")]
        public Proficiencies JobProficiencies { get; set; }


        [Display(Name = "Tips")]
        public List<GameTips> Tips { get; set; }
    }
}