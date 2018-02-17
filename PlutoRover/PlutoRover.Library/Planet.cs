using PlutoRover.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlutoRover.Library
{
    /// <summary>
    /// Class Planet.
    /// </summary>
    /// <seealso cref="PlutoRover.Abstractions.IPlanet" />
    public class Planet : IPlanet
    {
        /// <summary>
        /// Gets or sets the xsize.
        /// </summary>
        /// <value>The xsize.</value>
        public int Xsize { get; set; }

        /// <summary>
        /// Gets or sets the ysize.
        /// </summary>
        /// <value>The ysize.</value>
        public int Ysize { get; set; }

        /// <summary>
        /// Gets or sets the objects on map.
        /// </summary>
        /// <value>The objects on map.</value>
        public IEnumerable<IPosition> ObjectsOnMap { get; set; }
    }
}