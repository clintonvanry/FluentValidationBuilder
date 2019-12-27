using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using FluentValidationBuilder.Extension;
using FluentValidationBuilder.Model.ActiveMessage;
using FluentValidationBuilder.Model.Transcode;

namespace FluentValidationBuilder.Mapper
{
    public class ValidationFailureMapper : IDataMapper<IList<ValidationFailure>, IValidationResult>
    {
        public IValidationResult MapTo(IList<ValidationFailure> @from)
        {
            return new ValidationResult {Errors = from?.Select(m => m.ErrorMessage).ToArray()};
        }

        public void Map(IList<ValidationFailure> @from, IValidationResult to)
        {
            throw new System.NotImplementedException();
        }
    }

    public class TranscodeRequestInputElementMapper : IDataMapper<InputElement, ActiveMessage>
    {
        public ActiveMessage MapTo(InputElement @from)
        {
            throw new NotImplementedException();
        }

        public void Map(InputElement @from, ActiveMessage to)
        {
            var activeMessage = to;
            var requestMetadataElement = @from;




        }
    }


    public class TranscodeRequestOutputElementMapper : IDataMapper<IList<OutputElement>, ActiveMessage>
    {
        public ActiveMessage MapTo(IList<OutputElement> @from)
        {
            throw new NotImplementedException();
        }

        public void Map(IList<OutputElement> @from, ActiveMessage to)
        {
            var activeMessage = to;
            var outputElements = @from;

            // set 
            activeMessage.Body.Items = new List<TranscodeItem>(outputElements.Count);

            foreach (var outputElement in outputElements)
            {
                
            }


        }

        private void MapOutputElement(OutputElement outputElement, ActiveMessage activeMessage)
        {
            // outputElement.FileUrl // targerurl

            var targetUrl = outputElement.Url;
            var transcodeItem = new TranscodeItem();

            transcodeItem.TargetFileUri = outputElement.Url.ToString();
            transcodeItem.TargetFile = targetUrl.Segments.Last();
            transcodeItem.TargetFolder = targetUrl.LocalPath.Replace(targetUrl.Segments.Last(), string.Empty);
            // target bucket
            transcodeItem.PresetName = outputElement.Preset;

            // var targetBucket = s3Url.Host; 
            //outputElement.VideoDescription

            //outputElement.AudioDescription
        }

        private void MapVideoDescription(VideoDescriptionElement videoDescription, TranscodeItem transcodeItem)
        {
            transcodeItem.CustomValues.Upsert(TranscodeCustomValueKeys.FirstFrameTimecodeKey,videoDescription.FirstFrameTimecode);

            if (videoDescription?.Sequence?.Header?.Any() ?? false)
            {
                ProcessSequenceElements(videoDescription.Sequence.Header, transcodeItem,GetHeaderSequenceKeys());
            }
            if (videoDescription?.Sequence?.Tail?.Any() ?? false)
            {
                ProcessSequenceElements(videoDescription.Sequence.Tail, transcodeItem,GetTailSequenceKeys());
            }
        }


        private void ProcessSequenceElements(IList<VideoSequenceElement> videoSequencesElements, TranscodeItem transcodeItem, IDictionary<SequenceType, Stack<ValueTuple<string, string>>> sequenceKeys)
        {
            foreach (var videoSequencesElement in videoSequencesElements)
            {
                if (!sequenceKeys[videoSequencesElement.SequenceType].TryPop(out var keys))
                {
                    continue;
                }
                //  a pity that slate is only duration
                if (videoSequencesElement.SequenceType == SequenceType.Colour)
                {
                    transcodeItem.CustomValues.Upsert(keys.Item1, videoSequencesElement.Colour);
                    transcodeItem.CustomValues.Upsert(keys.Item2, videoSequencesElement.Duration.ToString());
                }
                else
                {
                    transcodeItem.CustomValues.Upsert(keys.Item2, videoSequencesElement.Duration.ToString());
                }

            }
        }

        private IDictionary<SequenceType, Stack<ValueTuple<string,string>>> GetHeaderSequenceKeys()
        {
            var sequenceDictionary = new Dictionary<SequenceType, Stack<ValueTuple<string, string>>>();
            var colourStack = new Stack<ValueTuple<string, string>>();
            colourStack.Push((TranscodeCustomValueKeys.Sequence.Header.SecondColourHexValueKey,
                TranscodeCustomValueKeys.Sequence.Header.SecondColourDurationKey));
            colourStack.Push((TranscodeCustomValueKeys.Sequence.Header.FirstColourHexValueKey,
                TranscodeCustomValueKeys.Sequence.Header.FirstColourDurationKey));
            var slateStack = new Stack<(string slateUrlKey, string slateDurationKey)>();
            slateStack.Push((TranscodeCustomValueKeys.Sequence.Header.SlateDurationKey, TranscodeCustomValueKeys.Sequence.Header.SlateDurationKey));

            sequenceDictionary.Add(SequenceType.Colour,colourStack);
            sequenceDictionary.Add(SequenceType.Slate,slateStack);

            return sequenceDictionary;

        }

        private IDictionary<SequenceType, Stack<ValueTuple<string, string>>> GetTailSequenceKeys()
        {
            var sequenceDictionary = new Dictionary<SequenceType, Stack<ValueTuple<string, string>>>();
            var colourStack = new Stack<ValueTuple<string, string>>();
            colourStack.Push((TranscodeCustomValueKeys.Sequence.Tail.SecondColourHexValueKey,
                TranscodeCustomValueKeys.Sequence.Tail.SecondColourDurationKey));
            colourStack.Push((TranscodeCustomValueKeys.Sequence.Tail.FirstColourHexValueKey,
                TranscodeCustomValueKeys.Sequence.Tail.FirstColourDurationKey));
            var slateStack = new Stack<(string slateUrlKey, string slateDurationKey)>();
            slateStack.Push((TranscodeCustomValueKeys.Sequence.Tail.SlateDurationKey, TranscodeCustomValueKeys.Sequence.Tail.SlateDurationKey));

            sequenceDictionary.Add(SequenceType.Colour, colourStack);
            sequenceDictionary.Add(SequenceType.Slate, slateStack);

            return sequenceDictionary;

        }




        private void MapAudioDescription(AudioDescriptionElement audioDescription, TranscodeItem transcodeItem)
        {
            
        }
    }
}