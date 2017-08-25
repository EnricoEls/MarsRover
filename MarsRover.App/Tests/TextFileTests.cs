using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            var textLines = TextHelper.ReadTextFile("../../Tests/testFile1.txt");
            Assert.That(textLines.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void Given_InputTextForFile_CorrectStringIfNeeded()
        {
            var textLocation = "\"E:\\New folder\\MarsRover\\MarsRover.App\\Tests\\testFile1.txt\"";
            var result = TextHelper.CorrectStringAsNeeded(textLocation);
            Assert.That(result,Is.EqualTo("E:/New folder/MarsRover/MarsRover.App/Tests/testFile1.txt"));
        }
    }
}
