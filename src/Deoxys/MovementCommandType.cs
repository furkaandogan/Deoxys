using System.ComponentModel.DataAnnotations;

namespace Deoxys
{

    /// <summary>
    /// hareket komut tipleri
    /// </summary>
    public enum MovementCommandType
        : sbyte
    {
        /// <summary>
        /// geçersiz hareket komutu
        /// </summary>
        NONE = 0,

        /// <summary>
        /// sola 90 derece döneceğini belirtir
        /// </summary>
        [Display(Name = "L")]
        Left,

        /// <summary>
        /// sağa 90 derece döneceğini belirtir
        /// </summary>
        [Display(Name = "R")]
        Rigth,

        /// <summary>
        /// ileri hareket edeceğini belirtir
        /// </summary>
        [Display(Name = "M")]
        Forward,
    }
}