using System.Text.Json.Serialization;

namespace FluentValidationBuilder.Model.Transcode
{
    public class AudioDescriptionAudioMappingElement
    {
        [JsonPropertyName("stream")]
        public string Stream { get; set; }

        [JsonPropertyName("map")]
        public string Map { get; set; }
    }
}