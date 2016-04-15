using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VisionDemo.Startup))]
namespace VisionDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
