using System.Collections.Generic;
using OSRSWeapons.Models;
using OSRSWeapons.Models.Requests;

namespace OSRSWeapons.Repositories {

    /// <summary>
    /// Interface representing the contract all Weapon Repositories must follow
    /// </summary>
    /// <author>Josh Faber</author>
    public interface IWeaponsRepository {

        /// <summary>
        /// Retrieves the entire list of weapons available
        /// </summary>
        /// <returns>The complete list of weapons to return</returns>
        public List<Weapon> GetWeapons();

        /// <summary>
        /// Retrieves a list of weapons matching the sent-in criteria. For example, criteria could match the Name, PrimaryAttackType, or Weight
        /// </summary>
        /// <param name="criteria">The criteria to search by</param>
        /// <returns>The list of weapons matching the sent-in criteria</returns>
        public List<Weapon> GetWeaponsByCriteria(string criteria);

        /// <summary>
        /// Retrieves a single weapon by its ID (or null if not found)
        /// </summary>
        /// <param name="weaponID">The ID of the weapon</param>
        /// <returns>The single weapon with the matching ID, or null</returns>
        public Weapon? GetWeaponByWeaponID(int weaponID);

        /// <summary>
        /// Creates a weapon and saves it to the database with the given parameters
        /// </summary>
        /// <param name="name">The weapon's name</param>
        /// <param name="examine">The weapon's examine description</param>
        /// <param name="exchangePrice">The weapon's exchange price</param>
        /// <param name="highAlchPrice">The weapon's high alchemy price</param>
        /// <param name="requiredAttackLvl">The weapon's required attack level</param>
        /// <param name="requiredStrengthLvl">The weapon's required strength level</param>
        /// <param name="primaryAttackType">The weapon's primary attack type</param>
        /// <param name="secondaryAttackType">The weapon's secondary attack type</param>
        /// <param name="attackSpeed">The weapon's attack speed</param>
        /// <param name="attackStab">The weapon's stab attack bonus</param>
        /// <param name="attackSlash">The weapon's slash attack bonus</param>
        /// <param name="attackCrush">The weapon's crush attack bonus</param>
        /// <param name="attackMagic">The weapon's magic attack bonus</param>
        /// <param name="attackRanged">The weapon's ranged attack bonus</param>
        /// <param name="defenceStab">The weapon's stab defence bonus</param>
        /// <param name="defenceSlash">The weapon's slash defence bonus</param>
        /// <param name="defenceCrush">The weapon's crush defence bonus</param>
        /// <param name="defenceMagic">The weapon's magic defence bonus</param>
        /// <param name="defenceRanged">The weapon's ranged defence bonus</param>
        /// <param name="meleeStrength">The weapon's melee strength bonus</param>
        /// <param name="magicStrength">The weapon's magic strength bonus</param>
        /// <param name="rangedStrength">The weapon's ranged strength bonus</param>
        /// <param name="prayerBonus">The weapon's prayer bonus</param>
        /// <param name="weight">The weapon's weight</param>
        /// <param name="imageURL">The weapon's image URL</param>
        /// <param name="modifiable">Indicates if the weapon is modifiable</param>
        /// <returns>The created weapon, with its generated ID included</returns>
        public Weapon CreateWeapon(
            string name, 
            string? examine,
            int? exchangePrice,
            int? highAlchPrice,
            int requiredAttackLvl,
            int requiredStrengthLvl,
            string primaryAttackType,
            string secondaryAttackType,
            int attackSpeed,
            int attackStab,
            int attackSlash,
            int attackCrush,
            int attackMagic,
            int attackRanged,
            int defenceStab,
            int defenceSlash,
            int defenceCrush,
            int defenceMagic,
            int defenceRanged,
            int meleeStrength,
            int magicStrength,
            int rangedStrength,
            int prayerBonus,
            decimal weight,
            string? imageURL,
            bool? modifiable = true
        );

        /// <summary>
        /// Updates a weapon and saves it to the database with the given parameters
        /// All parameters are the same as the previous method
        /// </summary>
        public void UpdateWeapon(
            int weaponID,
            string name,
            string? examine,
            int? exchangePrice,
            int? highAlchPrice,
            int requiredAttackLvl,
            int requiredStrengthLvl,
            string primaryAttackType,
            string secondaryAttackType,
            int attackSpeed,
            int attackStab,
            int attackSlash,
            int attackCrush,
            int attackMagic,
            int attackRanged,
            int defenceStab,
            int defenceSlash,
            int defenceCrush,
            int defenceMagic,
            int defenceRanged,
            int meleeStrength,
            int magicStrength,
            int rangedStrength,
            int prayerBonus,
            decimal weight,
            string? imageURL,
            bool? modifiable = true
        );

        /// <summary>
        /// Partially updates a weapon with the given ID using the provided request data
        /// </summary>
        /// <param name="weaponID">The ID of the weapon to update</param>
        /// <param name="request">The request containing the data to update</param>
        void PatchWeapon(int weaponID, WeaponPatchRequest request);

        /// <summary>
        /// Deletes a weapon from the database with the given ID
        /// </summary>
        /// <param name="weaponID">The ID of the weapon to delete</param>
        public void DeleteWeapon(int weaponID);

    }

}
