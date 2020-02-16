//using Microsoft.Owin;
//using Owin;
//[assembly: OwinStartup(typeof(SignalRChat.Startup))]
//namespace SignalRChat
//{
//    public class Startup
//    {
//        public void Configuration(IAppBuilder app)
//        {
//            // Any connection or hub wire up and configuration should go here
//            app.MapSignalR();
//        }
//    }
//}
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNet.SignalR;
using System;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Owin;

namespace SignalRChat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/signalr", map =>
            {
                //map.UseCors(CorsOptions.AllowAll);
                var hubConfig = new HubConfiguration
                {
                    EnableDetailedErrors = true,
                    EnableJavaScriptProxies = true,
                };

                //map.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions()
                //{
                //    Provider = new QueryStringOAuthBearerProvider()
                //});

                map.RunSignalR(hubConfig);
            });

            //GlobalHost.DependencyResolver.Register(typeof(JsonSerializer), () => JsonSerializer.Create(
            //    new JsonSerializerSettings()
            //    {
            //        ContractResolver = new SignalRContractResolver()
            //    })
            //);

        }
    }

}
