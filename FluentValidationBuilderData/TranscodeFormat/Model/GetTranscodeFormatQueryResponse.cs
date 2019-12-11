using System.Collections.Generic;

namespace FluentValidationBuilderData.TranscodeFormat.Model
{
    public class GetTranscodeFormatQueryResponse
    {
        public IEnumerable<TranscodeFormat> Formats = new List<TranscodeFormat>();

        public class TranscodeFormat
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string TranscodePackage { get; set; }

            public string Settings { get; set; }

            public bool IsClosedCaption { get; set; }
        }
    }
}