using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {

        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character {id = 1, name = "Sam"}
        };

        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CharacterService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<List<GetCharacterDto>> AddCharacter(AddCharacterDto newCharacter)
        {
            var DbContext = await _context.Characters.AddAsync(_mapper.Map<Character>(newCharacter));
            _context.SaveChanges();
            return _mapper.Map<List<GetCharacterDto>>(DbContext.Entity);
        }

        public async Task<List<Character>> DeleteCharacter(DeleteCharacterDto character)
        {
            var DbContext = await _context.Characters.FirstOrDefaultAsync(c => c.id == character.id);
            if (DbContext != null)
            {
                _context.Characters.Remove(DbContext);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException(nameof(character));
            }
            return characters;

        }

        public async Task<GetCharacterDto> GetCharacterById(int id, string name)
        {
            var DbContext = _context.Characters.FirstOrDefault(c => c.id == id && c.name == name)!;
            if (DbContext is not null)
            {
                return _mapper.Map<GetCharacterDto>(DbContext);
            }
            else
            {
                throw new ArgumentNullException(nameof(id));
            }
        }

        public async Task<List<GetCharacterDto>> GetCharacters()
        {
            var DbContext = await _context.Characters.ToListAsync();
            return _mapper.Map<List<GetCharacterDto>>(DbContext);
        }

        public async Task<List<Character>> UpdateCharacter(UpdateCharacterDto character)
        {
            var DbContext = await _context.Characters.FirstOrDefaultAsync(c => c.id == character.id);
            _mapper.Map(character, DbContext!);
            _context.Entry(DbContext).State = EntityState.Modified;
            _context.SaveChanges();
            return characters;
        }
    }
}