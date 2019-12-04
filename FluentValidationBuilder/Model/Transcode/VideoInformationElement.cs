using System.Text.Json.Serialization;

namespace FluentValidationBuilder.Model.Transcode
{
    public class VideoInformationElement
    {
        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        [JsonPropertyName("layout")]
        public VideoInformationLayoutElement Layout { get; set; }

    }
}