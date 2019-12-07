using System;
using System.Text;

namespace FluentValidationBuilder.Model.ActiveMessage
{
    public class ActiveMessage
    {
        public CallerType Caller { get; set; }

        public string CorrelationId { get; set; }

        public ActiveMessageStatus Status { get; set; }

        public int Version { get; set; }

        public ProductType Product { get; set; }

        public DateTime Deadline { get; set; }

        public Metadata Metadata { get; set; }

        public string Url { get; set; }

        public int Port { get; set; }

        public int Duration { get; set; }

        public MediaServerRegion Region { get; set; }

        public DateTime CreatedOn { get; set; }

        public long Size { get; set; }

        public ProviderType Provider { get; set; }

        public TranscodeBody Body { get; set; }
    }
}
