using Common.DTO;
using Common.Exceptions;
using Contracts.Repositories;
using DataAccess;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
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
                /* REALIZAR LOGICA DESDE TABLA INTERMEDIA
                Characters = _context.Characters.Select(c => new CharacterDTO
                {

                    Image_Character = c.Image_Character,
                    Name = c.Name,
                    Age = c.Age,
                    Weight = c.Weight,
                    History = c.History,
                }).ToList()
                */
            }).ToList();
        }

        public MovieDTO GetMovieByName(string title)
        {

            if (_context.Movies.Any(x => x.Title != title))
            {
                throw new MovieExceptions("The title doesn´t exists.");
            }
            var movie = _context.Movies.Find(title);
            return new MovieDTO()
            {
                Image_Movie = movie.Image_Movie,
                Title = movie.Title                
            };

        }

        public IList<MovieDTO> GetMoviesFilterByName(string title)
        {

            if (_context.Movies.Any(x => x.Title != title))
            {
                throw new MovieExceptions("The title doesn´t exists.");
            }
            var movies = _context.Movies.Where(m => m.Title.Contains(title)).Select(m => new MovieDTO()
            {
                Image_Movie = m.Image_Movie,
                Title = m.Title
            }).ToList();
            return movies;

        }

        public void AddMovie(MovieDTO movieDTO, List<CharacterDTO> characters)
        {

            // Verificar si la pelicula ya existe
            var existePelicula = _context.Movies
                .Any(x => x.Id_Movie == movieDTO.Id_Movie);
            if (!existePelicula)
            {
                // Agregar pelicula a la tabla
                _context.Movies.Add(new DataAccess.Models.Movie
                {
                    Image_Movie = movieDTO.Image_Movie,
                    Title = movieDTO.Title,
                    Creation_Date = movieDTO.Creation_Date,
                    Rating = movieDTO.Rating,
                    Genre_Id = movieDTO.Genre_Id                    
                });
                _context.SaveChanges();
            }

            // Verificar si los personajes ya existen
            foreach (var character in characters)
            {
                var existePersonaje = _context.Characters
                    .Any(x => x.Id_Character == character.Id_Character);
                if (!existePersonaje)
                {
                    // Agregar personaje a la tabla
                    _context.Characters.Add(new DataAccess.Models.Character
                    {
                        Image_Character = character.Image_Character,
                        Name = character.Name,
                        Age = character.Age,
                        Weight = character.Weight,
                        History = character.History
                    });
                }

                // Agregar relacion a la tabla intermedia
                _context.CharacterMovies.Add(new DataAccess.Models.CharacterMovie
                {
                    Id_Character = character.Id_Character,
                    Id_Movie = movieDTO.Id_Movie
                });
            }
        }

        public void DeleteMovie(MovieDTO movieDTO)
        {

            var deleteMovie = _context.Movies.FirstOrDefault(x => x.Title == movieDTO.Title)
                ?? throw new MovieExceptions("Name of character does not exist.");


            _context.Movies.Remove(deleteMovie);

        }

        public void ModifyMovie(MovieDTO movieDTO)
        {

            var modifyMovie = _context.Movies.FirstOrDefault(x => x.Title == movieDTO.Title)
                ?? throw new MovieExceptions("Name of character does not exist.");

            modifyMovie.Title = movieDTO.Title;
            modifyMovie.Image_Movie = movieDTO.Image_Movie;
            modifyMovie.Creation_Date = movieDTO.Creation_Date;
            modifyMovie.Rating = movieDTO.Rating;
            modifyMovie.Genre_Id = movieDTO.Genre_Id;

            _context.Movies.Update(modifyMovie);
        }
    }
}


