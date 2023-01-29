using Common.DTO;
using Contracts.Service;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace DisneyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost("AddMovie")]
        public ResponseDTO AddMovie([FromQuery] MovieDTO movieDTO, List<CharacterDTO> characters)
        {
            return _movieService.AddMovie(movieDTO, characters);
        }

    }
}
