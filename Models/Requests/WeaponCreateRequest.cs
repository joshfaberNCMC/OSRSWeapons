using System.ComponentModel.DataAnnotations;

namespace OSRSWeapons.Models.Requests 
{
    /// <summary>
    /// Represents a request to create a new weapon
    /// </summary>
    public class WeaponCreateRequest 
    {
        /// <summary>
        /// The name of the weapon
        /// </summary>
        [Required]
        [MinLength(3)]
        [MaxLength(200)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// A weapons in-game examine text
        /// </summary>
        [Required]
        [MinLength(3)]
        [MaxLength(255)]
        public string Examine { get; set; } = null!;

        /// <summary>
        /// The Grand Exchange price of the weapon
        /// </summary>
        public int ExchangePrice { get; set; }

        /// <summary>
        /// The high alchemy value of the weapon
        /// </summary>
        public int HighAlchPrice { get; set; }

        /// <summary>
        /// The attack level required to wield the weapon
        /// </summary>
        [Required]
        public int RequiredAttackLvl { get; set; }

        /// <summary>
        /// The strength level required to wield the weapon
        /// </summary>
        [Required]
        public int RequiredStrengthLvl { get; set; }

        /// <summary>
        /// The primary attack type of the weapon
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string PrimaryAttackType { get; set; } = null!;

        /// <summary>
        /// The secondary attack type of the weapon
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string SecondaryAttackType { get; set; } = null!;

        /// <summary>
        /// The attack speed of the weapon
        /// </summary>
        [Required]
        public int AttackSpeed { get; set; }

        /// <summary>
        /// The stab attack bonus of the weapon
        /// </summary>
        public int AttackStab { get; set; }

        /// <summary>
        /// The slash attack bonus of the weapon
        /// </summary>
        public int AttackSlash { get; set; }

        /// <summary>
        /// The crush attack bonus of the weapon
        /// </summary>
        public int AttackCrush { get; set; }

        /// <summary>
        /// The magic attack bonus of the weapon
        /// </summary>
        public int AttackMagic { get; set; }

        /// <summary>
        /// The ranged attack bonus of the weapon
        /// </summary>
        public int AttackRanged { get; set; }

        /// <summary>
        /// The stab defence bonus of the weapon
        /// </summary>
        public int DefenceStab { get; set; }

        /// <summary>
        /// The slash defence bonus of the weapon
        /// </summary>
        public int DefenceSlash { get; set; }

        /// <summary>
        /// The crush defence bonus of the weapon
        /// </summary>
        public int DefenceCrush { get; set; }

        /// <summary>
        /// The magic defence bonus of the weapon
        /// </summary>
        public int DefenceMagic { get; set; }

        /// <summary>
        /// The ranged defence bonus of the weapon
        /// </summary>
        public int DefenceRanged { get; set; }

        /// <summary>
        /// The melee strength bonus of the weapon
        /// </summary>
        public int MeleeStrength { get; set; }

        /// <summary>
        /// The magic strength bonus of the weapon
        /// </summary>
        public int MagicStrength { get; set; }

        /// <summary>
        /// The ranged strength bonus of the weapon
        /// </summary>
        public int RangedStrength { get; set; }

        /// <summary>
        /// The prayer bonus of the weapon
        /// </summary>
        public int PrayerBonus { get; set; }

        /// <summary>
        /// The weight of the weapon
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        /// The URL to an image of the weapon
        /// </summary>
        [Url]
        public string? ImageUrl { get; set; }
    }
}
