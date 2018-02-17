using PlutoRover.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlutoRover.Library.Commands
{
    /// <summary>
    /// Class NullCommand.
    /// </summary>
    /// <seealso cref="PlutoRover.Abstractions.ICommand" />
    public class NullCommand : ICommand
    {
        /// <summary>
        /// Gets the command value.
        /// </summary>
        /// <value>The command value.</value>
        public int CommandValue
        {
            get {
                return 0;
            }
        }
    }
}
