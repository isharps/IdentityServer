﻿using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace IdentityServer.Validation
{
    internal class RefreshTokenRequestValidator : IRefreshTokenRequestValidator
    {
        private readonly ISystemClock _clock;
        private readonly IRefreshTokenStore _refreshTokenStore;

        public RefreshTokenRequestValidator(
            ISystemClock clock,
            IRefreshTokenStore refreshTokenStore)
        {
            _clock = clock;
            _refreshTokenStore = refreshTokenStore;
        }

        public async Task<RefreshTokenValidationResult> ValidateAsync(RefreshTokenValidationRequest request)
        {
            var refreshToken = await _refreshTokenStore.FindRefreshTokenAsync(request.RefreshToken);
            if (refreshToken == null)
            {
                throw new ValidationException(OpenIdConnectValidationErrors.InvalidGrant, "Invalid refresh token");
            }
            if (_clock.UtcNow.UtcDateTime > refreshToken.Expiration)
            {
                await _refreshTokenStore.RevomeRefreshTokenAsync(refreshToken);
                throw new ValidationException(OpenIdConnectValidationErrors.InvalidGrant, "Refresh token has expired");
            }
            await _refreshTokenStore.RevomeRefreshTokenAsync(refreshToken);
            return new RefreshTokenValidationResult(Array.Empty<Claim>());
        }
    }
}
