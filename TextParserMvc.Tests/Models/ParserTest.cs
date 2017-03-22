using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextParserMvc.Models;

namespace TextParserMvc.Tests.Models
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void ParseCompact()
        {
            // Arrange
            Parser parser = new Parser();

            // Act
            Text result = parser.Parse(@"Mary had a little lamb. Peter called for the wolf, and Aesop came.
                 Cinderella likes shoes.");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Sentences.Count);
            Assert.AreEqual(5, result.Sentences[0].Words.Count);
            Assert.AreEqual("a", result.Sentences[0].Words[0]);
            Assert.AreEqual("had", result.Sentences[0].Words[1]);
            Assert.AreEqual("Mary", result.Sentences[0].Words[4]);
            Assert.AreEqual(8, result.Sentences[1].Words.Count);
        }

        [TestMethod]
        public void ParseDelimeters()
        {
            // Arrange
            Parser parser = new Parser();

            // Act
            Text result = parser.Parse(@"  Mary    had   a little lamb .

                Peter called for       the wolf , and    Aesop   came .

                    Cinderella     likes shoes.");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Sentences.Count);
            Assert.AreEqual(5, result.Sentences[0].Words.Count);
            Assert.AreEqual("a", result.Sentences[0].Words[0]);
            Assert.AreEqual("had", result.Sentences[0].Words[1]);
            Assert.AreEqual("Mary", result.Sentences[0].Words[4]);
            Assert.AreEqual(8, result.Sentences[1].Words.Count);
        }
    }
}
