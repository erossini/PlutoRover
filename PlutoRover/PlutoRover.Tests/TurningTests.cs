using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlutoRover.Abstractions;
using PlutoRover.Abstractions.Enums;
using PlutoRover.Library;
using PlutoRover.Library.Commands;
using PlutoRover.Library.Factories;
using PlutoRover.Library.Positions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlutoRover.Tests
{
    [TestClass]
    public class TurningTests
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
        [DataRow(0, 0, 'N', "0,0,E")]
        [DataRow(0, 0, 'E', "0,0,S")]
        [DataRow(0, 0, 'S', "0,0,W")]
        [DataRow(0, 0, 'W', "0,0,N")]
        public void RotateRight(int xCoordinate, int yCoordinate, char direction, string expected)
        {
            CompassDirection? compassDirection = new DirectionFactory().Get(direction);
            IPosition robotStartPosition = new Position(xCoordinate, yCoordinate, compassDirection);

            IRobotController robotController = new RobotController(robotStartPosition, pluto);
            IRotate robotCommand = new RotateRight();
            IPosition robotEndPosition = robotController.Move(robotCommand);

            Assert.AreEqual(expected, robotEndPosition.ToString());
        }

        [TestMethod]
        [DataRow(0, 0, 'N', "0,0,W")]
        [DataRow(0, 0, 'W', "0,0,S")]
        [DataRow(0, 0, 'S', "0,0,E")]
        [DataRow(0, 0, 'E', "0,0,N")]
        public void RotateLeft(int xCoordinate, int yCoordinate, char direction, string expected)
        {
            CompassDirection? compassDirection = new DirectionFactory().Get(direction);
            IPosition robotStartPosition = new Position(xCoordinate, yCoordinate, compassDirection);

            IRobotController robotController = new RobotController(robotStartPosition, pluto);
            IRotate robotCommand = new RotateLeft();
            IPosition robotEndPosition = robotController.Move(robotCommand);

            Assert.AreEqual(expected, robotEndPosition.ToString());
        }
    }
}
