using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Marvel.Models;
using Marvel.Data;
using Marvel.Repositories;

namespace Marvel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharactersRepository _charactersRepository;

        public CharactersController(ICharactersRepository charactersRepository)
        {
            _charactersRepository = charactersRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
        {
            var CharacterDtos = await _charactersRepository.GetCharacters();
            return Ok(CharacterDtos);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(int id)
        {
            var characterDto = await _charactersRepository.GetCharacterById(id);

            if (characterDto == null)
            {
                return NotFound();
            }

            return Ok(characterDto);
        }

        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(Character character)
        {
            if (character == null)
            {
                return BadRequest("Character data is null.");
            }

            var addedCharacter = await _charactersRepository.PostCharacter(character);

            return CreatedAtAction(nameof(GetCharacter), new { id = addedCharacter.Id }, addedCharacter);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, [FromBody] Character character)
        {
            if (id != character.Id)
            {
                return BadRequest("Character ID mismatch.");
            }

            var updateSuccessful = await _charactersRepository.PutCharacter(id, character);

            if (!updateSuccessful)
            {
                if (!await _charactersRepository.GetCharacterById(id).ContinueWith(t => t.Result != null))
                {
                    return NotFound();
                }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var deletionSuccessful = await _charactersRepository.DeleteCharacter(id);

            if (!deletionSuccessful)
            {
                return NotFound($"Character with Id = {id} not found");
            }

            return NoContent();
        }
    }
}