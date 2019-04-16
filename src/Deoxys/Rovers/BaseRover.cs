using System;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using Deoxys.Exceptions;
using Deoxys.Planets;

namespace Deoxys.Rovers
{
    /// <summary>
    /// rover araçlarının temel işlerini ve kontrollerini yapan abstract classıdır tüm rover araçları bundan türetilmelidir
    /// </summary>
    public abstract class BaseRover
        : IRover
    {
        protected readonly IMovementController _movementController;
        private readonly IPlanet _planet;
        private readonly IList<MovementCommandType> _movementCommands;
        private bool _isDropped;

        /// <summary>
        /// rover aracının gezegene başarılı iniş yaptığı bilgisini tutar
        /// </summary>
        /// <value></value>
        public bool IsDropped
        {
            get
            {
                return _isDropped;
            }
        }

        /// <summary>
        /// rover aracının bırakıldığı gezegenin bilgisini tutar
        /// </summary>
        /// <value></value>
        public IPlanet DroppedPlanet
        {
            get
            {
                return _planet;
            }
        }

        /// <summary>
        /// rover aracının gezegen üzerindeki hareket komutlarınını tutar
        /// </summary>
        /// <value></value>
        public IList<MovementCommandType> MovementCommands
        {
            get
            {
                return _movementCommands;
            }
        }

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
                    Direction = _movementController.LeftMove(Direction);
                    break;
                case MovementCommandType.Rigth:
                    Direction = _movementController.RigthMove(Direction);
                    break;
                case MovementCommandType.Forward:
                    Location = _movementController.ForwardMove(Direction, Location);
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
        public virtual void Drop(IPlanet planet)
        {
            bool isValidHorizontal = Location.X >= 0 && Location.X <= planet.Size.Width;
            bool isValidVertical = Location.Y >= 0 && Location.Y <= planet.Size.Height;

            if (isValidHorizontal && isValidVertical)
            {
                _isDropped = true;
            }

            throw new RoverDropException();
        }

        /// <summary>
        /// /// rover aracının gezegen üzerinden gireln hareket komutlarına göre keşif yapmasını sağlşar
        /// </summary>
        public virtual void Explore()
        {
            if (this.MovementCommands == null)
            {
                throw new NullReferenceException($"{nameof(MovementCommands)} is null");
            }

            foreach (MovementCommandType movement in MovementCommands)
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
            : this(location, direction, droppedPlanet, movementCommands, new DefaultRoverMovementConttroller())
        {

        }

        /// <summary>
        /// tüm bilgili ve görevleri tanımlı bir rover oluşturur
        /// </summary>
        /// <param name="location">gezegende iniş yapacağı konumu belirler</param>
        /// <param name="direction">iniş halindeki ilk hareket yönünü belirler</param>
        /// <param name="movementController">roverın hareketini gerçekleştirecek olan sınıftır</param>
        /// <param name="droppedPlanet">inişi ve keşifini gerçekleştireceği gezegen bilgisi</param>
        /// <param name="movementCommands">keşif için gerçekleştireceği hareket bilgisi</param>
        public BaseRover(Point location, DirectionType direction, IPlanet droppedPlanet, IList<MovementCommandType> movementCommands, IMovementController movementController)
        {
            Location = location;
            Direction = direction;
            _planet = droppedPlanet;
            _movementController = movementController;
            _movementCommands = movementCommands;
        }
    }
}