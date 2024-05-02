using System;
using System.Collections.Generic;
using System.Linq;
using OSRSWeapons.Models;
using OSRSWeapons.Models.Requests;
using OSRSWeapons.Exceptions;
using OSRSWeapons.Utilities;
using System.Data.Common;
using System.Linq.Expressions;

namespace OSRSWeapons.Repositories
{
    /// <summary>
    /// Implementation of the weapons repository interface
    /// </summary>
    /// <author>Josh Faber</author>
    public class WeaponsRepositoryImpl : IWeaponsRepository
    {
        private readonly OSRSWeaponsDbContext _context;

        public WeaponsRepositoryImpl(OSRSWeaponsDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all weapons from the database
        /// </summary>
        /// <returns>A list of weapons</returns>
        public List<Weapon> GetWeapons()
        {
            try
            {
                return _context.Weapons.ToList();
            }
            catch (DbException)
            {
                throw new DbOperationException("An error occurred while attempting to retrieve weapons from the database.");
            }
        }

        /// <summary>
        /// Retrieves weapons from the database based on the provided search criteria
        /// </summary>
        /// <param name="criteria">The search criteria</param>
        /// <returns>A list of weapons matching the criteria</returns>
        public List<Weapon> GetWeaponsByCriteria(string criteria)
        {
            try
            {
                return this._context.Weapons
                .Where(w => w.Name.ToUpper().Contains(criteria.ToUpper()) || // search by name
                w.Examine != null && w.Examine.ToString().ToUpper().Contains(criteria.ToUpper()) || // search by examine text
                w.PrimaryAttackType.ToUpper().Contains(criteria.ToUpper()) || // search by primary attack type
                w.SecondaryAttackType.ToUpper().Contains(criteria.ToUpper()) || // search by secondary attack type
                w.RequiredAttackLvl.ToString().ToUpper().Contains(criteria.ToUpper()) || // search by required attack lvl
                w.RequiredStrengthLvl.ToString().ToUpper().Contains(criteria.ToUpper()) // search by required strength lvl
                ).ToList();
            }
            catch (DbException)
            {
                throw new DbOperationException("An error occurred while attempting to retrieve weapons from the database.");
            }
        }

        /// <summary>
        /// Retrieves a weapon from the database based on the weapon ID
        /// </summary>
        /// <param name="weaponID">The ID of the weapon to retrieve</param>
        /// <returns>The weapon with the specified ID, or null if not found</returns>
        public Weapon? GetWeaponByWeaponID(int weaponID)
        {   
            try
            {
                var weapon = this._context.Weapons.Find(weaponID);

                if (weapon == null)
                {
                    throw new EntityNotFoundException($"Search failed as a weapon with ID #{weaponID} does not exist.");
                }
                else
                {
                    return weapon;
                }
            }
            catch (DbException)
            {
                throw new DbOperationException("An error occurred while attempting to retrieve weapons from the database.");
            }
        }

        /// <summary>
        /// Creates a new weapon in the database
        /// </summary>
        /// <param name="name">The name of the weapon</param>
        /// <param name="examine">The examine text of the weapon</param>
        /// <param name="exchangePrice">The exchange price of the weapon</param>
        /// <param name="highAlchPrice">The high alchemy price of the weapon</param>
        /// <param name="requiredAttackLvl">The required attack level for using the weapon</param>
        /// <param name="requiredStrengthLvl">The required strength level for using the weapon</param>
        /// <param name="primaryAttackType">The primary attack type of the weapon</param>
        /// <param name="secondaryAttackType">The secondary attack type of the weapon</param>
        /// <param name="attackSpeed">The attack speed of the weapon</param>
        /// <param name="attackStab">The stab attack bonus of the weapon</param>
        /// <param name="attackSlash">The slash attack bonus of the weapon</param>
        /// <param name="attackCrush">The crush attack bonus of the weapon</param>
        /// <param name="attackMagic">The magic attack bonus of the weapon</param>
        /// <param name="attackRanged">The ranged attack bonus of the weapon</param>
        /// <param name="defenceStab">The stab defence bonus of the weapon</param>
        /// <param name="defenceSlash">The slash defence bonus of the weapon</param>
        /// <param name="defenceCrush">The crush defence bonus of the weapon</param>
        /// <param name="defenceMagic">The magic defence bonus of the weapon</param>
        /// <param name="defenceRanged">The ranged defence bonus of the weapon</param>
        /// <param name="meleeStrength">The melee strength bonus of the weapon</param>
        /// <param name="magicStrength">The magic strength bonus of the weapon</param>
        /// <param name="rangedStrength">The ranged strength bonus of the weapon</param>
        /// <param name="prayerBonus">The prayer bonus of the weapon</param>
        /// <param name="weight">The weight of the weapon</param>
        /// <param name="imageURL">The URL of the image for the weapon</param>
        /// <param name="modifiable">Determines if the weapon is modifiable</param>
        /// <returns>The newly created weapon</returns>
        public Weapon CreateWeapon(
            string name,
            string examine,
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
            bool? modifiable)
        {
            try
            { 
                if (name.Length < 3)
                {
                    throw new WeaponCreateException("Weapon name must be at least 3 characters long.");
                }
                else if (examine.Length < 3)
                {
                    throw new WeaponCreateException("Weapon examine text must be at least 3 characters long.");
                }
                else if (!ValidationUtility.IsValidURL(imageURL))
                {
                    throw new WeaponCreateException("Image URL is not a fully qualified domain name.");
                }
                else
                {
                    var weapon = new Weapon
                    {
                        Name = name,
                        Examine = examine,
                        ExchangePrice = exchangePrice,
                        HighAlchPrice = highAlchPrice,
                        RequiredAttackLvl = requiredAttackLvl,
                        RequiredStrengthLvl = requiredStrengthLvl,
                        PrimaryAttackType = primaryAttackType,
                        SecondaryAttackType = secondaryAttackType,
                        AttackSpeed = attackSpeed,
                        AttackStab = attackStab,
                        AttackSlash = attackSlash,
                        AttackCrush = attackCrush,
                        AttackMagic = attackMagic,
                        AttackRanged = attackRanged,
                        DefenceStab = defenceStab,
                        DefenceSlash = defenceSlash,
                        DefenceCrush = defenceCrush,
                        DefenceMagic = defenceMagic,
                        DefenceRanged = defenceRanged,
                        MeleeStrength = meleeStrength,
                        MagicStrength = magicStrength,
                        RangedStrength = rangedStrength,
                        PrayerBonus = prayerBonus,
                        Weight = weight,
                        ImageURL = imageURL,
                        Modifiable = modifiable
                    };

                    _context.Weapons.Add(weapon);
                    _context.SaveChanges();

                    return weapon;
                }
            }
            catch (DbException)
            {
                throw new DbOperationException("An error occurred while attempting to retrieve weapons from the database.");
            }
        }

        /// <summary>
        /// Updates an existing weapon in the database
        /// </summary>
        /// <param name="weaponID">The ID of the weapon to update</param>
        /// <param name="name">The new name of the weapon</param>
        /// <param name="examine">The new examine text of the weapon</param>
        /// <param name="exchangePrice">The new exchange price of the weapon</param>
        /// <param name="highAlchPrice">The new high alchemy price of the weapon</param>
        /// <param name="requiredAttackLvl">The new required attack level for using the weapon</param>
        /// <param name="requiredStrengthLvl">The new required strength level for using the weapon</param>
        /// <param name="primaryAttackType">The new primary attack type of the weapon</param>
        /// <param name="secondaryAttackType">The new secondary attack type of the weapon</param>
        /// <param name="attackSpeed">The new attack speed of the weapon</param>
        /// <param name="attackStab">The new stab attack bonus of the weapon</param>
        /// <param name="attackSlash">The new slash attack bonus of the weapon</param>
        /// <param name="attackCrush">The new crush attack bonus of the weapon</param>
        /// <param name="attackMagic">The new magic attack bonus of the weapon</param>
        /// <param name="attackRanged">The new ranged attack bonus of the weapon</param>
        /// <param name="defenceStab">The new stab defence bonus of the weapon</param>
        /// <param name="defenceSlash">The new slash defence bonus of the weapon</param>
        /// <param name="defenceCrush">The new crush defence bonus of the weapon</param>
        /// <param name="defenceMagic">The new magic defence bonus of the weapon</param>
        /// <param name="defenceRanged">The new ranged defence bonus of the weapon</param>
        /// <param name="meleeStrength">The new melee strength bonus of the weapon</param>
        /// <param name="magicStrength">The new magic strength bonus of the weapon</param>
        /// <param name="rangedStrength">The new ranged strength bonus of the weapon</param>
        /// <param name="prayerBonus">The new prayer bonus of the weapon</param>
        /// <param name="weight">The new weight of the weapon</param>
        /// <param name="imageURL">The new URL of the image for the weapon</param>
        /// <param name="modifiable">Determines if the weapon is modifiable</param>
        public Weapon? UpdateWeapon(
            int weaponID,
            string name,
            string examine,
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
            bool? modifiable)
        {
            try
            {
                var weapon = _context.Weapons.Find(weaponID);

                if (weapon == null)
                {
                    throw new EntityNotFoundException($"Update failed as a weapon with ID #{weaponID} does not exist.");
                }
                else if (weapon != null && weapon.Modifiable == false)
                {
                    throw new WeaponUnmodifiableException($"The weapon with ID #{weaponID} could not be modified. You may not modify weapons that are marked as unmodifiable.");
                }
                else if (weapon != null && weapon.Modifiable == true)
                {
                    if (name.Length < 3)
                    {
                        throw new WeaponUpdateException("Weapon name must be at least 3 characters long.");
                    }
                    else if (examine.Length < 3)
                    {
                        throw new WeaponUpdateException("Weapon examine text must be at least 3 characters long.");
                    }
                    else if (imageURL != null && !ValidationUtility.IsValidURL(imageURL))
                    {
                        throw new WeaponUpdateException("Image URL is not a fully qualified domain name.");
                    }
                    else
                    {
                        weapon.Name = name;
                        weapon.Examine = examine;
                        weapon.ExchangePrice = exchangePrice;
                        weapon.HighAlchPrice = highAlchPrice;
                        weapon.RequiredAttackLvl = requiredAttackLvl;
                        weapon.RequiredStrengthLvl = requiredStrengthLvl;
                        weapon.PrimaryAttackType = primaryAttackType;
                        weapon.SecondaryAttackType = secondaryAttackType;
                        weapon.AttackSpeed = attackSpeed;
                        weapon.AttackStab = attackStab;
                        weapon.AttackSlash = attackSlash;
                        weapon.AttackCrush = attackCrush;
                        weapon.AttackMagic = attackMagic;
                        weapon.AttackRanged = attackRanged;
                        weapon.DefenceStab = defenceStab;
                        weapon.DefenceSlash = defenceSlash;
                        weapon.DefenceCrush = defenceCrush;
                        weapon.DefenceMagic = defenceMagic;
                        weapon.DefenceRanged = defenceRanged;
                        weapon.MeleeStrength = meleeStrength;
                        weapon.MagicStrength = magicStrength;
                        weapon.RangedStrength = rangedStrength;
                        weapon.PrayerBonus = prayerBonus;
                        weapon.Weight = weight;
                        weapon.ImageURL = imageURL;
                        weapon.Modifiable = modifiable;
                    }
                }
                _context.SaveChanges();

                return weapon;
            }
            catch (DbException)
            {
                throw new DbOperationException("An error occurred while attempting to retrieve weapons from the database.");
            }
        }

        /// <summary>
        /// Updates an existing weapon in the database with the provided changes
        /// </summary>
        /// <param name="weaponID">The ID of the weapon to update</param>
        /// <param name="request">The object containing the updated values</param>
        public Weapon? PatchWeapon(int weaponID, WeaponPatchRequest request)
        {
            try
            {
                // Retrieve the weapon from the database
                var existingWeapon = _context.Weapons.Find(weaponID);

                // If the weapon doesn't exist, throw an exception or handle it appropriately
                if (existingWeapon == null)
                {
                    throw new EntityNotFoundException($"Update failed as a weapon with ID #{weaponID} does not exist.");
                }
                else if (existingWeapon != null && existingWeapon.Modifiable == false)
                {
                    throw new WeaponUnmodifiableException($"The weapon with ID #{weaponID} could not be modified. You may not modify weapons that are marked as unmodifiable.");
                }
                else if (existingWeapon != null && existingWeapon.Modifiable == true)
                {
                    if (request.Name != null && existingWeapon != null)
                    { // checking if every entry is not equal to null is to dodge the dreaded yellow squiggly underline
                        if (request.Name.Length < 3)
                        {
                            throw new WeaponUpdateException("Weapon name must be at least 3 characters long.");
                        }
                        else
                        {
                            existingWeapon.Name = request.Name;
                        }
                    }

                    if (request.Examine != null && existingWeapon != null)
                    {
                        if (request.Examine.Length < 3)
                        {
                            throw new WeaponUpdateException("Weapon examine text must be at least 3 characters long.");
                        }
                        else
                        {
                            existingWeapon.Examine = request.Examine;
                        }
                    }

                    if (request.ExchangePrice != null && existingWeapon != null)
                    {
                        existingWeapon.ExchangePrice = request.ExchangePrice.Value;
                    }

                    if (request.HighAlchPrice != null && existingWeapon != null)
                    {
                        existingWeapon.HighAlchPrice = request.HighAlchPrice.Value;
                    }

                    if (request.RequiredAttackLvl != null && existingWeapon != null)
                    {
                        existingWeapon.RequiredAttackLvl = request.RequiredAttackLvl.Value;
                    }

                    if (request.RequiredStrengthLvl != null && existingWeapon != null)
                    {
                        existingWeapon.RequiredStrengthLvl = request.RequiredStrengthLvl.Value;
                    }

                    if (request.PrimaryAttackType != null && existingWeapon != null)
                    {
                        existingWeapon.PrimaryAttackType = request.PrimaryAttackType;
                    }

                    if (request.SecondaryAttackType != null && existingWeapon != null)
                    {
                        existingWeapon.SecondaryAttackType = request.SecondaryAttackType;
                    }

                    if (request.AttackSpeed != null && existingWeapon != null)
                    {
                        existingWeapon.AttackSpeed = request.AttackSpeed.Value;
                    }

                    if (request.AttackStab != null && existingWeapon != null)
                    {
                        existingWeapon.AttackStab = request.AttackStab.Value;
                    }

                    if (request.AttackSlash != null && existingWeapon != null)
                    {
                        existingWeapon.AttackSlash = request.AttackSlash.Value;
                    }

                    if (request.AttackCrush != null && existingWeapon != null)
                    {
                        existingWeapon.AttackCrush = request.AttackCrush.Value;
                    }

                    if (request.AttackMagic != null && existingWeapon != null)
                    {
                        existingWeapon.AttackMagic = request.AttackMagic.Value;
                    }

                    if (request.AttackRanged != null && existingWeapon != null)
                    {
                        existingWeapon.AttackRanged = request.AttackRanged.Value;
                    }

                    if (request.DefenceStab != null && existingWeapon != null)
                    {
                        existingWeapon.DefenceStab = request.DefenceStab.Value;
                    }

                    if (request.DefenceSlash != null && existingWeapon != null)
                    {
                        existingWeapon.DefenceSlash = request.DefenceSlash.Value;
                    }

                    if (request.DefenceCrush != null && existingWeapon != null)
                    {
                        existingWeapon.DefenceCrush = request.DefenceCrush.Value;
                    }

                    if (request.DefenceMagic != null && existingWeapon != null)
                    {
                        existingWeapon.DefenceMagic = request.DefenceMagic.Value;
                    }

                    if (request.DefenceRanged != null && existingWeapon != null)
                    {
                        existingWeapon.DefenceRanged = request.DefenceRanged.Value;
                    }

                    if (request.MeleeStrength != null && existingWeapon != null)
                    {
                        existingWeapon.MeleeStrength = request.MeleeStrength.Value;
                    }

                    if (request.MagicStrength != null && existingWeapon != null)
                    {
                        existingWeapon.MagicStrength = request.MagicStrength.Value;
                    }

                    if (request.RangedStrength != null && existingWeapon != null)
                    {
                        existingWeapon.RangedStrength = request.RangedStrength.Value;
                    }

                    if (request.PrayerBonus != null && existingWeapon != null)
                    {
                        existingWeapon.PrayerBonus = request.PrayerBonus.Value;
                    }

                    if (request.Weight != null && existingWeapon != null)
                    {
                        existingWeapon.Weight = request.Weight.Value;
                    }

                    if (request.ImageURL != null && existingWeapon != null)
                    {
                        if (request.ImageURL != null && !ValidationUtility.IsValidURL(request.ImageURL))
                        {
                            throw new WeaponUpdateException("Image URL is not a fully qualified domain name.");
                        }
                        else
                        {
                            existingWeapon.ImageURL = request.ImageURL;
                        }
                    }
                }
                else
                {
                    throw new WeaponUpdateException($"Something went wrong when attempting to update the weapon with ID #{weaponID}.");
                }

                _context.SaveChanges();

                return existingWeapon;
            }
            catch (DbException)
            {
                throw new DbOperationException("An error occurred while attempting to retrieve weapons from the database.");
            }
        }
        
        /// <summary>
        /// Deletes a weapon from the database by its ID
        /// </summary>
        /// <param name="weaponID">The ID of the weapon to delete</param>
        /// <exception cref="EntityNotFoundException">Thrown when the weapon with the specified ID does not exist</exception>
        /// <exception cref="WeaponUnmodifiableException">Thrown when attempting to delete a weapon that is marked as unmodifiable</exception>
        /// <exception cref="WeaponDeleteException">Thrown when an error occurs during the delete operation</exception>
        public string DeleteWeapon(int weaponID)
        {
            try
            {
                var weapon = _context.Weapons.Find(weaponID);
                string msg = $"Weapon with ID #{weaponID} has been deleted.";

                if (weapon == null)
                {
                    throw new EntityNotFoundException($"Delete failed as a weapon with ID #{weaponID} does not exist.");
                }
                else if (weapon != null && weapon.Modifiable == false)
                {
                    throw new WeaponUnmodifiableException($"The weapon with ID #{weaponID} could not be modified. You may not delete weapons that are marked as unmodifiable.");
                }
                else if (weapon != null && weapon.Modifiable == true)
                {
                _context.Weapons.Remove(weapon);
                _context.SaveChanges();

                return msg;
                }
                else
                {
                    throw new WeaponDeleteException($"Something went wrong when attempting to delete the weapon with ID #{weaponID}.");
                }
            }
            catch (DbException)
            {
                throw new DbOperationException("An error occurred while attempting to retrieve weapons from the database.");
            }
        }
    }
}
