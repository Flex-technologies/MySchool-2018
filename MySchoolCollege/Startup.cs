using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MySchoolCollege.Startup))]
namespace MySchoolCollege
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
