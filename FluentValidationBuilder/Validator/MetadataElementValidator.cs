using System;
using System.Collections.Generic;
using FluentValidation;
using FluentValidationBuilder.Model;
using FluentValidationBuilder.Model.Transcode;

namespace FluentValidationBuilder.Validator
{
    /// <summary>
    /// At a minimum we require a callbackUrl and Region
    /// </summary>
    public class MetadataElementValidator : AbstractValidator<MetadataElement>
    {
        public MetadataElementValidator()
        {
            RuleFor(m => m.CallBackUrl).NotNull().Custom(ValidateCallbackUrl);
            RuleFor(m => m.Region).NotNull().NotEmpty().Custom(IsValidAWSRegion);
        }

        private void ValidateCallbackUrl(Uri callbackUrl, FluentValidation.Validators.CustomContext context)
        {

            if (string.IsNullOrEmpty(callbackUrl.OriginalString))
            {
                context.AddFailure("callback Url does not have a value.");
                return;
            }

            if (!callbackUrl.IsWellFormedOriginalString())
            {
                context.AddFailure("invalid callback Url.");
                return;
            }

            if (callbackUrl.Scheme != Uri.UriSchemeHttps)
            {
                context.AddFailure("Please specify a valid https callback Url.");
            }
        }

        private void IsValidAWSRegion(string awsRegion, FluentValidation.Validators.CustomContext context)
        {
            var peachAWSRegions = PeachAWSRegions();
            if (!peachAWSRegions.Contains(awsRegion))
            {
                context.AddFailure("Not a recognized aws region");
            }

        }

        private List<string> PeachAWSRegions()
        {
            return new List<string>() { "us-east-1", "eu-west-1", "eu-central-1", "sa-east-1" };
        }

    }
}
