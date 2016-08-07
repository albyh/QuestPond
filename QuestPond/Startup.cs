using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuestPond.Startup))]
namespace QuestPond
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
