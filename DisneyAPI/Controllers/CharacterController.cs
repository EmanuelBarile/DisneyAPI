using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DisneyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {

        private readonly DisneyContext _context;

        public CharacterController(DisneyContext context)
        {
            _context = context;
        }

        // GET: API/Characters
        [HttpGet("CharactersList")]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
        {
            return await _context.Characters.ToListAsync();
        }


    }
}
