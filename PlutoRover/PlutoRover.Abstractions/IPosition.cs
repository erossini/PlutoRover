using PlutoRover.Abstractions.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlutoRover.Abstractions
{
    public interface IPosition
    {
        /// <summary>
        /// Gets the xcoordinate.
        /// </summary>
        /// <value>The xcoordinate.</value>
        int Xcoordinate { get; }

        /// <summary>
        /// Gets the ycoordinate.
        /// </summary>
        /// <value>The ycoordinate.</value>
        int Ycoordinate { get; }

        /// <summary>
        /// Gets the direction.
        /// </summary>
        /// <value>The direction.</value>
        CompassDirection? Direction { get; }
    }
}
