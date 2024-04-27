using OSRSWeapons.Models;
using OSRSWeapons.Models.Requests;
using OSRSWeapons.Repositories;
using OSRSWeapons.Exceptions;

namespace OSRSWeapons.Services {

    public class WeaponsService {

        private readonly IWeaponsRepository _weaponsRepository;

        public WeaponsService(IWeaponsRepository weaponsRepository) {
            this._weaponsRepository = weaponsRepository;
        }

        public List<Weapon> GetWeapons(string? criteria) {
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

        public Weapon? GetWeaponByWeaponId(int weaponId) {
            return this._weaponsRepository.GetWeaponById(weaponId);
        }

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
                request.ImageUrl,
                request.Modifiable
            );
        }

        public void UpdateWeapon(WeaponCreateRequest request, int weaponId) 
        {
            try
            {
                _weaponsRepository.UpdateWeapon(
                    weaponId,
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
                    request.ImageUrl,
                    request.Modifiable);
            }

            catch (Exception ex)
            {
                // If the exception message indicates that the entity is not found
                if (ex.Message.Contains("not found"))
                {
                    throw new EntityNotFoundException($"Update failed as a weapon with ID #{weaponId} does not exist.");
                }
                else // Otherwise, throw a WeaponUpdateException
                {
                    throw new WeaponUpdateException("Failed to update the weapon.");
                }
            }
        } 

        public void PatchWeapon(WeaponPatchRequest request, int weaponId) 
        {
            try
            {
                _weaponsRepository.PatchWeapon(weaponId, request);
            }

            catch (Exception ex)
            {
                // If the exception message indicates that the entity is not found
                if (ex.Message.Contains("not found"))
                {
                    throw new EntityNotFoundException($"Update failed as a weapon with ID #{weaponId} does not exist.");
                }
                else // Otherwise, throw a WeaponUpdateException
                {
                    throw new WeaponUpdateException("Failed to update the weapon.");
                }
            }
        }

        public void DeleteWeapon(int weaponId) {
            this._weaponsRepository.DeleteWeapon(weaponId);
        }

    }

}
