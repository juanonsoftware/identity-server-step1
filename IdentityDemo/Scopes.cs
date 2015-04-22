using System.Collections.Generic;
using Thinktecture.IdentityServer.Core.Models;

namespace IdentityDemo
{
    class Scopes
    {
        public static List<Scope> Get()
        {
            return new List<Scope>
            {
                new Scope
                {
                    Name = "api1"
                }
            };
        }
    }
}
