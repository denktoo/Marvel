using Marvel.Models;
using System.Collections.Generic;

namespace Marvel.Repositories
{
    public interface ICharactersRepository
    {
        Task<IEnumerable<Character>> GetCharacters();
        Task<Character> GetCharacterById(int id);
        Task<Character> PostCharacter(Character character);
        Task<bool> PutCharacter(int id, Character character);
        Task<bool> DeleteCharacter(int id);
    }
}