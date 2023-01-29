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
    public class GenreService : IGenreService
    {
        private readonly DisneyContext _context;
        private readonly IGenreRepository genreRepository;

        public GenreService(DisneyContext context, IGenreRepository genreRepository)
        {
            _context = context;
            this.genreRepository = genreRepository;
        }


        public ResponseDTO GetAllMoviesByGenre(string name)
        {
            ResponseDTO result = new();

            try
            {
                result.Result = genreRepository.GetAllMoviesByGenre(name);
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

        public ResponseDTO AddGenre(GenreDTO genreDTO)
        {
            ResponseDTO result = new();

            try
            {
                genreRepository.AddGenre(genreDTO);
                result.Success = true;
                _context.SaveChanges();
            }
            catch (GenreExceptions genreExceptions)
            {
                result.Success = false;
                result.Message = genreExceptions.Message;
            }
            catch
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error, lamentamos lo sucedido.";
            }

            return result;
        }

        public ResponseDTO DeleteGenre(GenreDTO genreDTO)
        {
            ResponseDTO result = new();
            try
            {
                genreRepository.DeleteGenre(genreDTO);
                result.Success = true;
                _context.SaveChanges();
            }
            catch (GenreExceptions genreExceptions)
            {
                result.Success = false;
                result.Message = genreExceptions.Message;
            }
            catch
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error, lamentamos lo sucedido.";
            }

            return result;
        }               

        public ResponseDTO ModifyGenre(GenreDTO genreDTO)
        {
            ResponseDTO result = new();
            try
            {
                genreRepository.ModifyGenre(genreDTO);
                result.Success = true;
                _context.SaveChanges();
            }
            catch (GenreExceptions usuarioExceptions)
            {
                result.Success = false;
                result.Message = usuarioExceptions.Message;
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
