using System;
using System.Collections.Generic;
using System.Text;

namespace PlutoRover.Abstractions
{
    public interface IPlanet
    {
        /// <summary>
        /// Gets or sets the xsize.
        /// </summary>
        /// <value>The xsize.</value>
        int Xsize { get; set; }

        /// <summary>
        /// Gets or sets the ysize.
        /// </summary>
        /// <value>The ysize.</value>
        int Ysize { get; set; }

        /// <summary>
        /// Gets or sets the objects on map.
        /// </summary>
        /// <value>The objects on map.</value>
        IEnumerable<IPosition> ObjectsOnMap { get; set; }
    }
}
