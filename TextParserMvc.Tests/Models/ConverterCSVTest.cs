using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextParserMvc.Models;
using System.Text.RegularExpressions;

namespace TextParserMvc.Tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ConverterCSVTest
    {
        public ConverterCSVTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [TestMethod]
        public void TestConvert()
        {
            // Arrange
            Parser parser = new Parser();
            Text text = parser.Parse(@"Mary had a little lamb. Peter called for the wolf, and Aesop came.
                 Cinderella likes shoes.");
            IConvert converter = new ConverterCSV();

            // Act
            string csv = converter.Convert(text);
            string[] lines = Regex.Split(csv, "\r\n|\r|\n");

            // Assert
            Assert.AreEqual(4, lines.Length);
            Assert.AreEqual(", Word 1, Word 2, Word 3, Word 4, Word 5, Word 6, Word 7, Word 8", lines[0]);
            Assert.AreEqual("Sentence 1, a, had, lamb, little, Mary", lines[1]);
            Assert.AreEqual("Sentence 2, Aesop, and, called, came, for, Peter, the, wolf", lines[2]);
            Assert.AreEqual("Sentence 3, Cinderella, likes, shoes", lines[3]);
        }
    }
}
