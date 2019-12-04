using System.Collections.Generic;
using FluentValidation.TestHelper;
using FluentValidationBuilder.Model;
using FluentValidationBuilder.Model.Transcode;
using FluentValidationBuilder.Validator;
using NUnit.Framework;

namespace FluentValidationBuilderTest.Validator.Unit
{
    [TestFixture]
    public class VideoInformationElementValidatorTest
    {
        private VideoInformationElementValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new VideoInformationElementValidator();
        }

        [Test]
        public void when_duration_is_less_than_one_then_fail()
        {
            var videoInformation = new VideoInformationElement
                { Duration = 0, Layout = new VideoInformationLayoutElement() { PreRoll = 0, PostRoll = 0 } };

            var result = validator.TestValidate(videoInformation);

            result.ShouldHaveValidationErrorFor(m => m.Duration);

        }

        [Test]
        public void when_duration_is_greater_than_one_and_no_layout_then_pass()
        {
            var videoInformation = new VideoInformationElement
                { Duration = 1, Layout = new VideoInformationLayoutElement() { PreRoll = 0, PostRoll = 0 } };

            var result = validator.TestValidate(videoInformation);

            result.ShouldNotHaveValidationErrorFor(m => m.Duration);
        }

        [TestCaseSource("GetLayoutTestCases")]
        public void when_duration_is_greater_than_one_and_layout_is_invalid_then_fail(VideoInformationLayoutElement layout, int duration)
        {
            var videoInformation = new VideoInformationElement
                { Duration = duration, Layout = layout };

            var result = validator.TestValidate(videoInformation);

            result.ShouldHaveValidationErrorFor(m => m.Layout);
        }

        public static IEnumerable<TestCaseData> GetLayoutTestCases
        {
            get
            {
                yield return new TestCaseData(new VideoInformationLayoutElement() { PreRoll = -1, PostRoll = 0 }, 100);
                yield return new TestCaseData(new VideoInformationLayoutElement() { PreRoll = 0, PostRoll = -1 }, 100);
                yield return new TestCaseData(new VideoInformationLayoutElement() { PreRoll = 100, PostRoll = -1 }, 100);
                yield return new TestCaseData(new VideoInformationLayoutElement() { PreRoll = 0, PostRoll = 100 }, 100);
                yield return new TestCaseData(new VideoInformationLayoutElement() { PreRoll = 100, PostRoll = 100 }, 100);

            }
        }

    }
}