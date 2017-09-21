using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BWBlog.Startup))]
namespace BWBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
