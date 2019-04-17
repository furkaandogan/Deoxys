namespace Deoxys.Planets
{

    /// <summary>
    /// Mars gezegeni oluşturur
    /// </summary>
    public sealed class MarsPlanet
        : BasePlanet, IPlanet
    {
        /// <summary>
        /// istenilen boyutlarda bir Mars gezegeni oluşturur
        /// </summary>
        /// <param name="size">new Size(5,5)</param>
        public MarsPlanet(Size size)
            : base(size)
        {
        }


        /// <summary>
        /// verilen boyutlarda bir Mars gezegeni oluşturur
        /// </summary>
        /// <param name="width">5</param>
        /// <param name="height">5</param>
        public MarsPlanet(int width, int height)
            : base(width, height)
        {
        }
    }
}