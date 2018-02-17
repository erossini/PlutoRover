using PlutoRover.Abstractions;
using PlutoRover.Abstractions.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlutoRover.Library.Positions
{
    /// <summary>
    /// Class Position.
    /// </summary>
    /// <seealso cref="PlutoRover.Library.Position.BasePosition" />
    /// <seealso cref="PlutoRover.Abstractions.IPosition" />
    public class Position : BasePosition, IPosition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Position"/> class.
        /// </summary>
        /// <param name="xCoordinate">The x coordinate.</param>
        /// <param name="yCoordinate">The y coordinate.</param>
        /// <param name="direction">The direction.</param>
        public Position(int xCoordinate, int yCoordinate, CompassDirection? direction) : base(xCoordinate, yCoordinate, direction)
        {
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return string.Format($"{Xcoordinate},{Ycoordinate},{Direction.ToString()[0]}");
        }
    }
}
