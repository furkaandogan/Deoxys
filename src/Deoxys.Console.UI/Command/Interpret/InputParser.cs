
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;

namespace Deoxys.Console.UI.Command.Interpret
{

    /// <summary>
    /// terminal ekranından girilen komutları yorumlar
    /// </summary>
    public sealed class InputParser
    {
        /// <summary>
        /// tanımlanan komutlar
        /// </summary>
        private readonly IDictionary<string, CommandType> _commandTypes;
    
        public InputParser()
        {
            _commandTypes = new Dictionary<string, CommandType>()
            {
                { @"^\d+ \d+$", CommandType.CreatePlanetCommand },
                { @"^\d+ \d+ [NSEW]$", CommandType.DropRoverCommand },
                { @"^[LRM]+$", CommandType.RoverSetMovementCommand }
            };
        }

        /// <summary>
        /// terminal ekranından girilen satırın hangi komut olduğunu belirler
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public CommandType GetCommandType(string command)
        {
            try
            {
                var commandType = _commandTypes.FirstOrDefault(x => new Regex(x.Key).IsMatch(command));
                return commandType.Value;
            }
            catch (InvalidOperationException)
            {
                throw new InvalidCommandException();
            }
        }
    }
}