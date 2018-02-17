using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlutoRover.Abstractions;
using PlutoRover.Abstractions.Enums;
using PlutoRover.Library;
using PlutoRover.Library.Commands;
using PlutoRover.Library.Positions;
using System.Collections.Generic;
using System.Linq;

namespace PlutoRover.Tests
{
    [TestClass]
    public class CollisionDetectionTests
    {
        IPlanet pluto;

        [TestInitialize]
        public void TestInit()
        {
            pluto = new Planet
            {
                Xsize = 40,
                Ysize = 50,
            };
        }

        [TestMethod]
        [DataRow(0, 1)]
        public void CollisionAtCoordinates(int expectedXcoordinate, int expectedYcoordinate)
        {
            List<IPosition> objectsOnMap = new List<IPosition>();

            objectsOnMap.Add(new Position(expectedXcoordinate, expectedYcoordinate, CompassDirection.North));
            pluto.ObjectsOnMap = objectsOnMap;

            IPosition startPosition = new Position(0, 0, CompassDirection.North);
            IRobotController controller = new RobotController(startPosition, pluto);
            IPosition endPosition = controller.Move(new Forward());

            Assert.IsTrue(controller.Collision);
            Assert.AreEqual(endPosition.ToString(), objectsOnMap.FirstOrDefault().ToString());
        }
    }
}
