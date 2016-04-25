using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReviewerProject.Models
{
    public class GameTips
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Title")]
        [StringLength(30)]
        public string Title { get; set; }

        [Display(Name = "Content")]
        [StringLength(254)]
        public string Content { get; set; }

        [Display(Name = "Image URL")]
        public string ImageURL { get; set; }

        [Display(Name = "Ediolon ID")]
        public int EidolonID { get; set; }

        [Display(Name = "Job ID")]
        public int JobID { get; set; }

        [Display(Name = "Quest ID")]
        public int QuestID { get; set; }
    }
}