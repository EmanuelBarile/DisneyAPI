using Contracts.Repositories;
using Contracts.Service;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Repositories;
using Services;
using Swashbuckle.AspNetCore.Swagger;

namespace DisneyAPI
{
    public class Startup
    {

        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // agregar servicios aquí


            services.AddDbContext<DisneyContext>(option => option.UseSqlServer(_configuration.GetConnectionString("DisneyAPISQL")));


            services.AddTransient<ICharacterRepository, CharacterRepository>();
            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<ICharacterService, CharacterService>();
            services.AddTransient<IGenreService, GenreService>();
            services.AddTransient<IMovieService, MovieService>();

        }

        public void Configure(IApplicationBuilder app)
        {
            // configurar la aplicación aquí
        }
    }
}