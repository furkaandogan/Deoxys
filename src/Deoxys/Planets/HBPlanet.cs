namespace Deoxys.Planets
{

    /// <summary>
    /// HB gezegeni oluşturur
    /// </summary>
    public sealed class HBPlanet
        : BasePlanet, IPlanet
    {
        /// <summary>
        /// istenilen boyutlarda bir HB gezegeni oluşturur
        /// </summary>
        /// <param name="size">new Size(5,5)</param>
        public HBPlanet(Size size)
            : base(size)
        {
        }


        /// <summary>
        /// verilen boyutlarda bir HB gezegeni oluşturur
        /// </summary>
        /// <param name="width">5</param>
        /// <param name="height">5</param>
        public HBPlanet(int width, int height)
            : base(width, height)
        {
        }
    }
}