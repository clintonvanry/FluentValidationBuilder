using FluentValidation;
using FluentValidationBuilder.Model;

namespace FluentValidationBuilder.Validator
{
    public class InputElementValidator : AbstractValidator<InputElement>
    {
        public InputElementValidator()
        {
            RuleFor(m => m.File).NotNull().SetValidator(new InputFileElementValidator());
            RuleFor(m => m.VideoInformation).NotNull().SetValidator(new VideoInformationElementValidator());
        }
    }
}