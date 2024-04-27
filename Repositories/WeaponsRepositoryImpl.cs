using System;
using System.Collections.Generic;
using System.Linq;
using OSRSWeapons.Models;
using OSRSWeapons.Models.Requests;
using OSRSWeapons.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace OSRSWeapons.Repositories
{
    public class WeaponsRepositoryImpl : IWeaponsRepository
    {
        private readonly OSRSWeaponsDbContext _context;

        public WeaponsRepositoryImpl(OSRSWeaponsDbContext context)
        {
            _context = context;
        }

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
            string? imageUrl,
            bool? modifiable)
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
                ImageUrl = imageUrl,
                Modifiable = modifiable
            };

            _context.Weapons.Add(weapon);
            _context.SaveChanges();

            return weapon;
        }

        public void DeleteWeapon(int id)
        {
            var weapon = _context.Weapons.Find(id);
            if (weapon != null && weapon.Modifiable == true)
            {
                _context.Weapons.Remove(weapon);
                _context.SaveChanges();
            }
            else if (weapon != null && weapon.Modifiable == false)
            {
                 throw new Exception($"The weapon with ID {id} could not be modified. You man not change or delete weapons that are marked as unmodifiable.");
            }
            else
            {
                throw new Exception($"Weapon with ID {id} was not found. Could not delete weapon.");
            }
        }

        public List<Weapon> GetWeapons()
        {
            return _context.Weapons.ToList();
        }

        public List<Weapon> GetWeaponsByCriteria(string criteria)
        {
            return _context.Weapons
                .Where(w => w.Name.Contains(criteria) ||
                w.Examine != null && w.Examine.ToString().Contains(criteria) ||
                w.PrimaryAttackType.Contains(criteria) || 
                w.SecondaryAttackType.Contains(criteria) ||
                w.RequiredAttackLvl.ToString().Contains(criteria) ||
                w.RequiredAttackLvl.ToString().Contains(criteria)
                ).ToList();
        }

        public Weapon? GetWeaponById(int id)
        {
            return _context.Weapons.Find(id);
        }

        public void UpdateWeapon(
            int id,
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
            string? imageUrl,
            bool? modifiable)
        {
            var weapon = _context.Weapons.Find(id);
            if (weapon != null && weapon.Modifiable == true)
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
                weapon.ImageUrl = imageUrl;
                weapon.Modifiable = modifiable;

                _context.SaveChanges();
            }
            else if (weapon != null && weapon.Modifiable == false)
            {
                throw new Exception($"The weapon with ID {id} could not be modified. You man not change or delete weapons that are marked as unmodifiable.");
            }
            else
            {
                throw new Exception($"Weapon with ID {id} was not found. Could not update weapon.");
            }
        }

        
        public void PatchWeapon(int weaponId, WeaponPatchRequest request)
        {
            // Retrieve the weapon from the database
            var existingWeapon = _context.Weapons.Find(weaponId);
            Console.WriteLine(existingWeapon);

            // If the weapon doesn't exist, throw an exception or handle it appropriately
            if (existingWeapon == null)
            {
                throw new EntityNotFoundException($"Update failed as a weapon with ID #{weaponId} does not exist.");
            }

            if (request.Name != null)
            {
                existingWeapon.Name = request.Name;
            }

            if (request.Examine != null)
            {
                existingWeapon.Examine = request.Examine;
            }

            if (request.ExchangePrice != null)
            {
                existingWeapon.ExchangePrice = request.ExchangePrice.Value;
            }

            if (request.HighAlchPrice != null)
            {
                existingWeapon.HighAlchPrice = request.HighAlchPrice.Value;
            }

            if (request.RequiredAttackLvl != null)
            {
                existingWeapon.RequiredAttackLvl = request.RequiredAttackLvl.Value;
            }

            if (request.RequiredStrengthLvl != null)
            {
                existingWeapon.RequiredStrengthLvl = request.RequiredStrengthLvl.Value;
            }

            if (request.PrimaryAttackType != null)
            {
                existingWeapon.PrimaryAttackType = request.PrimaryAttackType;
            }

            if (request.SecondaryAttackType != null)
            {
                existingWeapon.SecondaryAttackType = request.SecondaryAttackType;
            }

            if (request.AttackSpeed != null)
            {
                existingWeapon.AttackSpeed = request.AttackSpeed.Value;
            }

            if (request.AttackStab != null)
            {
                existingWeapon.AttackStab = request.AttackStab.Value;
            }

            if (request.AttackSlash != null)
            {
                existingWeapon.AttackSlash = request.AttackSlash.Value;
            }

            if (request.AttackCrush != null)
            {
                existingWeapon.AttackCrush = request.AttackCrush.Value;
            }

            if (request.AttackMagic != null)
            {
                existingWeapon.AttackMagic = request.AttackMagic.Value;
            }

            if (request.AttackRanged != null)
            {
                existingWeapon.AttackRanged = request.AttackRanged.Value;
            }

            if (request.DefenceStab != null)
            {
                existingWeapon.DefenceStab = request.DefenceStab.Value;
            }

            if (request.DefenceSlash != null)
            {
                existingWeapon.DefenceSlash = request.DefenceSlash.Value;
            }

            if (request.DefenceCrush != null)
            {
                existingWeapon.DefenceCrush = request.DefenceCrush.Value;
            }

            if (request.DefenceMagic != null)
            {
                existingWeapon.DefenceMagic = request.DefenceMagic.Value;
            }

            if (request.DefenceRanged != null)
            {
                existingWeapon.DefenceRanged = request.DefenceRanged.Value;
            }

            if (request.MeleeStrength != null)
            {
                existingWeapon.MeleeStrength = request.MeleeStrength.Value;
            }

            if (request.MagicStrength != null)
            {
                existingWeapon.MagicStrength = request.MagicStrength.Value;
            }

            if (request.RangedStrength != null)
            {
                existingWeapon.RangedStrength = request.RangedStrength.Value;
            }

            if (request.PrayerBonus != null)
            {
                existingWeapon.PrayerBonus = request.PrayerBonus.Value;
            }

            if (request.Weight != null)
            {
                existingWeapon.Weight = request.Weight.Value;
            }

            if (request.ImageUrl != null)
            {
                existingWeapon.ImageUrl = request.ImageUrl;
            }

            if (request.Modifiable != null)
            {
                existingWeapon.Modifiable = request.Modifiable.Value;
            }

            _context.SaveChanges();
        }
    }
}
