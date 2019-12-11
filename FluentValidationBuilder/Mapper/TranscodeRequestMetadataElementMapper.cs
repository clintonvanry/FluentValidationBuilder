using System;
using FluentValidationBuilder.Model.ActiveMessage;
using FluentValidationBuilder.Model.Transcode;

namespace FluentValidationBuilder.Mapper
{
    public class TranscodeRequestMetadataElementMapper : IDataMapper<MetadataElement, ActiveMessage>
    {
        public ActiveMessage MapTo(MetadataElement @from)
        {
            throw new System.NotImplementedException();
        }

        public void Map(MetadataElement @from, ActiveMessage to)
        {
            var activeMessage = to;
            var requestMetadataElement = @from;

            activeMessage.CorrelationId = string.IsNullOrEmpty(requestMetadataElement?.CorrelationId)
                ? Guid.NewGuid().ToString()
                : requestMetadataElement.CorrelationId;

            if (requestMetadataElement.Reference != null)
            {
                activeMessage.Metadata = new Metadata
                {
                    Id = requestMetadataElement.Reference.Id, Name = requestMetadataElement.Reference.Name
                };
            }

            activeMessage.Region = MediaServerRegions.GetByName(requestMetadataElement.Region);
            activeMessage.Url = requestMetadataElement.CallBackUrl.ToString();

        }
    }
}