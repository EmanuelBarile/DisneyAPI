using Common.DTO;
using Common.Exceptions;
using Contracts.Repositories;
using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Repositories.CharacterRepository;

namespace Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private DisneyContext _context { get; set; }
        public CharacterRepository(DisneyContext context)
        {
            _context = context;
        }

        public IList<CharacterDTO> GetAllCharacters()
        {
            return _context.Characters.Where(x => x.Id_Character != null).Select(x => new CharacterDTO()
            {
                Image_Character = x.Image_Character,
                Name = x.Name,
            }).ToList();
        }

        public CharacterDTO GetMoviesByCharacter(string name)
        {
            /* 
            var character = _context.Characters.Find(name);
            return new CharacterDTO()
            {
                Image_Character = character.Image_Character,
                Name = character.Name,
                Age = character.Age,
                Weight = character.Weight,
                History = character.History
                ).ToList()
            };
            */
            return null;
        }

        public CharacterDTO GetCharacterByName(string name)
        {
            var character = _context.Characters.Find(name);
            return new CharacterDTO()
            {
                Image_Character = character.Image_Character,
                Name = character.Name
            };
        }

        public void AddCharacter(CharacterDTO characterDTO)
        {

            if (_context.Characters.Any(x => x.Name == characterDTO.Name))
            {
                throw new CharacterExceptions("The name is already taken.");
            }
            _context.Characters.Add(new DataAccess.Models.Character()
            {
                Image_Character = characterDTO.Image_Character,
                Name = characterDTO.Name,
                Age = characterDTO.Age,
                Weight = characterDTO.Weight,
                History = characterDTO.History
            });

        }

        public void DeleteCharacter(CharacterDTO characterDTO)
        {

            var deleteCharacter = _context.Characters.FirstOrDefault(x => x.Name == characterDTO.Name)
                ?? throw new CharacterExceptions("Name of character does not exist.");


            _context.Characters.Remove(deleteCharacter);

        }

        public void ModifyCharacter(CharacterDTO characterDTO)
        {

            var modifyCharacter = _context.Characters.FirstOrDefault(x => x.Name == characterDTO.Name)
                ?? throw new CharacterExceptions("Name of character does not exist.");

            modifyCharacter.Image_Character = characterDTO.Image_Character;
            modifyCharacter.Name = characterDTO.Name;
            modifyCharacter.Age = characterDTO.Age;
            modifyCharacter.Weight = characterDTO.Weight;
            modifyCharacter.History = characterDTO.History;

            _context.Characters.Update(modifyCharacter);

        }
    }
}
