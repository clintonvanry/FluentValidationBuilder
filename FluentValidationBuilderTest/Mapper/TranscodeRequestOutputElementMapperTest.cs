using System;
using System.Collections.Generic;
using System.Text;
using FluentValidationBuilder.Mapper;
using FluentValidationBuilder.Model.ActiveMessage;
using FluentValidationBuilder.Model.Transcode;
using NUnit.Framework;

namespace FluentValidationBuilderTest.Mapper
{
    [TestFixture]
    public class TranscodeRequestOutputElementMapperTest
    {
        private IDataMapper<IList<OutputElement>, ActiveMessage> mapper;

        [SetUp]
        public void Setup()
        {
            mapper = new TranscodeRequestOutputElementMapper();
        }
    }
}
