using System;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using Deoxys.Exceptions;
using Deoxys.Planets;

namespace Deoxys
{
    /// <summary>
    /// rover araçlarının temel işlerini ve kontrollerini yapan abstract classıdır tüm rover araçları bundan türetilmelidir
    /// </summary>
    public abstract class BaseRover
        : IRover
    {

        /// <summary>
        /// rover aracının bırakıldığı gezegenin bilgisini tutar
        /// </summary>
        /// <value></value>
        public IPlanet DroppedPlanet { get; }

        /// <summary>
        /// rover aracının gezegen üzerindeki hareket komutlarınını tutar
        /// </summary>
        /// <value></value>
        public IList<MovementCommandType> MovementCommands { get; }

        /// <summary>
        /// rover aracının şuanki konum bilgisini barındırır
        /// </summary>
        /// <value></value>
        public Point Location { get; set; }

        /// <summary>
        /// rover aracının hareket edeceği yön bilgisini tutar
        /// </summary>
        /// <value></value>
        public DirectionType Direction { get; set; }

        /// <summary>
        /// rover aracını verilen hareket tipine göre harekett ettirir
        /// </summary>
        /// <param name="movement"></param>
        public virtual void Move(MovementCommandType movement)
        {
            switch (movement)
            {
                case MovementCommandType.Left:
                    break;
                case MovementCommandType.Rigth:
                    break;
                case MovementCommandType.Forward:
                    break;
                case MovementCommandType.NONE:
                default:
                    throw new InvalidMovementCommandType();
            }
        }

        /// <summary>
        /// rover aracınını verilen gezegene indirir
        /// </summary>
        /// <param name="planet">indirilmek istenen gezegen</param>
        public abstract void Drop(IPlanet planet);

        /// <summary>
        /// /// rover aracının gezegen üzerinden gireln hareket komutlarına göre keşif yapmasını sağlşar
        /// </summary>
        public virtual void Explore()
        {
            if (this.MovementCommands == null)
            {
                throw new NullReferenceException($"{nameof(this.MovementCommands)} is null");
            }

            foreach (MovementCommandType movement in this.MovementCommands)
            {
                this.Move(movement);
            }
        }

        /// <summary>
        /// tüm bilgili ve görevleri tanımlı bir rover oluşturur
        /// </summary>
        /// <param name="location">gezegende iniş yapacağı konumu belirler</param>
        /// <param name="direction">iniş halindeki ilk hareket yönünü belirler</param>
        /// <param name="droppedPlanet">inişi ve keşifini gerçekleştireceği gezegen bilgisi</param>
        /// <param name="movementCommands">keşif için gerçekleştireceği hareket bilgisi</param>
        public BaseRover(Point location, DirectionType direction, IPlanet droppedPlanet, IList<MovementCommandType> movementCommands)
        {
            this.Location = location;
            this.Direction = direction;
            this.DroppedPlanet = droppedPlanet;
            this.MovementCommands = movementCommands;
        }
    }
}