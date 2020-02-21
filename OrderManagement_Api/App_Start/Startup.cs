using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;

[assembly: OwinStartup(typeof(OrderManagement_Api.App_Start.Startup))]

namespace OrderManagement_Api.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {

                AllowInsecureHttp = true,
                // The Path for Generating the token
                TokenEndpointPath = new PathString("/token"),
                // Setting the Token Expired Time(24 hours)
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(8),

                //MyAuthorizationServerProvider class will validate the user credentials
                Provider = new MyAuthorizationServiceProvider()

            };


            // Token Generation

            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());


            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);

        }
    }
}
