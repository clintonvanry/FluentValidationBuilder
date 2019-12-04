using System;
using FluentValidation;
using FluentValidationBuilder.Model;
using FluentValidationBuilder.Model.Transcode;

namespace FluentValidationBuilder.Validator
{
    /// <summary>
    /// At a minimum we require url and size
    /// </summary>
    public class InputFileElementValidator : AbstractValidator<InputFileElement>
    {
        public InputFileElementValidator()
        {
            RuleFor(m => m.Url).NotNull().NotEmpty().Custom(ValidateS3Url);
            RuleFor(m => m.Size).GreaterThan(0);
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