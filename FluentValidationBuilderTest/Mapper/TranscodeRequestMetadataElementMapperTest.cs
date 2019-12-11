using System;
using System.Text;
using FluentValidationBuilder.Builder;
using FluentValidationBuilder.Mapper;
using FluentValidationBuilder.Model.ActiveMessage;
using FluentValidationBuilder.Model.Transcode;
using NUnit.Framework;

namespace FluentValidationBuilderTest.Mapper
{
    [TestFixture]
    public class TranscodeRequestMetadataElementMapperTest
    {
        private IDataMapper<MetadataElement, ActiveMessage> mapper;

        [SetUp]
        public void Setup()
        {
            mapper = new TranscodeRequestMetadataElementMapper();
        }

        [Test]
        public void when_metadataElement_has_a_value_then_map_to_activemessage()
        {
            var metadata = GetMetadataTestStub();
            var activeMessage = new ActiveMessage();
            
            mapper.Map(metadata,activeMessage);

            Assert.AreEqual(metadata.CorrelationId, activeMessage.CorrelationId);
            Assert.AreEqual(metadata.Reference.Id, activeMessage.Metadata.Id);
            Assert.AreEqual(metadata.Reference.Name, activeMessage.Metadata.Name);
            Assert.AreEqual(metadata.CallBackUrl.ToString(), activeMessage.Url);
            Assert.AreEqual(metadata.Region, activeMessage.Region.Name);
        }

        private MetadataElement GetMetadataTestStub()
        {
            var correlationId = "correlationid";
            var callbackUrl = new Uri("https://callback.com/message");
            var region = "us-east-1";

            var reference = new CallerReferenceElement() { Id = 1, Name = "name" };
            return new MetadataElement() { CorrelationId = correlationId, CallBackUrl = callbackUrl, Reference = reference, Region = region };

        }
    }
}
