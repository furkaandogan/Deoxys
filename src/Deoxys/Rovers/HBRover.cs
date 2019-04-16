using System.Collections.Generic;
using System.Drawing;
using Deoxys.Planets;

namespace Deoxys.Rovers
{
    public sealed class HBRover
        : BaseRover, IRover
    {

        /// <summary>
        /// tüm bilgili ve görevleri tanımlı bir hb rover oluşturur
        /// </summary>
        /// <param name="location">gezegende iniş yapacağı konumu belirler</param>
        /// <param name="direction">iniş halindeki ilk hareket yönünü belirler</param>
        /// <param name="droppedPlanet">inişi ve keşifini gerçekleştireceği gezegen bilgisi</param>
        /// <param name="movementCommands">keşif için gerçekleştireceği hareket bilgisi</param>
        public HBRover(Point location, DirectionType direction, IPlanet droppedPlanet, IList<MovementCommandType> movementCommands)
            : base(location, direction, droppedPlanet, movementCommands)
        {

        }
    }
}