using FluentValidation;
using FluentValidationBuilder.Model.Transcode;

namespace FluentValidationBuilder.Validator
{
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
}