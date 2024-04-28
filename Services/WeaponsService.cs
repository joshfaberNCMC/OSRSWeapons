using OSRSWeapons.Models;
using OSRSWeapons.Models.Requests;
using OSRSWeapons.Repositories;
using OSRSWeapons.Exceptions;

namespace OSRSWeapons.Services 
{

    /// <summary>
    /// Represents a service for managing weapons in the OSRSWeapons application
    /// </summary>
    /// <author>Josh Faber</author>
    public class WeaponsService {

        private readonly IWeaponsRepository _weaponsRepository;

        /// <summary>
        /// Initializes a new instance of the WeaponsService class
        /// </summary>
        /// <param name="weaponsRepository">The weapons repository to be used by the service</param>
        public WeaponsService(IWeaponsRepository weaponsRepository) 
        {
            this._weaponsRepository = weaponsRepository;
        }

        /// <summary>
        /// Retrieves a list of weapons based on the provided search criteria
        /// </summary>
        /// <param name="criteria">The search criteria to filter the weapons</param>
        /// <returns>A list of weapons that match the search criteria</returns>
        public List<Weapon> GetWeapons(string? criteria) 
        {
            List<Weapon> weapons = [];

            if (criteria != null) 
            {
                weapons.AddRange(this._weaponsRepository.GetWeaponsByCriteria(criteria));

                if (weapons.Count == 0) // check if search criteria results in a list with no items
                {
                    throw new NoCriteriaMatchException("There are no items that matched your search criteria.");
                }
            } 
            else 
            {
                weapons.AddRange(this._weaponsRepository.GetWeapons());
            }

            return weapons;
        }

        /// <summary>
        /// Retrieves a weapon by its ID
        /// </summary>
        /// <param name="weaponID">The ID of the weapon to retrieve</param>
        /// <returns>The weapon corresponding to the provided ID, or null if not found</returns>
        public Weapon? GetWeaponByWeaponID(int weaponID) 
        {
            return this._weaponsRepository.GetWeaponByWeaponID(weaponID);
        }

    /// <summary>
    /// Creates a new weapon based on the provided request data
    /// </summary>
    /// <param name="request">The request containing information about the weapon to be created</param>
    /// <returns>The newly created weapon</returns>
        public Weapon CreateWeapon(WeaponCreateRequest request)
        {
            return this._weaponsRepository.CreateWeapon(
                request.Name,
                request.Examine,
                request.ExchangePrice,
                request.HighAlchPrice,
                request.RequiredAttackLvl,
                request.RequiredStrengthLvl,
                request.PrimaryAttackType,
                request.SecondaryAttackType,
                request.AttackSpeed,
                request.AttackStab,
                request.AttackSlash,
                request.AttackCrush,
                request.AttackMagic,
                request.AttackRanged,
                request.DefenceStab,
                request.DefenceSlash,
                request.DefenceCrush,
                request.DefenceMagic,
                request.DefenceRanged,
                request.MeleeStrength,
                request.MagicStrength,
                request.RangedStrength,
                request.PrayerBonus,
                request.Weight,
                request.ImageURL
            );
        }

        /// <summary>
        /// Updates an existing weapon with the provided request data
        /// </summary>
        /// <param name="request">The request containing updated information about the weapon</param>
        /// <param name="weaponID">The ID of the weapon to be updated</param>
        public void UpdateWeapon(WeaponCreateRequest request, int weaponID) 
        {
            _weaponsRepository.UpdateWeapon(
                weaponID,
                request.Name,
                request.Examine,
                request.ExchangePrice,
                request.HighAlchPrice,
                request.RequiredAttackLvl,
                request.RequiredStrengthLvl,
                request.PrimaryAttackType,
                request.SecondaryAttackType,
                request.AttackSpeed,
                request.AttackStab,
                request.AttackSlash,
                request.AttackCrush,
                request.AttackMagic,
                request.AttackRanged,
                request.DefenceStab,
                request.DefenceSlash,
                request.DefenceCrush,
                request.DefenceMagic,
                request.DefenceRanged,
                request.MeleeStrength,
                request.MagicStrength,
                request.RangedStrength,
                request.PrayerBonus,
                request.Weight,
                request.ImageURL);
        } 

        /// <summary>
        /// Applies partial updates to an existing weapon using the provided patch request
        /// </summary>
        /// <param name="request">The patch request containing partial updates for the weapon</param>
        /// <param name="weaponID">The ID of the weapon to be patched</param>
        public void PatchWeapon(WeaponPatchRequest request, int weaponID) 
        {
            _weaponsRepository.PatchWeapon(weaponID, request);
        }

        /// <summary>
        /// Deletes a weapon from the repository by its ID
        /// </summary>
        /// <param name="weaponID">The ID of the weapon to be deleted</param>
        public void DeleteWeapon(int weaponID) 
        {
            this._weaponsRepository.DeleteWeapon(weaponID);
        }

    }

}
