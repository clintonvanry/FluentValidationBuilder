using FluentValidationBuilder.Validator;
using NUnit.Framework;

namespace FluentValidationBuilderTest.Validator.Unit
{
    [TestFixture]
    public class VideoDescriptionElementValidatorTest
    {
        private VideoDescriptionElementValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new VideoDescriptionElementValidator();
        }


    }
}