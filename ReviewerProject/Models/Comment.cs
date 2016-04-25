using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace ReviewerProject.Models
{
    public class Comment
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Content")]
        public string Content { get; set; }

        [Display(Name="Thread ID")]
        public int ThreadID { get; set; }

        public string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }
        //[Display(Name="User")]
        //public int UserID { get; set; }

    }
}