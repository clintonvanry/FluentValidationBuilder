using System.Text.Json.Serialization;

namespace FluentValidationBuilder.Model.Transcode
{
    public class InputElement
    {
        [JsonPropertyName("file")]
        public InputFileElement File { get; set; }


        [JsonPropertyName("videoInformation")]
        public VideoInformationElement VideoInformation { get; set; }
    }
}