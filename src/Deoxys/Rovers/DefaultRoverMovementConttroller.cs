using System.Collections.Generic;
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
            Point newLocation = new Point();
            switch (currentDirection)
            {
                case DirectionType.East:
                    newLocation = new Point(location.X + 1, location.Y);
                    break;
                case DirectionType.North:
                    newLocation = new Point(location.X, location.Y + 1);
                    break;
                case DirectionType.South:
                    newLocation = new Point(location.X, location.Y - 1);
                    break;
                case DirectionType.West:
                    newLocation = new Point(location.X - 1, location.Y);
                    break;
            }

            return newLocation;
        }


        /// <summary>
        /// sola dönüş
        /// </summary>
        /// /// <param name="currentDirection">sağa dönüş işlemini gerçekletiğindeki aktif yön</param>
        /// <returns></returns>
        public virtual DirectionType LeftMove(DirectionType currentDirection)
        {
            if ((int)currentDirection - 90 == -90)
                currentDirection = DirectionType.West;
            else
                currentDirection = currentDirection - 90;
            return currentDirection;
            // return currentDirection - 90;
        }

        /// <summary>
        /// sağa dönüş
        /// </summary>
        /// <param name="currentDirection">sağa dönüş işlemini gerçekletiğindeki aktif yön</param>
        /// <returns></returns>

        public virtual DirectionType RigthMove(DirectionType currentDirection)
        {
            if ((int)currentDirection + 90 == 360)
                currentDirection = DirectionType.North;
            else
                currentDirection = currentDirection + 90;
            return currentDirection;

            // return currentDirection + 90;
        }
    }
}