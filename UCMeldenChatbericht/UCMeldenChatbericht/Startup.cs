using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UCMeldenChatbericht.Startup))]
namespace UCMeldenChatbericht
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
