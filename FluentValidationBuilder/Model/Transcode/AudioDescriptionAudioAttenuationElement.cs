using System.Text.Json.Serialization;

namespace FluentValidationBuilder.Model.Transcode
{
    public class AudioDescriptionAudioAttenuationElement
    {
        [JsonPropertyName("type")]
        public AudioAttenuationType Type { get; set; }

        [JsonPropertyName("algorithm")]
        public AudioAttenuationAlgorithmType Algorithm { get; set; }

        [JsonPropertyName("value")]
        public double Value { get; set; }

        [JsonPropertyName("tolerance")]
        public double Tolerance { get; set; }
    
    }
}