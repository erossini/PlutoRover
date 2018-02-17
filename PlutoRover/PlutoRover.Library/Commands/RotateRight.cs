using PlutoRover.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlutoRover.Library.Commands
{
    /// <summary>
    /// Class RotateRight.
    /// </summary>
    /// <seealso cref="PlutoRover.Abstractions.ICommand" />
    /// <seealso cref="PlutoRover.Abstractions.IRotate" />
    public class RotateRight : ICommand, IRotate
    {
        private int _turnRightBy = 1;

        /// <summary>
        /// Gets the command value.
        /// </summary>
        /// <value>The command value.</value>
        public int CommandValue
        {
            get {
                return _turnRightBy;
            }
        }
    }
}