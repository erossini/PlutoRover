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
    public class CommandQueueTests
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
        [DataRow(0, 0, 'N', "FRLRFB", "0,1,E")]
        [DataRow(0, 0, 'N', "F", "0,1,N")]
        [DataRow(0, 0, 'N', "FR", "0,1,E")]
        [DataRow(0, 0, 'N', "FRL", "0,1,N")]
        [DataRow(0, 0, 'N', "FRLR", "0,1,E")]
        [DataRow(0, 0, 'N', "FRLRF", "1,1,E")]
        [DataRow(0, 0, 'W', "FFL", "98,0,S")]
        [DataRow(0, 0, 'W', "FFLFF", "98,98,S")]
        public void FollowEachCommandInCommandQueue(int startXcoordinate, int startYCoordiate, char startFacingDirectionFirstLetter, string queueOfCommands, string expectedEndPosition)
        {
            CompassDirection? startFacingDirection = new DirectionFactory().Get(startFacingDirectionFirstLetter);
            IPosition startPosition = new Position(startXcoordinate, startYCoordiate, startFacingDirection);

            IRobotController controller = new RobotController(startPosition, pluto);
            IRobotQueueCommandRunner queueOfCommandsRunner = new RobotQueueCommandRunner(controller);

            IEnumerable<IPosition> robotPath = queueOfCommandsRunner.Run(queueOfCommands);

            Assert.AreEqual(expectedEndPosition, robotPath.LastOrDefault().ToString());

        }

        [TestMethod]
        [DataRow('F', "Forward")]
        [DataRow('B', "Reverse")]
        [DataRow('L', "RotateLeft")]
        [DataRow('R', "RotateRight")]
        public void GetCommandFromFactory(char commandType, string expectedCommand)
        {
            ICommand command = new CommandFactory().Get(commandType);
            string commandName = command.GetType().Name;

            Assert.AreEqual(expectedCommand, commandName);
        }

    }
}
