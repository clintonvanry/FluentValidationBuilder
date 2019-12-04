using System;
using System.Collections.Generic;
using FluentValidation.TestHelper;
using FluentValidationBuilder.Model;
using FluentValidationBuilder.Model.Transcode;
using FluentValidationBuilder.Validator;
using NUnit.Framework;

namespace FluentValidationBuilderTest.Validator.Unit
{
    [TestFixture]
    public class MetadataElementValidatorTest
    {
        private MetadataElementValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new MetadataElementValidator();
        }

        [TestCaseSource("GetCallBackUrlTestCases")]
        public void when_callback_url_is_not_valid_then_should_fail(Uri callbackUrl)
        {
            var region = "eu-central-1";
            var metadataElement = new MetadataElement { CallBackUrl = callbackUrl, Region = region };
            var result = validator.TestValidate(metadataElement);
            result.ShouldHaveValidationErrorFor(m => m.CallBackUrl);
        }

        [Test]
        public void when_callback_is_valid_then_should_pass()
        {
            var region = "eu-central-1";
            var metadataElement = new MetadataElement { CallBackUrl = new Uri("https://api.imdcloud:9090/message"), Region = region };
            var result = validator.TestValidate(metadataElement);
            result.ShouldNotHaveValidationErrorFor(m => m.CallBackUrl);
        }

        // 
        [TestCase("")]
        [TestCase("abc")]
        [TestCase("ap-south-1")]
        public void when_region_not_valid_then_should_fail(string region)
        {
            var metadataElement = new MetadataElement { CallBackUrl = new Uri("https://api.imdcloud:9090/message"), Region = region };
            var result = validator.TestValidate(metadataElement);

            result.ShouldHaveValidationErrorFor(m => m.Region);

        }

        public static IEnumerable<TestCaseData> GetCallBackUrlTestCases
        {
            get
            {
                yield return new TestCaseData(new Uri("", UriKind.Relative));
                yield return new TestCaseData(new Uri("http://api.imdcloud:9090/message"));
            }
        }
    }
}
