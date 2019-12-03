using System;
using System.Text.Json.Serialization;

namespace FluentValidationBuilder.Model
{
    public class VideoSequenceElement
    {
        [JsonPropertyName("type")]
        public SequenceType SequenceType { get; set; }

        [JsonPropertyName("url")]
        public Uri SlateUrl { get; set; }

        [JsonPropertyName("colour")]
        public string Colour { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }
    }
}