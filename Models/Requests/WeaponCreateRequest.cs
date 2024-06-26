using System.ComponentModel.DataAnnotations;

namespace OSRSWeapons.Models.Requests 
{
    /// <summary>
    /// Represents a request to create a new weapon
    /// </summary>
    /// <author>Josh Faber</author>
    public class WeaponCreateRequest 
    {
        [Required]
        [MinLength(3)]
        [MaxLength(200)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(3)]
        [MaxLength(255)]
        public string Examine { get; set; } = null!;

        public int ExchangePrice { get; set; }

        public int HighAlchPrice { get; set; }

        [Required]
        public int RequiredAttackLvl { get; set; }

        [Required]
        public int RequiredStrengthLvl { get; set; }

        [Required]
        [MaxLength(10)]
        public string PrimaryAttackType { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string SecondaryAttackType { get; set; } = null!;

        [Required]
        public int AttackSpeed { get; set; }

        public int AttackStab { get; set; }

        public int AttackSlash { get; set; }

        public int AttackCrush { get; set; }

        public int AttackMagic { get; set; }

        public int AttackRanged { get; set; }

        public int DefenceStab { get; set; }

        public int DefenceSlash { get; set; }

        public int DefenceCrush { get; set; }

        public int DefenceMagic { get; set; }

        public int DefenceRanged { get; set; }

        public int MeleeStrength { get; set; }

        public int MagicStrength { get; set; }

        public int RangedStrength { get; set; }

        public int PrayerBonus { get; set; }

        public decimal Weight { get; set; }

        [Url]
        public string? ImageURL { get; set; }
    }
}
