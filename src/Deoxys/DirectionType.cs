using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Deoxys
{

    /// <summary>
    /// konum ve yön tipleri
    /// </summary>
    public enum DirectionType
        : sbyte
    {
        [Display(Name = "N")]
        North = 0,

        [Display(Name = "E")]
        East,

        [Display(Name = "S")]
        South,

        [Display(Name = "W")]
        West
    }
}