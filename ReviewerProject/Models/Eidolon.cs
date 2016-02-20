using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReviewerProject.Models
{
    public class Eidolon
    {
        public int ID { get; set; }
        public string EidolonName { get; set; }
        public string Description { get; set; }
        public Material Magicite { get; set; }
        public string MagiciteAbilty { get; set; }
        public List<Quest> QuestsFound { get; set; }
    }
}