using PlutoRover.Abstractions;
using PlutoRover.Library.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlutoRover.Library
{
    /// <summary>
    /// Class RobotQueueCommandRunner.
    /// </summary>
    /// <seealso cref="PlutoRover.Abstractions.IRobotQueueCommandRunner" />
    public class RobotQueueCommandRunner : IRobotQueueCommandRunner
    {
        private IRobotController _robotController;

        /// <summary>
        /// Initializes a new instance of the <see cref="RobotQueueCommandRunner"/> class.
        /// </summary>
        /// <param name="controller">The controller.</param>
        public RobotQueueCommandRunner(IRobotController controller)
        {
            _robotController = controller;
        }

        /// <summary>
        /// Runs the specified queue of commands.
        /// </summary>
        /// <param name="queueOfCommands">The queue of commands.</param>
        /// <returns>IEnumerable&lt;IPosition&gt;.</returns>
        public IEnumerable<IPosition> Run(string queueOfCommands)
        {
            foreach (char command in queueOfCommands)
            {
                ICommand commandToRun = new CommandFactory().Get(command);

                if (commandToRun is IRotate)
                {
                    IRotate rotateCommand = (IRotate)commandToRun;
                    yield return _robotController.Move(rotateCommand);
                }
                else
                {
                    yield return _robotController.Move(commandToRun);
                }
            }
        }
    }
}