using System;
using System.Text.Json.Serialization;
using FluentValidationBuilder.JsonConverter;

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

        // checkumAlgorithm
        [JsonConverter(typeof(ChecksumAlgorithmConverter))]
        [JsonPropertyName("checkumAlgorithm")]
        public ChecksumAlgorithmType ChecksumAlgorithm { get; set; }
    }
}