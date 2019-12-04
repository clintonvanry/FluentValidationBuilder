using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FluentValidationBuilder.Model.Transcode
{
    public class AudioDescriptionElement
    {
        [JsonPropertyName("audioMapping")]
        public IList<AudioDescriptionAudioMappingElement> AudioMapping { get; set; }

        public IList<AudioDescriptionAudioAttenuationElement> AudioAttenuation { get; set; }
    }
}