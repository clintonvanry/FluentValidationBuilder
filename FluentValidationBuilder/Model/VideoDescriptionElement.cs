using System.Text.Json.Serialization;

namespace FluentValidationBuilder.Model
{
    public class VideoDescriptionElement
    {
        [JsonPropertyName("sequence")]
        public VideoDescriptionSequenceElement Sequence { get; set; }

        [JsonPropertyName("firstFrameTimecode")]
        public string FirstFrameTimecode { get; set; }

        [JsonPropertyName("conversion")]
        public VideoDescriptionConversionElement Conversion { get; set; }
    }
}
