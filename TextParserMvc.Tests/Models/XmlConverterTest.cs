using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextParserMvc.Models;
using System.Text.RegularExpressions;
using System.Xml;

namespace TextParserMvc.Tests
{

    [TestClass]
    public class XmlConverterTest
    {

        [TestMethod]
        public void TestXml()
        {
            // Arrange
            Parser parser = new Parser();
            Text text = parser.Parse(@"Mary had a little lamb. Peter called for the wolf, and Aesop came.
                 Cinderella likes shoes.");
            IConvert converter = new XmlConverter();

            // Act
            string xml = converter.Convert(text);
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(xml);

            // Assert
            Assert.AreEqual(2, xd.ChildNodes.Count);
            Assert.AreEqual("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>",
                xd.ChildNodes[0].OuterXml);

            Assert.AreEqual("<sentence><word>a</word><word>had</word><word>lamb</word><word>little</word><word>Mary</word></sentence>",
                xd.ChildNodes[1].ChildNodes[0].OuterXml);
            Assert.AreEqual("<sentence><word>Aesop</word><word>and</word><word>called</word><word>came</word><word>for</word><word>Peter</word><word>the</word><word>wolf</word></sentence>",
                xd.ChildNodes[1].ChildNodes[1].OuterXml);
            Assert.AreEqual("<sentence><word>Cinderella</word><word>likes</word><word>shoes</word></sentence>",
                xd.ChildNodes[1].ChildNodes[2].OuterXml);

        }
    }
}