namespace FluentValidationBuilder.Mapper
{
    public static class TranscodeCustomValueKeys
    {
        public static string FirstFrameTimecodeKey = "$Sequence.TVCFirstFrameTimecode";

        public static string EnableWebSocketNotification = "EnableWebSocketNotification";

        public static class Sequence
        {
            public static class Header
            {
                public static string FirstColourHexValueKey = "$Sequence.HeadColor1";
                public static string FirstColourDurationKey = "$Sequence.HeadColorDur1";
                public static string SlateDurationKey = "$Sequence.HeadSlateDur";
                public static string SecondColourHexValueKey = "$Sequence.HeadColor2";
                public static string SecondColourDurationKey = "$Sequence.HeadColorDur2";
            }

            public static class Tail
            {
                public static string FirstColourHexValueKey = "$Sequence.TailColor1";
                public static string FirstColourDurationKey = "$Sequence.TailColorDur1";
                public static string SlateDurationKey = "$Sequence.TailSlateDur";
                public static string SecondColourHexValueKey = "$Sequence.TailColor2";
                public static string SecondColourDurationKey = "$Sequence.TailColorDur2";
            }
        }
    }
}