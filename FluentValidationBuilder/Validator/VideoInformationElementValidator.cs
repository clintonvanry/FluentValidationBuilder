using FluentValidation;
using FluentValidation.Results;
using FluentValidationBuilder.Model;
using FluentValidationBuilder.Model.Transcode;

namespace FluentValidationBuilder.Validator
{
    public class VideoInformationElementValidator : AbstractValidator<VideoInformationElement>
    {
        private readonly string durationLabel = "Duration";
        public VideoInformationElementValidator()
        {
            RuleFor(m => m.Duration).GreaterThan(0);
            RuleFor(m => m.Layout).NotNull().Custom(ValidateLayout);
        }

        private void ValidateLayout(VideoInformationLayoutElement layout,
            FluentValidation.Validators.CustomContext context)
        {
            var preRoll = layout.PreRoll;
            var postRoll = layout.PostRoll;
            var totalDuration = int.Parse(context.ParentContext.RootContextData[durationLabel].ToString());

            if (preRoll < 0)
            {
                context.AddFailure("preRoll value must be equal or greater than zero.");
            }
            if (postRoll < 0)
            {
                context.AddFailure("postRoll value must be equal or greater than zero.");
            }

            var tvcContent = totalDuration - (preRoll + postRoll);
            if (tvcContent < 1)
            {
                context.AddFailure("The sum of the layout is greater than total duration.");
            }

        }

        protected override bool PreValidate(ValidationContext<VideoInformationElement> context, FluentValidation.Results.ValidationResult result)
        {
            // we need to pass the duration
            var duration = context.InstanceToValidate?.Duration ?? 0;
            context.RootContextData.Add(durationLabel, duration);

            return base.PreValidate(context, result);
        }

    }
}