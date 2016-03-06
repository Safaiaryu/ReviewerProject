using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReviewerProject.Models
{
    public class Thread
    {
        //This will reference what page each Thread belongs on
        public enum Type
        {
            BugFix, 
            Review
        }

        //Ability to search
        public enum Category
        {
            UserInterface, 
            Party, 
            Monsters, 
            Drops, 
            Upgrades, 
            Equipment, 
            CrystalSerges, 
            QuestObjectives, 
            Rooms, 
            Help,
            Materials
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public Type ThreadType { get; set;}
        public Category CategoryType { get; set; }

        public ICollection<Comment> Reviews { get; set; }
    }
}