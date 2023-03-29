﻿using IdentityServer.Models;
using IdentityServer.Validation;

namespace Hosting.Configuration
{
    public class ResourceOwnerCredentialRequestValidator : IResourceOwnerCredentialRequestValidator
    {
        public Task<ResourceOwnerCredentialValidationResult> ValidateAsync(ResourceOwnerCredentialValidationRequest context)
        {
            if (context.Username == "test" && context.Password == "test")
            {
                return Task.FromResult(new ResourceOwnerCredentialValidationResult("10"));
            }
            throw new ValidationException(ValidationErrors.InvalidGrant, "用户名或密码错误");
        }
    }
}
