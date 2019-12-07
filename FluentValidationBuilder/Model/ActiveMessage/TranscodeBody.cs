using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FluentValidationBuilder.Model.ActiveMessage
{
    public class TranscodeBody
    {
        [JsonPropertyName("Items")]
        public IList<TranscodeItem> Items { get; set; }

        [JsonPropertyName("Endpoint")]
        public string Endpoint { get; set; }


        [JsonPropertyName("Priority")]
        public int Priority { get; set; }

        [JsonPropertyName("CustomValues")]
        public IList<TranscodeCustomValue> CustomValues { get; set; }

        
        [JsonPropertyName("TargetBucket")]
        public string TargetBucket { get; set; }

        [JsonPropertyName("CorrelationId")]
        public string CorrelationId { get; set; }


        [JsonPropertyName("CallbackEndpoint")]
        public string CallbackEndpoint { get; set; }


        [JsonPropertyName("TargetStorageProvider")]
        public string TargetStorageProvider { get; set; }


        [JsonPropertyName("TargetStorageProviderUser")]
        public string TargetStorageProviderUser { get; set; }


        [JsonPropertyName("TargetStorageProviderPassword")]
        public string TargetStorageProviderPassword { get; set; }
    }
}