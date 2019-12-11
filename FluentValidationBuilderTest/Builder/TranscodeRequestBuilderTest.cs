using System;
using FluentValidationBuilder.Builder;
using FluentValidationBuilder.Mapper;
using FluentValidationBuilder.Model.ActiveMessage;
using FluentValidationBuilder.Model.Transcode;
using NUnit.Framework;

namespace FluentValidationBuilderTest.Builder
{
    [TestFixture]
    public class TranscodeRequestBuilderTest
    {
        private ActiveMessageBuilder builder;

        [SetUp]
        public void Setup()
        {
            builder = new TranscodeRequestBuilder(new ActiveMessage(), new TranscodeRequestMetadataElementMapper(), new TranscodeRequestInputElementMapper());
        }

        [Test]
        public void when_correlationid_has_a_value_then_map_to_activemessage_correlation_id()
        {
            var correlationId = "correlationid";
            var request = new TranscodeRequest() { Metadata =new MetadataElement() {CorrelationId = correlationId,CallBackUrl = new Uri("https://callback.com/message"),Region = "us-east-1" } };
            var activeMessage = builder.with_transcode_request.build(request).compile();
            Assert.AreEqual(correlationId,activeMessage.CorrelationId);
        }
        [Test]
        public void when_correlationid_has_an_empty_value_then_map_to_activemessage_new_correlation_id()
        {
            var correlationId = "";
            var request = new TranscodeRequest() { Metadata = new MetadataElement() { CorrelationId = correlationId, CallBackUrl = new Uri("https://callback.com/message"), Region = "us-east-1" } };
            var activeMessage = builder.with_transcode_request.build(request).compile();
            Assert.IsTrue(activeMessage.CorrelationId.Length > 0);
        }

        [Test]
        public void when_reference_element_has_value_then_map_to_activemessage_correctly()
        {
            var correlationId = "correlationid";
            var callbackUrl = new Uri("https://callback.com/message");
            var region = "us-east-1";

            var reference = new CallerReferenceElement() {Id = 1, Name = "name"};
            var request = new TranscodeRequest() { Metadata = new MetadataElement() { CorrelationId = correlationId, CallBackUrl = callbackUrl, Reference = reference,  Region = region } };

            var activeMessage = builder.with_transcode_request.build(request).compile();
            Assert.AreEqual(reference.Id, activeMessage.Metadata.Id);
            Assert.AreEqual(reference.Name, activeMessage.Metadata.Name);
            Assert.AreEqual(activeMessage.Url , callbackUrl.ToString());
            Assert.AreEqual(region, activeMessage.Region.Name);

        }



    }
}
