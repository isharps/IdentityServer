﻿using Microsoft.AspNetCore.Http;
using System.Net.Mime;

namespace IdentityServer.Endpoints
{
    public class JwkDiscoveryResult : IEndpointResult
    {
        public JwkDiscoveryGeneratorResponse _response;

        public JwkDiscoveryResult(JwkDiscoveryGeneratorResponse response)
        {
            _response = response;
        }

        public async Task ExecuteAsync(HttpContext context)
        {
            var json = _response.Serialize();
            context.Response.ContentType = MediaTypeNames.Application.Json;
            await context.Response.WriteAsync(json, System.Text.Encoding.UTF8);
        }
    }
}
