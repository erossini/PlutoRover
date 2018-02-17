using System;
using System.Collections.Generic;
using System.Text;

namespace PlutoRover.Abstractions
{
    /// <summary>
    /// Interface IRotate
    /// </summary>
    public interface IRotate
    {
        /// <summary>
        /// Gets the command value.
        /// </summary>
        /// <value>The command value.</value>
        int CommandValue { get; }
    }
}
