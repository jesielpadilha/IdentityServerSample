using System;
using System.Collections.Generic;
using IdentityServer4.Models;

namespace IdentityServerSample.Hosting.Models
{
    public class Config
    {
        public static IEnumerable<Client> Clients() =>
            new List<Client>()
            {
                new Client
                {
                    ClientId = "mvc-client",
                    ClientName = "My MVC Client",
                    ClientSecrets = { new Secret("segredo".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris = {
                        "http://localhost:9090",
                        "https://localhost:9091",
                        "https://localhost:9090/signin-oidc",
                        "https://localhost:9091/signin-oidc"
                    },
                    AllowedScopes = { "openid", "profile", "email" }
                }
            };
        public static IEnumerable<IdentityResource> IdentityResources() =>
            new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };

        public static IEnumerable<ApiResource> ApiResources() =>
            new List<ApiResource>()
            {
                new ApiResource("HumanResources"),
                new ApiResource("Finantial")
                {
                    Scopes = { "Finantial.Read", "Finantial.Write" }
                },
            };
    }
}