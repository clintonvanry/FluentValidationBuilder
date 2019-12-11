using FluentValidation;
using FluentValidationBuilder.Model.Transcode;

namespace FluentValidationBuilder.Validator
{
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