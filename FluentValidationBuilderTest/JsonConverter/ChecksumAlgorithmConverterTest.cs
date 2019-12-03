using System.Text.Json;
using FluentValidationBuilder.JsonConverter;
using FluentValidationBuilder.Model;
using NUnit.Framework;


namespace FluentValidationBuilderTest.JsonConverter
{
    [TestFixture]
    public class ChecksumAlgorithmConverterTest
    {
        private JsonSerializerOptions options;

        [SetUp]
        public void Setup()
        {
            options = new JsonSerializerOptions();
            options.Converters.Add(new ChecksumAlgorithmConverter());
            options.IgnoreNullValues = true;
        }

        [Test]
        public void when_empty_string_supplied_in_json_return_enum_value_none()
        {
            //var result = JsonSerializer.Deserialize<ChecksumAlgorithmType>("{\"checkumAlgorithm\":\"\"}",options);
            var result = JsonSerializer.Deserialize<ChecksumAlgorithmType>("\"\"", options);
            Assert.AreEqual(ChecksumAlgorithmType.None, result);

        }
        [Test]
        public void when_none_string_supplied_in_json_return_enum_value_none()
        {
            var result = JsonSerializer.Deserialize<ChecksumAlgorithmType>("\"None\"", options);
            Assert.AreEqual(ChecksumAlgorithmType.None, result);

        }
        [Test]
        public void when_md5_string_supplied_in_json_return_enum_value_MD5()
        {
            var result = JsonSerializer.Deserialize<ChecksumAlgorithmType>("\"MD5\"", options);
            Assert.AreEqual(ChecksumAlgorithmType.MD5, result);

        }
        [Test]
        public void when_sha1_string_supplied_in_json_return_enum_value_SHA1()
        {
            var result = JsonSerializer.Deserialize<ChecksumAlgorithmType>("\"SHA1\"", options);
            Assert.AreEqual(ChecksumAlgorithmType.SHA1, result);

        }
        [Test]
        public void when_sha256_string_supplied_in_json_return_enum_value_SHA256()
        {
            var result = JsonSerializer.Deserialize<ChecksumAlgorithmType>("\"SHA256\"", options);
            Assert.AreEqual(ChecksumAlgorithmType.SHA256, result);

        }
        [Test]
        public void when_sha512_string_supplied_in_json_return_enum_value_SHA512()
        {
            var result = JsonSerializer.Deserialize<ChecksumAlgorithmType>("\"SHA512\"", options);
            Assert.AreEqual(ChecksumAlgorithmType.SHA512, result);

        }
        [Test]
        public void when_unknonw_string_supplied_in_json_return_enum_value_None()
        {
            var result = JsonSerializer.Deserialize<ChecksumAlgorithmType>("\"bob\"", options);
            Assert.AreEqual(ChecksumAlgorithmType.None, result);

        }
    }
}
