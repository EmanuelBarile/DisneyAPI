using Common.DTO;
using Common.Exceptions;
using Contracts.Repositories;
using Contracts.Service;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MovieService : IMovieService
    {
        private readonly DisneyContext _context;
        private readonly IMovieRepository movieRepository;

        public MovieService(DisneyContext context, IMovieRepository movieRepository)
        {
            _context = context;
            this.movieRepository = movieRepository;
        }

        public ResponseDTO GetAllMovies()
        {
            ResponseDTO result = new();

            try
            {
                result.Result = movieRepository.GetAllMovies();
                result.Success = true;
            }
            catch (MovieExceptions movieExceptions)
            {
                result.Success = false;
                result.Message = movieExceptions.Message;
            }
            catch
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error, lamentamos lo sucedido.";
            }


            return result;
        }

        public ResponseDTO GetMovieByName(string title)
        {
            ResponseDTO result = new();

            try
            {
                result.Result = movieRepository.GetMovieByName(title);
                result.Success = true;
            }
            catch (MovieExceptions movieExceptions)
            {
                result.Success = false;
                result.Message = movieExceptions.Message;
            }
            catch
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error, lamentamos lo sucedido.";
            }


            return result;
        }

        public ResponseDTO GetMoviesFilterByName(string title)
        {
            ResponseDTO result = new();

            try
            {
                result.Result = movieRepository.GetMoviesFilterByName(title);
                result.Success = true;
            }
            catch (MovieExceptions movieExceptions)
            {
                result.Success = false;
                result.Message = movieExceptions.Message;
            }
            catch
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error, lamentamos lo sucedido.";
            }


            return result;
        }

        public ResponseDTO AddMovie(MovieDTO movieDTO, List<CharacterDTO> characters)
        {
            ResponseDTO result = new();

            try
            {
                movieRepository.AddMovie(movieDTO, characters);
                result.Success = true;
                _context.SaveChanges();
            }
            catch (MovieExceptions movieExceptions)
            {
                result.Success = false;
                result.Message = movieExceptions.Message;
            }
            catch
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error, lamentamos lo sucedido.";
            }


            return result;
        }

        public ResponseDTO DeleteMovie(MovieDTO movieDTO)
        {
            ResponseDTO result = new();

            try
            {
                movieRepository.DeleteMovie(movieDTO);
                result.Success = true;
                _context.SaveChanges();
            }
            catch (MovieExceptions movieExceptions)
            {
                result.Success = false;
                result.Message = movieExceptions.Message;
            }
            catch
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error, lamentamos lo sucedido.";
            }

            return result;
        }
                
        public ResponseDTO ModifyMovie(MovieDTO movieDTO)
        {
            ResponseDTO result = new();

            try
            {
                movieRepository.ModifyMovie(movieDTO);
                result.Success = true;
                _context.SaveChanges();
            }
            catch (MovieExceptions movieExceptions)
            {
                result.Success = false;
                result.Message = movieExceptions.Message;
            }
            catch
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error, lamentamos lo sucedido.";
            }

            return result;
        }
    }    
}
