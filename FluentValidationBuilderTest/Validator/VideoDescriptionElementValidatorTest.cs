using FluentValidationBuilder.Validator;
using NUnit.Framework;

namespace FluentValidationBuilderTest.Validator
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