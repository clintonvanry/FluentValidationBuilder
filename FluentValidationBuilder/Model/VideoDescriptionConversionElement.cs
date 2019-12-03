using System.Text.Json.Serialization;

namespace FluentValidationBuilder.Model
{
    public class VideoDescriptionConversionElement
    {
        [JsonPropertyName("standard")]
        public VideoStandardType Standard { get; set; }

        [JsonPropertyName("aspectRatio")]
        public VideoAspectRatioType AspectRatio { get; set; }
    }
}