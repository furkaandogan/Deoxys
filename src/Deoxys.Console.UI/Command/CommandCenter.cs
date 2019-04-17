using System;
using System.Text;
using System.Collections.Generic;
using Deoxys;
using Deoxys.Rovers;
using Deoxys.Planets;
using Deoxys.Console.UI.Command.Interpret;
using System.Linq;
using Deoxys.Console.UI.Report;

namespace Deoxys.Console.UI.Command
{

    /// <summary>
    /// terminalden girilen kodları çalıştıran sınıftır
    /// </summary>
    public sealed class CommandCenter
    {
        private readonly InputParser _inputParser;
        private readonly Func<Point, DirectionType, IRover> _roverFactory;
        private readonly Func<Size, IPlanet> _planetFactory;
        private readonly IList<IRover> _rovers;

        /// <summary>
        /// ara yüzden girilen komutu işleyen sınıftır ara yüzün gireceği kısım
        /// </summary>
        /// <param name="inputParser"></param>
        /// <param name="roverFactory"></param>
        /// <param name="planetFactory"></param>
        public CommandCenter(InputParser inputParser, Func<Point, DirectionType, IRover> roverFactory, Func<Size, IPlanet> planetFactory)
        {
            _inputParser = inputParser;
            _roverFactory = roverFactory;
            _planetFactory = planetFactory;
            _rovers = new List<IRover>();
        }

        /// <summary>
        /// girilen komutu yorumlar
        /// </summary>
        /// <param name="command"></param>
        /// <returns>kodu yorumladıktan sonra kendisini geri döner</returns>
        public CommandCenter Parse(string command)
        {
            if (string.IsNullOrEmpty(command))
            {
                throw new ArgumentNullException($"{nameof(command)} is null");
            }

            string[] commands = command.Split(Environment.NewLine, StringSplitOptions.None);

            IRover rover = null;
            IPlanet planet = null;

            foreach (string cmd in commands)
            {
                switch (_inputParser.GetCommandType(cmd))
                {
                    case CommandType.CreatePlanetCommand:
                        planet = CreatePlanet(cmd);
                        break;
                    case CommandType.DropRoverCommand:
                        rover = CreateRover(cmd);
                        rover.Drop(planet);
                        _rovers.Add(rover);
                        break;
                    case CommandType.RoverSetMovementCommand:
                        rover.SetMovementCommand(CreateRoverMovementCommands(cmd));
                        break;
                }
            }

            return this;
        }

        /// <summary>
        /// yorumlanan kodları çalıştırır
        /// </summary>
        public CommandCenter Execute()
        {
            foreach (IRover rover in _rovers)
            {
                rover.Explore();
            }
            return this;
        }

        /// <summary>
        /// çalıştırılan roverların loglarını verir
        /// </summary>
        /// <returns></returns>
        public CommandCenter LogWrite()
        {
            foreach (IRover rover in _rovers)
            {
                // rover.Report();
                new RoverConsoleReport(rover)
                    .Write();
            }
            return this;
        }

        #region Helpers

        private IPlanet CreatePlanet(string command)
        {
            string[] arguments = command.Split(' ');

            return _planetFactory(new Size(int.Parse(arguments[0]), int.Parse(arguments[1])));
        }

        private IRover CreateRover(string command)
        {
            string[] arguments = command.Split(' ');

            Point location = new Point(int.Parse(arguments[0]), int.Parse(arguments[1]));
            DirectionType direction = EnumHelpers<DirectionType>.GetValueFromName(arguments[2][0].ToString());

            return _roverFactory(location, direction);
        }

        private IList<MovementCommandType> CreateRoverMovementCommands(string command)
        {
            char[] arguments = command.ToCharArray();

            return arguments
                .Select(x => EnumHelpers<MovementCommandType>.GetValueFromName(x.ToString()))
                .ToList();
        }
        
        #endregion
        
    }
}