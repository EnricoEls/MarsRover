using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.App.Tests
{
    [TestFixture]
    public class RoverLogicTests
    {
        [Test]
        public void Given_ListOfInstructions_Should_BuildRoverLogicBaseCorrectly()
        {
            var listOfInstructions = new List<string> {
                "8 8",
                "1 2 E",
                "MMLMRMMRRMML",
            };

            var roverLogic = new RoverLogic(listOfInstructions);

            Assert.That(roverLogic.XMax, Is.EqualTo(8));
            Assert.That(roverLogic.YMax, Is.EqualTo(8));

            Assert.That(roverLogic.X, Is.EqualTo(1));
            Assert.That(roverLogic.Y, Is.EqualTo(2));
            Assert.That(roverLogic.D, Is.EqualTo("E"));

            Assert.That(roverLogic.Instructions.Count, Is.EqualTo(12));
        }

        [Test]
        public void Given_MovementCommand_ShouldExecuteCorrectly()
        {
            var listOfInstructions = new List<string> {
                "8 8",
                "1 2 E",
                "MMLMRMMRRMML",
            };

            var roverLogic = new RoverLogic(listOfInstructions);
            roverLogic.ExecuteMovementCommand("M");

            Assert.That(roverLogic.X, Is.EqualTo(2));
            Assert.That(roverLogic.Y, Is.EqualTo(2));
            Assert.That(roverLogic.D, Is.EqualTo("E"));
        }

        [TestCase("8 8", "9 8 N", "M", false)]
        [TestCase("8 8", "8 8 N", "M", true)]
        [TestCase("8 8", "8 0 S", "M", true)]
        [TestCase("8 8", "8 -1 S", "M", false)]
        public void Given_PositionOutOfGrid_ShouldReturnStatementAndExitLocation(string grid, string position, string movements, bool expected)
        {
            var listOfInstructions = new List<string> {
                grid,
                position,
                movements,
            };

            var roverLogic = new RoverLogic(listOfInstructions);
            var result = roverLogic.IsInBounds();

            Assert.That(result,Is.EqualTo(expected));
        }

        [Test]
        public void Given_MovementCommandThatGoesOutOfBounds_ShouldReturnFalse()
        {
            var listOfInstructions = new List<string> {
                "8 8",
                "8 8 N",
                "M",
            };

            var roverLogic = new RoverLogic(listOfInstructions);
            var result = roverLogic.Execute();
            Assert.That(result, Is.EqualTo("Rover moved out of grid at point 8 8 \n End position 8 9 N"));
        }

        [Test]
        public void Given_UnknownInstuction_ShouldReturnUnknownInstructions()
        {
            var listOfInstructions = new List<string> {
                "8 8",
                "1 2 E",
                "MMLMFMMRRMML",
            };

            var roverLogic = new RoverLogic(listOfInstructions);
            var result = roverLogic.Execute();

            Assert.That(roverLogic.UnknownInstructions.Count, Is.EqualTo(1));
            Assert.That(roverLogic.UnknownInstructions[0], Is.EqualTo("F"));
        }

        [Test]
        public void GoldenTest()
        {
            var listOfInstructions = new List<string> {
                "8 8",
                "1 2 E",
                "MMLMRMMRRMML",
            };

            var roverLogic = new RoverLogic(listOfInstructions);
            var result = roverLogic.Execute();

            Assert.That(result, Is.EqualTo("3 3 S"));
        }
    }
}
