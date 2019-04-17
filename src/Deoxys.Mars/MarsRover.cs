using System.Collections.Generic;
using Deoxys.Planets;
using Deoxys.Rovers;

namespace Deoxys.Mars
{
    public sealed class MarsRover
        : BaseRover, IRover
    {
        /// <summary>
        /// konum ve yönü belli indirilmeye hazor bir rover hazorlar
        /// </summary>
        /// <param name="location">gezegende iniş yapacağı konumu belirler</param>
        /// <param name="direction">iniş halindeki ilk hareket yönünü belirler</param>
        public MarsRover(Point location, DirectionType direction)
            : base(location, direction,new MarsRoverMovementConttroller())
        {

        }

        /// <summary>
        /// tüm bilgili ve görevleri tanımlı bir hb rover oluşturur
        /// </summary>
        /// <param name="location">gezegende iniş yapacağı konumu belirler</param>
        /// <param name="direction">iniş halindeki ilk hareket yönünü belirler</param>
        /// <param name="droppedPlanet">inişi ve keşifini gerçekleştireceği gezegen bilgisi</param>
        /// <param name="movementCommands">keşif için gerçekleştireceği hareket bilgisi</param>
        public MarsRover(Point location, DirectionType direction, IPlanet droppedPlanet, IList<MovementCommandType> movementCommands)
            : base(location, direction, droppedPlanet, movementCommands)
        {

        }
    }
}