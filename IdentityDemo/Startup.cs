using Owin;
using Thinktecture.IdentityServer.Core.Configuration;

namespace IdentityDemo
{
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var factory = InMemoryFactory.Create(
                scopes: Scopes.Get(),
                clients: Clients.Get(),
                users: Users.Get());

            var options = new IdentityServerOptions
            {
                Factory = factory,
                RequireSsl = false
            };

            app.UseIdentityServer(options);
        }
    }
}
