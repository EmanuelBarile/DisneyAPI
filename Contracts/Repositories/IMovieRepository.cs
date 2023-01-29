using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface IMovieRepository
    {
        IList<MovieDTO> GetAllMovies();
        MovieDTO GetMovieByName(string title);
        IList<MovieDTO> GetMoviesFilterByName(string title);       
        void AddMovie(MovieDTO movieDTO, List<CharacterDTO> characters);
        void DeleteMovie(MovieDTO movieDTO);
        void ModifyMovie(MovieDTO movieDTO);
    }
}
