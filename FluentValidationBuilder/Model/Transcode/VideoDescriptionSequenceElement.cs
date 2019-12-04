using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FluentValidationBuilder.Model.Transcode
{
    public class VideoDescriptionSequenceElement
    {
        [JsonPropertyName("header")]
        public IList<VideoSequenceElement> Header { get; set; }

        [JsonPropertyName("tail")]
        public IList<VideoSequenceElement> Tail { get; set; }
    }
}