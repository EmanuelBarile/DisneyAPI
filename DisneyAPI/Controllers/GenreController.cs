using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DisneyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
       
        private readonly DisneyContext _context;

        public GenreController(DisneyContext context)
        {
            _context = context;
        }


    }
}
