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
        public IActionResult GetWeapons([FromQuery] string? criteria) 
        {
            var weapons = _weaponsService.GetWeapons(criteria);
            return Ok(weapons);
        }

        /// <summary>
        /// Retrieves a weapon by its ID
        /// </summary>
        /// <param name="weaponId">The ID of the weapon</param>
        /// <returns>The weapon with the specified ID, if found; otherwise, NotFound</returns>
        [HttpGet("weapons/{weaponId}", Name = "GetWeaponById")]
        public IActionResult GetWeaponById(int weaponId) 
        {
            var weapon = _weaponsService.GetWeaponByWeaponId(weaponId);

            if (weapon == null) 
            {
                return NotFound();
            }

            return Ok(weapon);
        }

        /// <summary>
        /// Creates a new weapon
        /// </summary>
        /// <param name="request">The request containing data for the new weapon</param>
        /// <returns>The created weapon</returns>
        [HttpPost("weapons", Name = "CreateWeapon")]
        public IActionResult CreateWeapon([FromBody] WeaponCreateRequest request) 
        {
            var createdWeapon = _weaponsService.CreateWeapon(request);

            return CreatedAtRoute("GetWeaponById", new { weaponId = createdWeapon.WeaponId }, createdWeapon);
        }

        /// <summary>
        /// Updates an existing weapon
        /// </summary>
        /// <param name="weaponId">The ID of the weapon to update</param>
        /// <param name="request">The request containing updated data for the weapon</param>
        /// <returns>NoContent</returns>
        [HttpPut("weapons/{weaponId}", Name = "UpdateWeapon")]
        public IActionResult UpdateWeapon(int weaponId, [FromBody] WeaponCreateRequest request) 
        {
            _weaponsService.UpdateWeapon(request, weaponId);

            return NoContent();
        }

        [HttpPatch("weapons/{weaponId}", Name = "PatchWeapon")]
        public IActionResult PatchWeapon(int weaponId, [FromBody] WeaponPatchRequest request) 
        {
            var existingWeapon = _weaponsService.GetWeaponByWeaponId(weaponId);

            if (existingWeapon == null) 
            {
                return NotFound(); // put a custom exception here
            }
            else
            {
                _weaponsService.PatchWeapon(request, weaponId);

                return NoContent(); // put a custom exception here
            }
        }

        /// <summary>
        /// Deletes a weapon
        /// </summary>
        /// <param name="weaponId">The ID of the weapon to delete</param>
        /// <returns>NoContent</returns>
        [HttpDelete("weapons/{weaponId}", Name = "DeleteWeapon")]
        public IActionResult DeleteWeapon(int weaponId) 
        {
            _weaponsService.DeleteWeapon(weaponId);
            
            return NoContent();
        }
    }
}
