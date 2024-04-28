using Microsoft.AspNetCore.Mvc;
using OSRSWeapons.Configurations;
using OSRSWeapons.Repositories;
using OSRSWeapons.Models;
using OSRSWeapons.Models.Requests;
using OSRSWeapons.Services;

namespace OSRSWeapons.Controllers 
{
    /// <summary>
    /// Controller for managing weapons
    /// </summary>
    /// <author>Josh Faber</author>
    [ApiController]
    public class WeaponsController : ControllerBase 
    {
        private readonly WeaponsService _weaponsService;

        /// <summary>
        /// Constructor for WeaponsController
        /// </summary>
        /// <param name="weaponsService">Instance of WeaponsService</param>
        public WeaponsController(WeaponsService weaponsService) 
        {
            _weaponsService = weaponsService;
        }

        /// <summary>
        /// Retrieves a list of weapons
        /// </summary>
        /// <param name="criteria">Optional criteria to filter the list of weapons</param>
        /// <returns>The list of weapons</returns>
        [HttpGet("weapons", Name = "GetWeapons")]
        public List<Weapon> GetWeapons([FromQuery] string? criteria) 
        {
            var weapons = _weaponsService.GetWeapons(criteria);
            
            return weapons;
        }

        /// <summary>
        /// Retrieves a weapon by its ID
        /// </summary>
        /// <param name="weaponID">The ID of the weapon</param>
        /// <returns>The weapon with that matching ID</returns>
        [HttpGet("weapons/{weaponID}", Name = "GetWeaponByWeaponID")]
        public Weapon? GetWeaponByWeaponID(int weaponID) 
        {
            var weapon = _weaponsService.GetWeaponByWeaponID(weaponID);

            return weapon;
        }

        /// <summary>
        /// Creates a new weapon
        /// </summary>
        /// <param name="request">The request containing data for the new weapon</param>
        /// <returns>The created weapon</returns>
        [HttpPost("weapons", Name = "CreateWeapon")]
        public Weapon CreateWeapon([FromBody] WeaponCreateRequest request) 
        {
            var createdWeapon = _weaponsService.CreateWeapon(request);

            return createdWeapon;
        }

        /// <summary>
        /// Updates an existing weapon
        /// </summary>
        /// <param name="weaponID">The ID of the weapon to update</param>
        /// <param name="request">The request containing updated data for the weapon</param>
        [HttpPut("weapons/{weaponID}", Name = "UpdateWeapon")]
        public void UpdateWeapon(int weaponID, [FromBody] WeaponCreateRequest request) 
        {
            _weaponsService.UpdateWeapon(request, weaponID);
        }

        /// <summary>
        /// Patches an existing weapon
        /// </summary>
        /// <param name="weaponID">The ID of the weapon to patch</param>
        /// <param name="request">The request containing updated data for the weapon</param>
        [HttpPatch("weapons/{weaponID}", Name = "PatchWeapon")]
        public void PatchWeapon(int weaponID, [FromBody] WeaponPatchRequest request) 
        {
            _weaponsService.GetWeaponByWeaponID(weaponID);
            _weaponsService.PatchWeapon(request, weaponID);
        }

        /// <summary>
        /// Deletes a weapon
        /// </summary>
        /// <param name="weaponID">The ID of the weapon to delete</param>
        [HttpDelete("weapons/{weaponID}", Name = "DeleteWeapon")]
        public void DeleteWeapon(int weaponID) 
        {
            _weaponsService.DeleteWeapon(weaponID);
        }
    }
}
