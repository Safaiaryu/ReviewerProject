using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReviewerProject.Startup))]
namespace ReviewerProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
