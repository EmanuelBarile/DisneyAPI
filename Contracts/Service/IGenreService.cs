using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Service
{
    public interface IGenreService
    {
        ResponseDTO GetAllMoviesByGenre(string name);
        ResponseDTO AddGenre(GenreDTO movieDTO);
        ResponseDTO DeleteGenre(GenreDTO movieDTO);
        ResponseDTO ModifyGenre(GenreDTO movieDTO);

    }
}
