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
    public class PositionTests
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
        [DataRow(0, 4, 'E', "0,4,E")]
        [DataRow(1, 1, 'E', "1,1,E")]
        [DataRow(0, 2, 'S', "0,2,S")]
        [DataRow(0, 0, 'N', "0,0,N")]
        public void PositionToStringFormat(int xCoordinate, int yCoordinate, char faceDirection, string expected)
        {
            CompassDirection? direction = new DirectionFactory().Get(faceDirection);
            IPosition position = new Position(xCoordinate, yCoordinate, direction);

            Assert.AreEqual(expected, position.ToString());
        }
    }
}
