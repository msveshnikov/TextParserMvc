using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TextParserMvc.Startup))]
namespace TextParserMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
