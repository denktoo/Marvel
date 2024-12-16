using Marvel.Data;
using Marvel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marvel.Repositories
{
    public class CharactersRepository : ICharactersRepository
    {
        private readonly MarvelContext _context;

        public CharactersRepository(MarvelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Character>> GetCharacters()
        {
            var characters = await _context.Characters.ToListAsync();
            if (characters == null)
            {
                return null;
            }
            return characters;
        }

        public async Task<Character> GetCharacterById(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return null;
            }

            return character;
        }

        public async Task<Character> PostCharacter(Character character)
        {
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            return character;
        }

        public async Task<bool> PutCharacter(int id, Character character)
        {
            if (id != character.Id)
            {
                return false;
            }

            _context.Entry(character).State = EntityState.Modified; // Mark entity as modified

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public async Task<bool> DeleteCharacter(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return false;
            }

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
