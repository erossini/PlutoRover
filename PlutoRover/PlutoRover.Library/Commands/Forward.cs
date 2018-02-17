using PlutoRover.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlutoRover.Library.Commands
{
    /// <summary>
    /// Class Forward.
    /// </summary>
    /// <seealso cref="PlutoRover.Abstractions.ICommand" />
    public class Forward : ICommand
    {
        private readonly int _moveForwards = 1;

        /// <summary>
        /// Gets the command value.
        /// </summary>
        /// <value>The command value.</value>
        public int CommandValue
        {
            get {
                return _moveForwards;
            }
        }
    }
}