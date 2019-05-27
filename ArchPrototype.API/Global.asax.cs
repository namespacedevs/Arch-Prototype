using System.Web;
using System.Web.Http;
using ProntotipoInterisk.API.App_Start;

namespace ProntotipoInterisk.API
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(SimpleInjectorWebApiInitializer.Register);
        }
    }
}