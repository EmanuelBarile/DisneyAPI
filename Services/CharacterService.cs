using Common.DTO;
using Common.Exceptions;
using Contracts.Repositories;
using Contracts.Service;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CharacterService : ICharacterService
    {
        private readonly DisneyContext _context;
        private readonly ICharacterRepository characterRepository;

        public CharacterService(DisneyContext context, ICharacterRepository characterRepository)
        {
            _context = context;
            this.characterRepository = characterRepository;
        }

        public ResponseDTO GetAllCharacters()
        {
            ResponseDTO result = new();

            try
            {
                result.Result = characterRepository.GetAllCharacters();
                result.Success = true;
            }
            catch (CharacterExceptions characterExceptions)
            {
                result.Success = false;
                result.Message = characterExceptions.Message;
            }
            catch
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error, lamentamos lo sucedido.";
            }

            return result;
        }
        

        public ResponseDTO GetMoviesByCharacter(string name)
        {
            ResponseDTO result = new();

            try
            {
                result.Result = characterRepository.GetMoviesByCharacter(name);
                result.Success = true;
            }
            catch (CharacterExceptions characterExceptions)
            {
                result.Success = false;
                result.Message = characterExceptions.Message;
            }
            catch
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error, lamentamos lo sucedido.";
            }

            return result;
        }


        public ResponseDTO GetCharacterByName(string name)
        {
            ResponseDTO result = new();

            try
            {
                result.Result = characterRepository.GetCharacterByName(name);
                result.Success = true;
            }
            catch (CharacterExceptions characterExceptions)
            {
                result.Success = false;
                result.Message = characterExceptions.Message;
            }
            catch
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error, lamentamos lo sucedido.";
            }

            return result;
        }


        public ResponseDTO AddCharacter(CharacterDTO characterDTO)
        {
            ResponseDTO result = new();

            try
            {
                characterRepository.AddCharacter(characterDTO);
                result.Success = true;
                _context.SaveChanges();
            }
            catch (CharacterExceptions characterExceptions)
            {
                result.Success = false;
                result.Message = characterExceptions.Message;
            }
            catch
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error, lamentamos lo sucedido.";
            }

            return result;
        }


        public ResponseDTO DeleteCharacter(CharacterDTO characterDTO)
        {
            ResponseDTO result = new();

            try
            {
                characterRepository.DeleteCharacter(characterDTO);
                result.Success = true;
                _context.SaveChanges();
            }
            catch (CharacterExceptions characterExceptions)
            {
                result.Success = false;
                result.Message = characterExceptions.Message;
            }
            catch
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error, lamentamos lo sucedido.";
            }

            return result;
        }
                       

        public ResponseDTO ModifyCharacter(CharacterDTO characterDTO)
        {
            ResponseDTO result = new();

            try
            {
                characterRepository.ModifyCharacter(characterDTO);
                result.Success = true;
                _context.SaveChanges();
            }
            catch (CharacterExceptions characterExceptions)
            {
                result.Success = false;
                result.Message = characterExceptions.Message;
            }
            catch
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error, lamentamos lo sucedido.";
            }

            return result;
        }
    }    
}
