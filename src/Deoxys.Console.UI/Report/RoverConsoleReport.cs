using Deoxys;
using Deoxys.Rovers;
using Deoxys.Rovers.Report;

namespace Deoxys.Console.UI.Report
{
    /// <summary>
    /// terminal için raporlama işlemini gerçekleştirir
    /// </summary>
    public sealed class RoverConsoleReport
        : IRoverReport
    {
        private readonly IRover _rover;

        /// <summary>
        /// raporlanacak rover aracı
        /// </summary>
        /// <value></value>
        public IRover Rover
        {
            get
            {
                return _rover;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rover">raporlanmak istenilen rover aracı</param>
        public RoverConsoleReport(IRover rover)
        {
            _rover = rover;
        }

        /// <summary>
        /// rover aracının lokasyon raporlama işlemini yapar
        /// </summary>
        public void LocationWrite()
        {
            System.Console.WriteLine($"{Rover.Location.X} {Rover.Location.Y} {EnumHelpers<DirectionType>.GetName(Rover.Direction)}");
        }

        /// <summary>
        /// tam raporlama işlemini gerçekleştirir
        /// </summary>
        public void Write()
        {
            LocationWrite();
        }
    }
}