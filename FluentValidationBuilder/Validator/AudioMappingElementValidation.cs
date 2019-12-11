using FluentValidation;
using FluentValidationBuilder.Model.Transcode;

namespace FluentValidationBuilder.Validator
{
    public class AudioMappingElementValidation : AbstractValidator<AudioDescriptionAudioMappingElement>
    {
        public AudioMappingElementValidation()
        {
            RuleFor(m => m.Map).NotNull().NotEmpty();
            RuleFor(m => m.Stream).NotNull().NotEmpty();
        }
    }
}