using PlutoRover.Abstractions;
using PlutoRover.Abstractions.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlutoRover.Library.Positions
{
    /// <summary>
    /// Class BasePosition.
    /// </summary>
    /// <seealso cref="PlutoRover.Abstractions.IPosition" />
    public abstract class BasePosition : IPosition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasePosition"/> class.
        /// </summary>
        /// <param name="xCoordinate">The x coordinate.</param>
        /// <param name="yCoordinate">The y coordinate.</param>
        /// <param name="direction">The direction.</param>
        public BasePosition(int xCoordinate, int yCoordinate, string direction)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BasePosition"/> class.
        /// </summary>
        /// <param name="xCoordinate">The x coordinate.</param>
        /// <param name="yCoordinate">The y coordinate.</param>
        /// <param name="direction">The direction.</param>
        public BasePosition(int xCoordinate, int yCoordinate, CompassDirection? direction)
        {
            _xCoordinate = xCoordinate;
            _yCoordinate = yCoordinate;
            _direction = direction;
        }

        /// <summary>
        /// Gets the xcoordinate.
        /// </summary>
        /// <value>The xcoordinate.</value>
        public int Xcoordinate
        {
            get {
                return _xCoordinate;
            }
        }
        protected int _xCoordinate;

        /// <summary>
        /// Gets the ycoordinate.
        /// </summary>
        /// <value>The ycoordinate.</value>
        public int Ycoordinate
        {
            get {
                return _yCoordinate;
            }
        }
        protected int _yCoordinate;

        /// <summary>
        /// Gets the direction.
        /// </summary>
        /// <value>The direction.</value>
        public CompassDirection? Direction
        {
            get {
                return _direction;
            }
        }
        protected CompassDirection? _direction;

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public abstract override string ToString();
    }
}
