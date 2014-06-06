using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BaseDeDatos.Startup))]
namespace BaseDeDatos
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
