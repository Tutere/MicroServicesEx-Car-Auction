﻿using Duende.IdentityServer.Models;

namespace IdentityService;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("auctionApp", "Auction app full access"),
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
          new Client { //to match the resources and api scope mentioned above
            ClientId = "postman",
            ClientName = "Postman",
            AllowedScopes = {"openid", "profile", "auctionApp"},
            RedirectUris = {"https://www.getpostman.com/oauth2/callback"}, //not actually used
            ClientSecrets = new [] {new Secret("NotASecret".Sha256())},
            AllowedGrantTypes = {GrantType.ResourceOwnerPassword}
          }
        };
}
