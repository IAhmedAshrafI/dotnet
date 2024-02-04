using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet.Models;

namespace dotnet.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<List<GetCharacterDto>> GetCharacters();
        Task<GetCharacterDto> GetCharacterById(int id, string name);
        Task<List<GetCharacterDto>> AddCharacter(AddCharacterDto newCharacter);
        Task<List<Character>> DeleteCharacter(DeleteCharacterDto character);
        Task<List<Character>> UpdateCharacter(UpdateCharacterDto character);
    }
}