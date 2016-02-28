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
        public int ID { get; set; }
        public string Title { get; set; }
        public Type ThreadType { get; set;}

        public ICollection<Comment> Reviews { get; set; }
    }
}