﻿using IdentityServer.Storage.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace IdentityServer.Serialization
{
    public static class ObjectSerializer
    {
        public readonly static JsonSerializerOptions JsonSerializerOptions;

        static ObjectSerializer()
        {
            JsonSerializerOptions = new JsonSerializerOptions
            {
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            };
            JsonSerializerOptions.Converters.Add(new ClaimJsonConverter());
        }

        public static string Serialize(object obj)
        {
            return JsonSerializer.Serialize(obj, JsonSerializerOptions);
        }

        public static T? Deserialize<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json, JsonSerializerOptions);
        }
    }
}
