using System.Collections.Generic;
using Deoxys.Planets;

namespace Deoxys.Rovers
{

    /// <summary>
    /// rover araçlarının türetileceği interfacedir
    /// </summary>
    public interface IRover
    {
        /// <summary>
        /// rover aracının gezegene başarılı iniş yaptığı bilgisini tutar
        /// </summary>
        /// <value></value>
        bool IsDropped { get; }

        /// <summary>
        /// rover aracının bırakıldığı gezegenin bilgisini tutar
        /// </summary>
        /// <value></value>
        IPlanet DroppedPlanet { get; }

        /// <summary>
        /// rover aracının gezegen üzerindeki hareket komutlarınını tutar
        /// </summary>
        /// <value></value>
        IList<MovementCommandType> MovementCommands { get; }

        /// <summary>
        /// rover aracının şuanki konum bilgisini barındırır
        /// </summary>
        /// <value></value>
        Point Location { get; set; }

        /// <summary>
        /// rover aracının hareket edeceği yön bilgisini tutar
        /// </summary>
        /// <value></value>
        DirectionType Direction { get; set; }

        /// <summary>
        /// rover aracını verilen hareket tipine göre harekett ettirir
        /// </summary>
        /// <param name="movement"></param>
        void Move(MovementCommandType movement);

        /// <summary>
        /// rover aracınını verilen gezegene indirir
        /// </summary>
        /// <param name="planet">indirilmek istenen gezegen</param>
        void Drop(IPlanet planet);

        /// <summary>
        /// rover aracının gezegen üzerinden gireln hareket komutlarına göre keşif yapmasını sağlşar
        /// </summary>
        void Explore();

        /// <summary>
        /// rover aracına yeni bir hareket planı bilgisi ekler
        /// </summary>
        /// <param name="vovementCommands">hareket bilgisi</param>
        void SetMovementCommand(IList<MovementCommandType> vovementCommands);

        /// <summary>
        /// rover aracının raporlama işlemini gerçekleştirir
        /// </summary>
        void Report();
    }
}