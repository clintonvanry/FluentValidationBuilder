using System.Text.Json.Serialization;

namespace FluentValidationBuilder.Model
{
    public class CallerReferenceElement
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}