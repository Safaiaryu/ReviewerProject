using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReviewerProject.Models
{
    public class Ability
    {
        public string Name { get; set; }
        public Job ProficitentClass { get; set; }
        public int Load { get; set; }
        public int APCost { get; set; }
        public double CoolDown { get; set; }
        public int Power { get; set; }
        public List<ElementTypeEnum.Element> ElementType { get; set; }
        public string Description { get; set; }
    }
}