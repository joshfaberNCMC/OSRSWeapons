using System;
using System.Collections.Generic;

namespace OSRSWeapons.Models
{
    /// <summary>
    /// Represents a weapon entity
    /// </summary>
    /// <author>Josh Faber</author>
    public partial class Weapon
    {
        /// <summary>
        /// The unique identifier for the weapon
        /// </summary>
        public int WeaponID { get; set; }

        /// <summary>
        /// The name of the weapon
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// The examine description of the weapon
        /// </summary>
        public string? Examine { get; set; }

        /// <summary>
        /// The exchange price of the weapon
        /// </summary>
        public int? ExchangePrice { get; set; }

        /// <summary>
        /// The high alchemy price of the weapon
        /// </summary>
        public int? HighAlchPrice { get; set; }

        /// <summary>
        /// The required attack level to wield the weapon
        /// </summary>
        public int RequiredAttackLvl { get; set; }

        /// <summary>
        /// The required strength level to wield the weapon
        /// </summary>
        public int RequiredStrengthLvl { get; set; }

        /// <summary>
        /// The primary attack type of the weapon
        /// </summary>
        public string PrimaryAttackType { get; set; } = null!;

        /// <summary>
        /// The secondary attack type of the weapon
        /// </summary>
        public string SecondaryAttackType { get; set; } = null!;

        /// <summary>
        /// The attack speed of the weapon
        /// </summary>
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
        /// The URL of the weapon image
        /// </summary>
        public string? ImageURL { get; set; }

        /// <summary>
        /// A value indicating whether the weapon is modifiable
        /// </summary>
        public bool? Modifiable { get; set; }
    }
}
