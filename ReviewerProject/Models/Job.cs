﻿using System;
using System.Collections.Generic;
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
            Axe,
            Artillery
        }

        public int ID { get; set; }
        public string JobName { get; set; }
        public int BaseHP { get; set; }
        public int BaseAP { get; set; }
        public int BaseLoad { get; set; }
        public string Description {get; set;}
        public List<Equipment> UsableEquipment { get; set; }
        public Proficiencies JobProficiencies { get; set; }
    }
}