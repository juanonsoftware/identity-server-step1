using System.Web.Http;
using Owin;
using Thinktecture.IdentityServer.AccessTokenValidation;

namespace MvcClient1
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // accept access tokens from identityserver and require a scope of 'api1'
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "http://localhost:44333",
                RequiredScopes = new[] { "api1" }
            });

            // configure web api
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            WebApiConfig.Register(config);

            // require authentication for all controllers
            config.Filters.Add(new AuthorizeAttribute());

            app.UseWebApi(config);
        }
    }
}