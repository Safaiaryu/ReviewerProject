using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReviewerProject.Models
{
    public class Quest
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int StarLevel { get; set; }
        public int Time { get; set; }
        public List<string> Tasks { get; set; }
        public List<string> Prerequisites { get; set; }
        public List<string> Rewards { get; set; }
    }
}