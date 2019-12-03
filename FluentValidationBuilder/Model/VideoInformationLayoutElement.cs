using System.Text.Json.Serialization;

namespace FluentValidationBuilder.Model
{
    public class VideoInformationLayoutElement
    {
        [JsonPropertyName("preRoll")]
        public int PreRoll { get; set; }

        [JsonPropertyName("postRoll")]
        public int PostRoll { get; set; }
    }
}