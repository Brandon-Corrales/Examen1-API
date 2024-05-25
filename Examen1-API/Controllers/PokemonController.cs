using Microsoft.AspNetCore.Mvc;
using Examen1_API.Services;
using System.Globalization;
using System.Xml.Linq;

namespace Examen1_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly PokemonServices pokemonServices;

        private readonly ILogger<PokemonController> _logger;

        public PokemonController(PokemonServices pokemonServices)
        {
            this.pokemonServices = pokemonServices;
        }

        [HttpGet(Name = "PokeAPI")]
        public async Task<IActionResult> GetPokemon(string name)
        {
            var pokemon = await pokemonServices.GetPokemonAsync(name);
            if (pokemon == null)
            {
                return NotFound();
            }
            return Ok(pokemon);
        }
    }
}