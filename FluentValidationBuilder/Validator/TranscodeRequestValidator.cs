using FluentValidation;
using FluentValidationBuilder.Model;

namespace FluentValidationBuilder.Validator
{
    public class TranscodeRequestValidator : AbstractValidator<TranscodeRequest>
    {
        public TranscodeRequestValidator()
        {
            RuleFor(tr => tr.Metadata).NotNull().SetValidator(new MetadataElementValidator());
            RuleFor(tr => tr.Input).NotNull().SetValidator(new InputElementValidator());
        }
    }
}