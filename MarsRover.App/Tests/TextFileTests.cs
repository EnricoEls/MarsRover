using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.App.Tests
{
    [TestFixture]
    class TextFileTests
    {
        [Test]
        public void Given_Textfile_Should_BeAbleToReadFile()
        {
            var textLines = TextHelper.ReadTextFile();
            Assert.That(textLines.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void Given_StringWithSpases_Should_ReturnStringWithoutSpaces()
        {
            string inputString = "This Is A Spaced Out String";

            string formattedString = TextHelper.RemoveAllSpaces(inputString);

            Assert.That(formattedString, Is.EqualTo("ThisIsASpacedOutString"));
        }
    }
}
