﻿using System.Text.Json.Serialization;

namespace FluentValidationBuilder.Model.Transcode
{
    public class VideoInformationLayoutElement
    {
        [JsonPropertyName("preRoll")]
        public int PreRoll { get; set; }

        [JsonPropertyName("postRoll")]
        public int PostRoll { get; set; }
    }
}