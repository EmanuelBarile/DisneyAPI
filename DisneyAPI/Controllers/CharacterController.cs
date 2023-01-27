using Common.DTO;
using Contracts.Repositories;
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
        



    


    }
}
