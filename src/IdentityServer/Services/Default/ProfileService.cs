﻿using System.Security.Claims;

namespace IdentityServer.Services
{
    internal class ProfileService : IProfileService
    {
        public Task<bool> IsActiveAsync(IsActiveRequest request)
        {
            return Task.FromResult(true);
        }

        public Task<IEnumerable<Claim>> GetProfileClaimsAsync(ProfileClaimsRequest request)
        {
            IEnumerable<Claim> result = Array.Empty<Claim>();
            return Task.FromResult(result);
        }

        public Task<IEnumerable<Claim>> GetAccessTokenClaimsAsync(ProfileClaimsRequest request)
        {
            IEnumerable<Claim> result = Array.Empty<Claim>();
            return Task.FromResult(result);
        }

        public Task<IEnumerable<Claim>> GetIdentityTokenClaimsAsync(ProfileClaimsRequest request)
        {
            IEnumerable<Claim> result = Array.Empty<Claim>();
            return Task.FromResult(result);
        }
    }
}
