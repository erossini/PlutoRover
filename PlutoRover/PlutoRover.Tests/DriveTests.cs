using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlutoRover.Abstractions;
using PlutoRover.Abstractions.Enums;
using PlutoRover.Library;
using PlutoRover.Library.Commands;
using PlutoRover.Library.Factories;
using PlutoRover.Library.Positions;
using System.Collections.Generic;
using System.Linq;

namespace PlutoRover.Tests
{
    [TestClass]
    public class DriveTests
    {
        IPlanet pluto;

        [TestInitialize]
        public void TestInit()
        {
            pluto = new Planet
            {
                Xsize = 100,
                Ysize = 100,
            };
        }

        [TestMethod]
        [DataRow(0, 0, 'N', "0,1,N")]
        [DataRow(0, 99, 'N', "0,0,N")]
        [DataRow(0, 0, 'S', "0,99,S")]
        [DataRow(85, 85, 'S', "85,84,S")]
        [DataRow(99, 1, 'W', "98,1,W")]
        [DataRow(3, 1, 'W', "2,1,W")]
        [DataRow(0, 1, 'E', "1,1,E")]
        [DataRow(0, 0, 'W', "99,0,W")]
        public void ForwardByOne(int startingXCoordinate, int startingYCoordinate, char direction, string expected)
        {
            CompassDirection? compassDirection = new DirectionFactory().Get(direction);
            IPosition robotStartPosition = new Position(startingXCoordinate, startingYCoordinate, compassDirection);

            ICommand robotCommand = new Forward();
            IRobotController robotController = new RobotController(robotStartPosition, pluto);
            IPosition robotEndPosition = robotController.Move(robotCommand);

            Assert.AreEqual(expected, robotEndPosition.ToString());
        }

        [DataRow(32, 12, 'W', "33,12,W")]
        [DataRow(64, 99, 'E', "63,99,E")]
        [DataRow(98, 42, 'S', "98,43,S")]
        [DataRow(0, 0, 'N', "0,99,N")]
        public void ReverseByOne(int startingXCoordinate, int startingYCoordinate, char direction, string expected)
        {
            CompassDirection? compassDirection = new DirectionFactory().Get(direction);
            IPosition robotStartPosition = new Position(startingXCoordinate, startingYCoordinate, compassDirection);

            ICommand robotCommand = new Reverse();
            IRobotController robotController = new RobotController(robotStartPosition, pluto);
            IPosition robotEndPosition = robotController.Move(robotCommand);

            Assert.AreEqual(expected, robotEndPosition.ToString());
        }
    }
}
