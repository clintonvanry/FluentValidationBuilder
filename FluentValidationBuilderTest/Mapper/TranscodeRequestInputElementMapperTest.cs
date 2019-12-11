using FluentValidationBuilder.Mapper;
using FluentValidationBuilder.Model.ActiveMessage;
using FluentValidationBuilder.Model.Transcode;
using NUnit.Framework;

namespace FluentValidationBuilderTest.Mapper
{
    [TestFixture]
    public class TranscodeRequestInputElementMapperTest
    {
        private IDataMapper<InputElement, ActiveMessage> mapper;

        [SetUp]
        public void Setup()
        {
            mapper = new TranscodeRequestInputElementMapper();
        }
    }
}