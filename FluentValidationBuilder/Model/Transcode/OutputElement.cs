using System.Text.Json.Serialization;

namespace FluentValidationBuilder.Model.Transcode
{
    public class OutputElement
    {
        [JsonPropertyName("preset")]
        public string Preset { get; set; }

        [JsonPropertyName("fileUrl")]
        public string FileUrl { get; set; }

        [JsonPropertyName("videoDescription")]
        public VideoDescriptionElement VideoDescription { get; set; }

    }
}