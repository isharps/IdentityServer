﻿using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace IdentityServer.Validation
{
    internal class BearerTokenUsageParser : ITokenParser
    {
        public async Task<string?> ParserAsync(HttpContext context)
        {
            if (context.Request.Headers.Authorization.Any())
            {
                string authorization = context.Request.Headers.Authorization.ToString();
                if (authorization.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                {
                    var token = authorization["Bearer ".Length..].Trim();
                    if (!string.IsNullOrEmpty(token))
                    {
                        return token;
                    }
                }
            }
            else if (context.Request.HasFormContentType)
            {
                var form = await context.Request.ReadFormAsync();
                var token = form[OpenIdConnectParameterNames.AccessToken].FirstOrDefault();
                if (!string.IsNullOrEmpty(token))
                {
                    return token;
                }
            }
            else
            {
                var token = context.Request.Query[OpenIdConnectParameterNames.AccessToken].FirstOrDefault();
                if (!string.IsNullOrEmpty(token))
                {
                    return token;
                }
            }
            return null;
        }
    }
}
