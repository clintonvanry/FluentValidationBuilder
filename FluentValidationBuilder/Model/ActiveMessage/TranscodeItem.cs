using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FluentValidationBuilder.Model.ActiveMessage
{
    public class TranscodeItem
    {
        [JsonPropertyName("Size")]
        public long FileSize { get; set; }

        [JsonPropertyName("Tasks")]
        public IList<TranscodeTask> Tasks { get; set; }

        [JsonPropertyName("CheckSum")]
        public string CheckSum { get; set; }

        [JsonPropertyName("FormatId")]
        public int FormatId { get; set; }

        [JsonPropertyName("Priority")]
        public int Priority { get; set; }

        [JsonPropertyName("SourceKey")]
        public string SourceKey { get; set; }

        [JsonPropertyName("TargetMD5")]
        public string TargetMD5 { get; set; }

        [JsonPropertyName("FrameCount")]
        public int FrameCount { get; set; }

        [JsonPropertyName("SourceFile")]
        public string SourceFile { get; set; }

        [JsonPropertyName("TargetFile")]
        public string TargetFile { get; set; }

        [JsonPropertyName("TargetSHA1")]
        public string TargetSHA1 { get; set; }

        [JsonPropertyName("CustomValues")]
        public IList<TranscodeCustomValue> CustomValues { get; set; }

        [JsonPropertyName("SourceBucket")]
        public string SourceBucket { get; set; }

        [JsonPropertyName("SourceRegion")]
        public string SourceRegion { get; set; }

        [JsonPropertyName("TargetFolder")]
        public string TargetFolder { get; set; }

        [JsonPropertyName("SourceFileUri")]
        public string SourceFileUri { get; set; }

        [JsonPropertyName("TargetFileUri")]
        public string TargetFileUri { get; set; }
    }
}