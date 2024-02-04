using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService; // Dependency Injection

        public CharacterController(ICharacterService characterService)
        {
            this._characterService = characterService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Character>>> Get()
        {
            return Ok(await _characterService.GetCharacters());
        }

        [HttpGet("{id}/{name}")]
        public async Task<IActionResult> GetSingle(int id, string name)
        {
            return Ok(await _characterService.GetCharacterById(id, name));
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddCharacter(AddCharacterDto newCharacter)
        {
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteCharacter(DeleteCharacterDto character)
        {
            return Ok(await _characterService.DeleteCharacter(character));
        }

        [HttpPut("put")]
        public async Task<IActionResult> UpdateCharacter(UpdateCharacterDto character)
        {
            return Ok(await _characterService.UpdateCharacter(character));
        }

    }
}