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

namespace Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private DisneyContext _context { get; set; }
        public MovieRepository(DisneyContext context)
        {
            _context = context;
        }

        public IList<MovieDTO> GetAllMovies()
        {
            return _context.Movies.Where(x => x.Id_Movie != null).Select(x => new MovieDTO()
            {
                Image_Movie = x.Image_Movie,
                Title = x.Title,
                Characters = _context.Characters.Select(c => new CharacterDTO
                {

                    Image_Character = c.Image_Character,
                    Name = c.Name,
                    Age = c.Age,
                    Weight = c.Weight,
                    History = c.History,
                }).ToList()

            }).ToList();
        }

        public MovieDTO GetMovieByName(string title)
        {
            if (_context.Movies.Any(x => x.Title != title))
            {
                throw new CharacterException("The title doesn´t exists.");
            }
            var movie = _context.Movies.Find(title);
            return new MovieDTO()
            {
                Image_Movie = movie.Image_Movie,
                Title= movie.Title
                
            };
        }


        public IList<MovieDTO> GetMoviesFilterByName(string title) //nombre tentativo
        {
            if (_context.Movies.Any(x => x.Title != title))
            {
                throw new CharacterException("The title doesn´t exists.");
            }
            var movies = _context.Movies.Where(m => m.Title.Contains(title)).Select(m => new MovieDTO()
            {
                Image_Movie = m.Image_Movie,
                Title = m.Title
            }).ToList();
            return movies;
        }




        public void AddMovie(MovieDTO movieDTO)
        {

            if (_context.Movies.Any(x => x.Title == movieDTO.Title))
            {
                throw new CharacterException("The name is already taken.");
            }
            _context.Movies.Add(new DataAccess.Models.Movie()
            {
                Image_Movie = movieDTO.Image_Movie,
                Title = movieDTO.Title,
                Creation_Date = movieDTO.Creation_Date,
                Rating = movieDTO.Rating,
                Genre_Id = movieDTO.Genre_Id

            });


        }


        public void DeleteMovie(MovieDTO movieDTO)
        {

            var deleteMovie = _context.Movies.FirstOrDefault(x => x.Title == movieDTO.Title)
                ?? throw new CharacterException("Name of character does not exist.");


            _context.Movies.Remove(deleteMovie);

        }

        public void ModifyMovie(MovieDTO movieDTO)
        {

            var modifyMovie = _context.Movies.FirstOrDefault(x => x.Title == movieDTO.Title)
                ?? throw new CharacterException("Name of character does not exist.");

            modifyMovie.Title = movieDTO.Title;
            modifyMovie.Image_Movie = movieDTO.Image_Movie;
            modifyMovie.Creation_Date = movieDTO.Creation_Date;
            modifyMovie.Rating = movieDTO.Rating;
            modifyMovie.Genre_Id = movieDTO.Genre_Id;

            _context.Movies.Update(modifyMovie);

        }

    }
}


