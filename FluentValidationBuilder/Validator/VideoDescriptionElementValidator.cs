using FluentValidation;
using FluentValidationBuilder.Model.Transcode;

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
}