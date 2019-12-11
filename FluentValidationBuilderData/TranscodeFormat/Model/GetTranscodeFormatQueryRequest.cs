using System;
using System.Collections.Generic;
using System.Text;

namespace FluentValidationBuilderData.TranscodeFormat.Model
{
    public class GetTranscodeFormatQueryRequest 
    {
        public string Name { get; set; }
    }
    // perhaps create a transcode table for id, name, transcodepackage , settings, isclosedcaption
}
