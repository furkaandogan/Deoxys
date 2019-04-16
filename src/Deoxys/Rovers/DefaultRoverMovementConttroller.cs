using System.Collections.Generic;
using System.Drawing;
using Deoxys.Planets;

namespace Deoxys.Rovers
{
    /// <summary>
    /// rover aracı için oluşturulacak tüm hareket kontrolcüsünün türüyeceği sınıftır
    /// </summary>
    public class DefaultRoverMovementConttroller
        : IMovementController
    {

        /// <summary>
        /// ileri yürüme
        /// </summary>
        /// <param name="currentDirection">ilerme işlemi gerçekletiğindeki aktif yön</param>
        /// /// <param name="currentLocation">ilerme işlemi gerçekletiğindeki aktif konum</param>
        /// <returns></returns>
        public virtual Point ForwardMove(DirectionType currentDirection, Point location)
        {
            throw new System.NotImplementedException();
        }


        /// <summary>
        /// sola dönüş
        /// </summary>
        /// /// <param name="currentDirection">sağa dönüş işlemini gerçekletiğindeki aktif yön</param>
        /// <returns></returns>
        public virtual DirectionType LeftMove(DirectionType currentDirection)
        {
            return currentDirection - 90;
        }

        /// <summary>
        /// sağa dönüş
        /// </summary>
        /// <param name="currentDirection">sağa dönüş işlemini gerçekletiğindeki aktif yön</param>
        /// <returns></returns>

        public virtual DirectionType RigthMove(DirectionType currentDirection)
        {
            return currentDirection + 90;
        }
    }
}