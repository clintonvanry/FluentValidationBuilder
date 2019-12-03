using System;
using System.Text.Json.Serialization;

namespace FluentValidationBuilder.Model
{
    public class MetadataElement
    {
        [JsonPropertyName("correlationId")]
        public string CorrelationId { get; set; }

        [JsonPropertyName("callbackUrl")]
        public Uri CallBackUrl { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }

        [JsonPropertyName("reference")]
        public CallerReferenceElement Reference { get; set; }
    }
}