﻿namespace IdentityServer.Models
{
    internal static class OpenIdConnectConstants
    {
        public static class EndpointNames
        {
            public const string Authorize = "Authorize";
            public const string Token = "Token";
            public const string Discovery = "Discovery";
            public const string DiscoveryJwks = "Jwks";
            public const string UserInfo = "Userinfo";
            public const string Introspection = "Introspection";
        }

        public static class EndpointRutePaths
        {

            public const string Authorize = "authorize";

            public const string Discovery = "/.well-known/openid-configuration";
            
            public const string DiscoveryJwks = Discovery + "/jwks";

            public const string Token = "token";

            public const string UserInfo = "userinfo";

            public const string Introspection = "introspect";
        }

        public static class Endpoints
        {
            public const string Authorize = "/authorize";

            public const string Discovery = "/.well-known/openid-configuration";
                         
            public const string DiscoveryJwks = Discovery + "/jwks";
                         
            public const string Token = "/token";
                         
            public const string UserInfo = "/userinfo";
                         
            public const string Introspection = "/introspect";
        }

        public static class AuthenticationSchemes
        {
            public const string AuthorizationHeaderBearer = "Bearer";
            public const string FormPostBearer = "access_token";
            public const string QueryStringBearer = "access_token";
            public const string AuthorizationHeaderPop = "PoP";
            public const string FormPostPop = "pop_access_token";
            public const string QueryStringPop = "pop_access_token";
        }

        public static class ClaimTypeFilters
        {
            public static readonly string[] ClaimsServiceFilterClaimTypes =
            {
                JwtClaimTypes.Subject,
                JwtClaimTypes.AccessTokenHash,
                JwtClaimTypes.Audience,
                JwtClaimTypes.AuthenticationMethod,
                JwtClaimTypes.AuthenticationTime,
                JwtClaimTypes.AuthorizedParty,
                JwtClaimTypes.AuthorizationCodeHash,
                JwtClaimTypes.ClientId,
                JwtClaimTypes.Expiration,
                JwtClaimTypes.IdentityProvider,
                JwtClaimTypes.IssuedAt,
                JwtClaimTypes.Issuer,
                JwtClaimTypes.JwtId,
                JwtClaimTypes.Nonce,
                JwtClaimTypes.NotBefore,
                JwtClaimTypes.ReferenceTokenId,
                JwtClaimTypes.SessionId,
                JwtClaimTypes.Scope,
                JwtClaimTypes.Confirmation,
            };
        }
    }
}
