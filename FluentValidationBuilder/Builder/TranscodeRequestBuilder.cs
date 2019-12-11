using System;
using FluentValidationBuilder.Mapper;
using FluentValidationBuilder.Model.ActiveMessage;
using FluentValidationBuilder.Model.Transcode;

namespace FluentValidationBuilder.Builder
{
    public class TranscodeRequestBuilder : ActiveMessageBuilder
    {
        private readonly IDataMapper<MetadataElement, ActiveMessage> metadataElementMapper;
        private readonly IDataMapper<InputElement, ActiveMessage> inputElementMapper;

        public TranscodeRequestBuilder(ActiveMessage message, 
            IDataMapper<MetadataElement, ActiveMessage> metadataElementMapper, 
            IDataMapper<InputElement, ActiveMessage> inputElementMapper) : base(message)
        {
            this.metadataElementMapper = metadataElementMapper;
            this.inputElementMapper = inputElementMapper;
        }

        public ActiveMessageBuilder build(TranscodeRequest request)
        {
            // the mapper order is important here as there is dependency to know how many items there will be 
            // in the active message
            metadataElementMapper.Map(request.Metadata,activeMessage);
            inputElementMapper.Map(request.Input,activeMessage);

            return this;
        }
    }
}