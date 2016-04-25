using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReviewerProject.Models
{
    public class Monster
    {
        public enum MonsterType
        {
            Goblin,
            Bomb,
            Chocobo,
            Bird,
            Toad,
            Lamia,
            Mandragora,
            Malboro,
            Forfex, 
            Turtle,
            Ghost, 
            Ahriman,
            Demon,
            Lizard, 
            Coeurl,
            IronGiant,
            Mech,
            Skeleton,
            Bat,
            Cactuar,
            MagicPot
        }

        [Key]
        public int ID { get; set; }

        [Display(Name = "Monster Name")]
        [StringLength(50)]
        public string MonsterName { get; set; }

        [Display(Name = "Description")]
        [StringLength(250)]
        public string Description { get; set; }

        [Display(Name="Create Cost")]
        [Range(0, 15000)]
        public int CreateCost { get; set; }

        [Display(Name = "Load")]
        [Range(100,300)]
        public int Load { get; set; }

        [Display(Name = "Monster Type")]
        public MonsterType Type { get; set; }

        [Display(Name = "Can Capture")]
        public bool CanCapture { get; set; }

    }
}