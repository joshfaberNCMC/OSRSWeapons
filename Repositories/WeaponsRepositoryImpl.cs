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

        public List<Weapon> GetWeapons()
        {
            return _context.Weapons.ToList();
        }

        public List<Weapon> GetWeaponsByCriteria(string criteria)
        {
            return this._context.Weapons
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
            var weapon = this._context.Weapons.Find(id);

            if (weapon == null)
            {
                throw new EntityNotFoundException($"Search failed as a weapon with ID #{id} does not exist.");
            }

            return weapon;
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
            if (weapon != null && weapon.Modifiable == true)
            {
                _context.Weapons.Remove(weapon);
                _context.SaveChanges();
            }
            else if (weapon != null && weapon.Modifiable == false)
            {
                throw new WeaponUnmodifiableException($"The weapon with ID {id} could not be modified. You may not modify weapons that are marked as unmodifiable.");
            }
            else
            {
                throw new EntityNotFoundException($"Update failed as a weapon with ID #{id} does not exist.");
            }
        }

        
        public void PatchWeapon(int weaponId, WeaponPatchRequest request)
        {
            // Retrieve the weapon from the database
            var existingWeapon = _context.Weapons.Find(weaponId);

            // If the weapon doesn't exist, throw an exception or handle it appropriately
            if (existingWeapon == null)
            {
                throw new EntityNotFoundException($"Update failed as a weapon with ID #{weaponId} does not exist.");
            }
            else if (existingWeapon != null && existingWeapon.Modifiable == false)
            {
                throw new WeaponUnmodifiableException($"The weapon with ID {weaponId} could not be modified. You may not modify weapons that are marked as unmodifiable.");
            }
            else
            {
                if (request.Name != null && existingWeapon != null)
                {
                    existingWeapon.Name = request.Name;
                }

                if (request.Examine != null && existingWeapon != null)
                {
                    existingWeapon.Examine = request.Examine;
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

                if (request.ImageUrl != null && existingWeapon != null)
                {
                    existingWeapon.ImageUrl = request.ImageUrl;
                }
            }

            _context.SaveChanges();
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
                throw new WeaponUnmodifiableException($"The weapon with ID {id} could not be modified. You may not delete weapons that are marked as unmodifiable.");
            }
            else
            {
                throw new EntityNotFoundException($"Delete failed as a weapon with ID #{id} does not exist.");
            }
        }
    }
}
