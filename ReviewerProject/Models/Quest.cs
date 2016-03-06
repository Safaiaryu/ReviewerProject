using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReviewerProject.Models
{
    public class Quest
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Star Level")]
        [Range(1, 10)]
        public int StarLevel { get; set; }

        [Display(Name = "Time Limit")]
        public int Time { get; set; }

        [Display(Name = "Tasks")]
        public List<string> Tasks { get; set; }

        [Display(Name = "Prerequisites")]
        public List<string> Prerequisites { get; set; }

        [Display(Name = "Rewards")]
        public List<string> Rewards { get; set; }
    }
}