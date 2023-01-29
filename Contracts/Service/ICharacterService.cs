using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Service
{
    public interface ICharacterService
    {
        ResponseDTO GetAllCharacters();
        ResponseDTO GetMoviesByCharacter(string name);
        ResponseDTO GetCharacterByName(string name);
        ResponseDTO AddCharacter(CharacterDTO characterDTO);
        ResponseDTO DeleteCharacter(CharacterDTO characterDTO);
        ResponseDTO ModifyCharacter(CharacterDTO characterDTO);

    }    
}
