using System;
using System.Collections.Generic;
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
        public int ID { get; set; }
        public string MonsterName { get; set; }
        public string Description { get; set; }
        public int CreateCost { get; set; }
        public int Load { get; set; }
        public MonsterType Type { get; set; }
        public bool CanCapture { get; set; }
    }
}