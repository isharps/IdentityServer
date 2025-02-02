﻿using IdentityServer.Models;

namespace IdentityServer.EntityFramework.Entities
{
    public class IdentityResourceEntity : ResourceEntity
    {
        public bool Required { get; set; } = false;

        public string Scope => Name;

        public IdentityResource Cast()
        {
            return new IdentityResource(Name)
            {
                Required = Required,
                Enabled = Enabled,
                DisplayName = DisplayName,
                Description = Description,
                ShowInDiscoveryDocument = ShowInDiscoveryDocument,
                ClaimTypes = ClaimTypes.Select(s => s.Data).ToArray(),
            };
        }

        public static implicit operator IdentityResourceEntity(IdentityResource resource)
        {
            return new IdentityResourceEntity
            {
                Required = resource.Required,
                Enabled = resource.Enabled,
                DisplayName = resource.DisplayName,
                Description = resource.Description,
                ShowInDiscoveryDocument = resource.ShowInDiscoveryDocument,
                ClaimTypes = resource.ClaimTypes.Select(s => new StringEntity(s)).ToArray(),
                Name = resource.Name,
            };
        }
    }
}
