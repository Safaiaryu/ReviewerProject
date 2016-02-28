using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReviewerProject.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public int ThreadID { get; set; }
    }
}