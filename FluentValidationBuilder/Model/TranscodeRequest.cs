using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FluentValidationBuilder.Model
{

    public class TranscodeRequest
    {
        [JsonPropertyName("metadata")]
        public MetadataElement Metadata { get; set; }

        [JsonPropertyName("input")]
        public InputElement Input { get; set; }

        [JsonPropertyName("outputs")]
        public IList<OutputElement> Outputs { get; set; }

    }

}
