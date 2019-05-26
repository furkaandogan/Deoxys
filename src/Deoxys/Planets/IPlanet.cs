using System.Collections.Generic;
using Deoxys.Rovers;

namespace Deoxys.Planets
{
    /// <summary>
    /// gezegen türlerinin türetileceği interfacedir
    /// </summary>
    public interface IPlanet
    {
        /// <summary>
        /// gezegenin boyut bilgisini saklar
        /// </summary>
        /// <value></value>
        Size Size { get; set; }

        IList<IRover> Rovers { get; set;}
    }
}