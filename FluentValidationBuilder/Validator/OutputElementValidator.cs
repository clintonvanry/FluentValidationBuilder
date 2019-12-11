using System;
using FluentValidation;
using FluentValidationBuilder.Model.Transcode;

namespace FluentValidationBuilder.Validator
{
    public class OutputElementValidator : AbstractValidator<OutputElement>
    {
        public OutputElementValidator()
        {
            RuleFor(m => m.Preset).NotNull().NotEmpty();
            RuleFor(m => m.Url).NotNull().NotEmpty().Custom(ValidateS3Url);
            RuleFor(m => m.VideoDescription).SetValidator(new VideoDescriptionElementValidator());
            RuleFor(m => m.AudioDescription).SetValidator(new AudioDescriptionElementValidation());
        }

        private void ValidateS3Url(Uri s3Url, FluentValidation.Validators.CustomContext context)
        {
            if (string.IsNullOrEmpty(s3Url.OriginalString))
            {
                context.AddFailure("S3 Url does not have a value.");
                return;
            }

            if (!s3Url.IsWellFormedOriginalString())
            {
                context.AddFailure("invalid s3 Url.");
                return;
            }

            if (!s3Url.Scheme.Equals("s3"))
            {
                context.AddFailure("Please specify a valid s3 Url.");
            }

        }
    }
}