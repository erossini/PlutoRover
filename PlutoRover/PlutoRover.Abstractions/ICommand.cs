using System;
using System.Collections.Generic;
using System.Text;

namespace PlutoRover.Abstractions
{
    /// <summary>
    /// Interface Command
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Gets the command value.
        /// </summary>
        /// <value>The command value.</value>
        int CommandValue { get; }
    }
}