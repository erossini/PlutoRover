using PlutoRover.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlutoRover.Library.Commands
{
    /// <summary>
    /// Class RotateLeft.
    /// </summary>
    /// <seealso cref="PlutoRover.Abstractions.ICommand" />
    /// <seealso cref="PlutoRover.Abstractions.IRotate" />
    public class RotateLeft : ICommand, IRotate
    {
        private int _turnLeftBy = -1;

        /// <summary>
        /// Gets the command value.
        /// </summary>
        /// <value>The command value.</value>
        public int CommandValue
        {
            get {
                return _turnLeftBy;
            }
        }
    }
}