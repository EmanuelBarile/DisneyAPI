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
        ResponseDTO GetMovieByName(string title);
        ResponseDTO GetMoviesFilterByName(string title);        
        ResponseDTO AddMovie(MovieDTO movieDTO, List<CharacterDTO> characters);
        ResponseDTO DeleteMovie(MovieDTO movieDTO);
        ResponseDTO ModifyMovie(MovieDTO movieDTO);        
        
    }
}
