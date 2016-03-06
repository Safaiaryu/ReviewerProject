using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReviewerProject.Models
{
    public class Ability
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Ability Name")]
        [StringLength(30)]
        public string Name { get; set; }

        [Display(Name="Proficitent Class")]
        public Job ProficitentClass { get; set; }

        [Display(Name = "Load")]
        [Range(0,100)]
        public int Load { get; set; }

        [Display(Name="AP Cost")]
        [Range(0,380)]
        public int APCost { get; set; }

        [Display(Name="Cool Down")]
        public double CoolDown { get; set; }

        [Display(Name = "Power")]
        [Range(0,400)]
        public int Power { get; set; }

        [Display(Name="Element Type")]
        public List<ElementTypeEnum.Element> ElementType { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}