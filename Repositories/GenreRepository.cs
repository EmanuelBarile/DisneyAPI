using Common.DTO;
using Common.Exceptions;
using Contracts.Repositories;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private DisneyContext _context { get; set; }
        public GenreRepository(DisneyContext context)
        {
            _context = context;
        }

        public GenreDTO GetAllMoviesByGenre(string name)
        {
            if (_context.Genres.Any(x => x.Name != name))
            {
                throw new GenreExceptions("The genre doesn´t exists.");
            }
            var genre = _context.Genres.Find(name);
            return new GenreDTO()
            {
                Image_Genre = genre.Image_Genre,
                Name = genre.Name,
                Movies = _context.Movies.Select(c => new MovieDTO
                {

                    Image_Movie = c.Image_Movie,
                    Title = c.Title,
                    Creation_Date = c.Creation_Date,
                    Rating = c.Rating,

                }).ToList()
            };
        }

        public void AddGenre(GenreDTO genreDTO)
        {
            if (_context.Genres.Any(x => x.Name == genreDTO.Name))
            {
                throw new GenreExceptions("The name is already taken.");
            }
            _context.Genres.Add(new DataAccess.Models.Genre()
            {
                Image_Genre = genreDTO.Image_Genre,
                Name = genreDTO.Name
            });
        }

        public void DeleteGenre(GenreDTO genreDTO)
        {

            var deleteGenre = _context.Genres.FirstOrDefault(x => x.Name == genreDTO.Name)
                ?? throw new GenreExceptions("Gender does not exist.");

            _context.Genres.Remove(deleteGenre);

        }

        public void ModifyGenre(GenreDTO genreDTO)
        {
            var modifyGenre = _context.Genres.FirstOrDefault(x => x.Name == genreDTO.Name)
                ?? throw new GenreExceptions("Gender does not exist.");

            modifyGenre.Name = genreDTO.Name;
            modifyGenre.Image_Genre = genreDTO.Image_Genre;

            _context.Genres.Update(modifyGenre);
        }
    }
}
