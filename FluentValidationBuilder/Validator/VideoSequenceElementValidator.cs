using FluentValidation;
using FluentValidationBuilder.Model;

namespace FluentValidationBuilder.Validator
{
    public class VideoSequenceElementValidator : AbstractValidator<VideoSequenceElement>
    {
        public VideoSequenceElementValidator()
        {
            When(m => m.SequenceType == SequenceType.Slate, ValidateSlateSequenceElement).Otherwise(ValidateColorSequenceElement);
        }

        private void ValidateSlateSequenceElement()
        {
            RuleFor(m => m.Duration).GreaterThan(0);
            // validate uri

        }

        private void ValidateColorSequenceElement()
        {
            RuleFor(m => m.Duration).GreaterThan(0);
            // https://stackoverflow.com/questions/1636350/how-to-identify-a-given-string-is-hex-color-format
            RuleFor(m => m.Colour).NotNull().Matches("^#(?:[0-9a-fA-F]{3}){1,2}$");
        }
    }
}