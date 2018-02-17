using System;
using System.Collections.Generic;
using System.Text;

namespace PlutoRover.Abstractions
{
    /// <summary>
    /// Interface IRobotQueueCommandRunner
    /// </summary>
    public interface IRobotQueueCommandRunner
    {
        /// <summary>
        /// Runs the specified queue of commands.
        /// </summary>
        /// <param name="queueOfCommands">The queue of commands.</param>
        /// <returns>IEnumerable&lt;IPosition&gt;.</returns>
        IEnumerable<IPosition> Run(string queueOfCommands);
    }
}
