using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Service
{
    public interface IMovieService
    {
        ResponseDTO GetAllMovies();

        ResponseDTO GetMoviesByGenre(int id);

        ResponseDTO GetMoviesByCharacter(int id);

        ResponseDTO GetMoviesByName(string name);

        ResponseDTO AddMovie(MovieDTO movieDTO);

        ResponseDTO DeleteMovie(MovieDTO movieDTO);

        ResponseDTO ModifyMovie(MovieDTO movieDTO);

    }
}
