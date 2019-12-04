using System.Text.Json.Serialization;

namespace FluentValidationBuilder.Model.Transcode
{
    public class CallerReferenceElement
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}