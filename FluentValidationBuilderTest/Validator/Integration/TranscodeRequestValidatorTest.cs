using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using FluentValidationBuilder.Model;
using FluentValidationBuilder.Validator;
using NUnit.Framework;

namespace FluentValidationBuilderTest.Validator.Integration
{
    [TestFixture]
    public class TranscodeRequestValidatorTest
    {
        private TranscodeRequestValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new TranscodeRequestValidator();
        }

        [TestCase(@".\Data\sampleTranscodeRequest.json")]
        public async Task when_valid_transcode_request_then_validator_should_pass(string filePath)
        {
            var transcodeRequest = await ReadTranscodeRequest(filePath);
            var result = await validator.ValidateAsync(transcodeRequest, CancellationToken.None);

            Assert.IsTrue(result.IsValid);
        }

        private static async Task<TranscodeRequest> ReadTranscodeRequest(string filePath)
        {
            await using var fsStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var options = new JsonSerializerOptions { IgnoreNullValues = true };
            options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));

            return await JsonSerializer.DeserializeAsync<TranscodeRequest>(fsStream, options);
        }


    }
}
