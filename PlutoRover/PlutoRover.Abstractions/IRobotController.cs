using System;
using System.Collections.Generic;
using System.Text;

namespace PlutoRover.Abstractions
{
    /// <summary>
    /// Interface IRobotController
    /// </summary>
    public interface IRobotController
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="IRobotController"/> is collision.
        /// </summary>
        /// <value><c>true</c> if collision; otherwise, <c>false</c>.</value>
        bool Collision { get; }

        /// <summary>
        /// Moves the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>IPosition.</returns>
        IPosition Move(ICommand command);

        /// <summary>
        /// Moves the specified rotate command.
        /// </summary>
        /// <param name="rotateCommand">The rotate command.</param>
        /// <returns>IPosition.</returns>
        IPosition Move(IRotate rotateCommand);
    }
}
