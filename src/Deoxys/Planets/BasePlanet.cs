using System.Collections.Generic;
using Deoxys.Rovers;

namespace Deoxys.Planets
{

    /// <summary>
    /// gezegen türlerinin türetileceği interfacedir
    /// </summary>
    public abstract class BasePlanet
        : IPlanet
    {
        /// <summary>
        /// verilen boyut bilgisini saklar
        /// </summary>
        /// <value></value>
        public Size Size { get; set; }
        public IList<IRover> Rovers { get; set; }

        /// <summary>
        /// istenilen boyutlarda bir gezegen oluşturur
        /// </summary>
        /// <param name="size">new Size(5,5)</param>
        public BasePlanet(Size size)
        {
            this.Size = size;
            this.Rovers = new List<IRover>();
        }


        /// <summary>
        /// verilen boyutlarda bir gezegen oluşturur
        /// </summary>
        /// <param name="width">5</param>
        /// <param name="height">5</param>
        public BasePlanet(int width, int height)
            : this(new Size(width, height))
        {

        }

    }
}