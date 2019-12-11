using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.Results;
using FluentValidationBuilder.Mapper;

namespace FluentValidationBuilder.Extension
{
    public static class ValidationResultMapperExtension
    {
        public static IValidationResult Map(this IList<ValidationFailure> validationFailures)
        {
            var mapper = new ValidationFailureMapper();
            return mapper.MapTo(validationFailures);

        }
    }
}
