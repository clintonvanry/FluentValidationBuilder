using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FluentValidationBuilder.Model.Transcode
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
