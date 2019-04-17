namespace Deoxys.Console.UI.Command
{

    /// <summary>
    /// ara yüzden girilen komut tipleri
    /// </summary>
    public enum CommandType
        : sbyte
    {

        /// <summary>
        /// gezegen bilgilerinin girildiği komut tipi
        /// </summary>
        CreatePlanetCommand = 0,

        /// <summary>
        /// rover aracının drop bilgilerinin girildiği komut tipi
        /// </summary>        
        DropRoverCommand,

        /// <summary>
        /// rover aracının keşif bilgilerinin girildiği komut tipi
        /// </summary>   
        RoverSetMovementCommand
    }
}