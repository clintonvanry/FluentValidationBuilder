using System;
using System.Collections.Generic;
using FluentValidation.TestHelper;
using FluentValidationBuilder.Model;
using FluentValidationBuilder.Validator;
using NUnit.Framework;

namespace FluentValidationBuilderTest.Validator
{
    [TestFixture]
    public class InputFileElementValidatorTest
    {
        private InputFileElementValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new InputFileElementValidator();
        }

        [TestCaseSource("GetS3UrlTestCases")]
        public void when_url_is_not_valid_then_should_fail(Uri s3Url)
        {
            var fileSize = 900;
            var metadataElement = new InputFileElement() { Url = s3Url, Size = fileSize };
            var result = validator.TestValidate(metadataElement);
            result.ShouldHaveValidationErrorFor(m => m.Url);
        }

        [Test]
        public void when_filesize_is_not_greater_than_0_then_fail()
        {
            var fileSize = 0;
            var metadataElement = new InputFileElement() { Url = new Uri("s3://bucket/folder/file.ext"), Size = fileSize };
            var result = validator.TestValidate(metadataElement);
            result.ShouldHaveValidationErrorFor(m => m.Size);
        }

        [Test]
        public void when_url_is_valid_then_should_not_fail()
        {
            var fileSize = 900;
            var metadataElement = new InputFileElement() { Url = new Uri("s3://bucket/folder/file.ext"), Size = fileSize };
            var result = validator.TestValidate(metadataElement);
            result.ShouldNotHaveValidationErrorFor(m => m.Url);
        }



        public static IEnumerable<TestCaseData> GetS3UrlTestCases
        {
            get
            {
                yield return new TestCaseData(new Uri("", UriKind.Relative));
                yield return new TestCaseData(new Uri("s4://bucket/folder/file.ext"));
                yield return new TestCaseData(new Uri("http://api.imdcloud:9090/message"));
            }
        }
    }
}