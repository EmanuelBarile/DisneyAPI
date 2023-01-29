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
    public class GenreController : ControllerBase
    {

        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpPost("AddGenre")]
        public ResponseDTO AddGenre([FromQuery] GenreDTO newGenre)
        {
            return _genreService.AddGenre(newGenre);
        }
    }
}
