namespace ReviewerProject.Migrations
{
    using ReviewerProject.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ReviewerProject.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "ReviewerProject.Models.ApplicationDbContext";
        }

        protected override void Seed(ReviewerProject.Models.ApplicationDbContext context)
        {
            //new Job
            //{
            //    JobName = "White Mage",
            //    BaseHP = 3650,
            //    BaseAP = 2830,
            //    BaseLoad = 150,
            //    Description = "(Healer) Starts with the highest Spirit. Your primary role will be " +
            //                "healing allies with white magic. You can also restore AP to allies using " +
            //                "the unipue ability Beseech.",
            //    JobProficiencies = (Job.Proficiencies)Enum.Parse(typeof(Job.Proficiencies), "White")
                

            //};

            //new Ability
            //{
            //    Name = "Cure",
            //    Load = 10,
            //    APCost = 60,
            //    CoolDown = 5,
            //    Power = 100, 
            //    Description = "Restore a small amount of HP to a locked ally, or yourself if no ally is locked."
            //};
        }
    }
}
