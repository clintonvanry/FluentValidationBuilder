using System.Collections.Generic;
using FluentValidation.Results;
using FluentValidationBuilder;
using FluentValidationBuilder.Mapper;
using NUnit.Framework;

namespace FluentValidationBuilderTest.Mapper
{
    [TestFixture]
    public class ValidationFailureMapperTest
    {
        private IDataMapper<IList<ValidationFailure>, IValidationResult> mapper;

        [SetUp]
        public void Setup()
        {
            mapper = new ValidationFailureMapper();
        }
    }
}