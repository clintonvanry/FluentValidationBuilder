using System;
using System.Text.Json.Serialization;

namespace FluentValidationBuilder.Model.Transcode
{
    public class OutputElement
    {
        [JsonPropertyName("preset")]
        public string Preset { get; set; }

        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        [JsonPropertyName("videoDescription")]
        public VideoDescriptionElement VideoDescription { get; set; }

        [JsonPropertyName("audioDescription")]
        public AudioDescriptionElement AudioDescription { get; set; }

    }
}