﻿using System.Linq;
using NUnit.Framework;

namespace ProNet.Test.Unit
{
    [TestFixture]
    public class XmlProgrammersProviderTests
    {
        [Test]
        public void Should_return_all_the_programmers_stored_as_xml()
        {
            var programmersProvider = new XmlProgrammersProvider(new HardCodedXmlLoader());
            var programmers = programmersProvider.GetAll();
            var programmerA = programmers.First();
            Assert.That(programmerA.Name, Is.EqualTo("Nick"));
        }
    }
}