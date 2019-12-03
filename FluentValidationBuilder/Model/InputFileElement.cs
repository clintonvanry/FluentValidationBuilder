using System;
using System.Text.Json.Serialization;

namespace FluentValidationBuilder.Model
{
    public class InputFileElement
    {
        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        [JsonPropertyName("size")]
        public long Size { get; set; }

        [JsonPropertyName("checksum")]
        public string Checksum { get; set; }
    }
}