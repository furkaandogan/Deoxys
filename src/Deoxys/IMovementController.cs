using Deoxys.Planets;

namespace Deoxys
{
    /// <summary>
    /// tüm hareket kontrolcüsünün türüyeceği sınıftır
    /// </summary>
    public interface IMovementController
    {

        void SetPlanet(IPlanet planet);
        
        /// <summary>
        /// sola dönüş
        /// </summary>
        /// /// <param name="currentDirection">sağa dönüş işlemini gerçekletiğindeki aktif yön</param>
        /// <returns></returns>
        DirectionType LeftMove(DirectionType currentDirection);


        /// <summary>
        /// sağa dönüş
        /// </summary>
        /// <param name="currentDirection">sağa dönüş işlemini gerçekletiğindeki aktif yön</param>
        /// <returns></returns>
        DirectionType RigthMove(DirectionType currentDirection);


        /// <summary>
        /// ileri yürüme
        /// </summary>
        /// <param name="currentDirection">ilerme işlemi gerçekletiğindeki aktif yön</param>
        /// /// <param name="currentLocation">ilerme işlemi gerçekletiğindeki aktif konum</param>
        /// <returns></returns>
        Point ForwardMove(DirectionType currentDirection, Point currentLocation);
    }

}