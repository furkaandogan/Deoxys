using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Deoxys
{

    /// <summary>
    /// konum ve yön tipleri
    /// </summary>
    public enum DirectionType
        : int
    {
        [Display(Name = "N")]
        North = 0,

        [Display(Name = "E")]
        East = 90,

        [Display(Name = "S")]
        South = 180,

        [Display(Name = "W")]
        West = 270
    }
}