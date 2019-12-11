using System.Collections.Generic;
using FluentValidationBuilder.Model.ActiveMessage;
using FluentValidationBuilder.Model.Transcode;

namespace FluentValidationBuilder.Builder
{
    public class TranscodeFormatBuilder : ActiveMessageBuilder
    {
        public TranscodeFormatBuilder(ActiveMessage message) : base(message)
        {
            
        }

        public ActiveMessageBuilder build(IEnumerable<TranscodeResponse> transcodeFormats)
        {
               
            return this;
        }
    }
}