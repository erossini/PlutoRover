using PlutoRover.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlutoRover.Library.Commands
{
    /// <summary>
    /// Class Reverse.
    /// </summary>
    /// <seealso cref="PlutoRover.Abstractions.ICommand" />
    public class Reverse : ICommand
    {
        private readonly int _reverseBy = -1;

        /// <summary>
        /// Gets the command value.
        /// </summary>
        /// <value>The command value.</value>
        public int CommandValue
        {
            get {
                return _reverseBy;
            }
        }
    }
}
