using FluentValidation;
using FluentValidationBuilder.Model;

namespace FluentValidationBuilder.Validator
{
    public class VideoDescriptionElementValidator : AbstractValidator<VideoDescriptionElement>
    {
        public VideoDescriptionElementValidator()
        {
            RuleFor(m => m.FirstFrameTimecode).NotNull().NotEmpty();
            When(m => m.Conversion != null, ValidateConversion);
            When(m => m.Sequence != null, ValidateSequence);
        }

        private void ValidateConversion() // build more complex validation here
        {
            RuleFor(x => x.Conversion.AspectRatio).NotNull();
            RuleFor(x => x.Conversion.Standard).NotNull();
        }

        private void ValidateSequence()
        {
            RuleForEach(m => m.Sequence.Header).NotNull().SetValidator(new VideoSequenceElementValidator());
            RuleForEach(m => m.Sequence.Tail).NotNull().SetValidator(new VideoSequenceElementValidator());
        }
    }

    public class AudioDescriptionElementValidation : AbstractValidator<AudioDescriptionElement>
    {
        public AudioDescriptionElementValidation()
        {
            When(m => m.AudioMapping != null, ValidateAudioMapping);
            When(m => m.AudioAttenuation != null, ValidateAudioAttenuation);
        }

        private void ValidateAudioMapping()
        {
            RuleForEach(m => m.AudioMapping).SetValidator(new AudioMappingElementValidation());
        }

        private void ValidateAudioAttenuation()
        {

        }
    }

    public class AudioMappingElementValidation : AbstractValidator<AudioDescriptionAudioMappingElement>
    {
        public AudioMappingElementValidation()
        {
            RuleFor(m => m.Map).NotNull().NotEmpty();
            RuleFor(m => m.Stream).NotNull().NotEmpty();
        }
    }

    public class AudioAttenuationElementValidation : AbstractValidator<AudioDescriptionAudioAttenuationElement>
    {
        public AudioAttenuationElementValidation()
        {
            RuleFor(m => m.Type).Custom(ValidateAudio);
        }

        private void ValidateAudio(AudioAttenuationType audioAttenuationType, FluentValidation.Validators.CustomContext context)
        {
            if (audioAttenuationType == AudioAttenuationType.Level)
            {
                ValidateAudioLevel(context);
            }
            if (audioAttenuationType == AudioAttenuationType.Loudness)
            {
                ValidateAudioLoudness(context);
            }
        }

        private void ValidateAudioLevel(FluentValidation.Validators.CustomContext context)
        {

        }

        private void ValidateAudioLoudness(FluentValidation.Validators.CustomContext context)
        {

        }

        
    }
}