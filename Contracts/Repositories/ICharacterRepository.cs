using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface ICharacterRepository
    {
        IList<CharacterDTO> GetAllCharacters();

        CharacterDTO GetCharacterByName (string name);
        void AddCharacter(CharacterDTO characterDTO);
        void DeleteCharacter(CharacterDTO characterDTO);
        void ModifyCharacter(CharacterDTO characterDTO);

    }
}
