using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface IGenreRepository
    {
        GenreDTO GetAllMoviesByGenre(string name);
        void AddGenre(GenreDTO genreDTO);
        void DeleteGenre(GenreDTO genreDTO);
        void ModifyGenre(GenreDTO genreDTO);
    }
   


}
