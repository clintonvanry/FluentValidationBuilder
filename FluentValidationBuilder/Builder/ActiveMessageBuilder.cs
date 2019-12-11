using System;
using System.Runtime.InteropServices;
using System.Text;
using FluentValidationBuilder.Mapper;
using FluentValidationBuilder.Model.ActiveMessage;
using FluentValidationBuilder.Validator;

namespace FluentValidationBuilder.Builder
{

    public class ActiveMessageBuilder
    {
        protected ActiveMessage activeMessage;

        public ActiveMessageBuilder(ActiveMessage message)
        {
            this.activeMessage = message;
        }

        public TranscodeRequestBuilder with_transcode_request => new TranscodeRequestBuilder(activeMessage, new TranscodeRequestMetadataElementMapper(), new TranscodeRequestInputElementMapper());

        public TranscodeFormatBuilder with_transcode_formats => new TranscodeFormatBuilder(activeMessage);

        public ActiveMessage compile()
        {
            return activeMessage;
        }
    }

    
}
