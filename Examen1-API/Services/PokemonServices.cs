using Examen1_API.Models;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Examen1_API.Services
{
    public class PokemonServices
    {
        public readonly HttpClient _httpClient;

        public PokemonServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Pokemon> GetPokemonAsync(string name)
        {
            var response = await _httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon/{name.ToLower()}");
            var json = JObject.Parse(await response.Content.ReadAsStringAsync());

            var pokemon = new Pokemon
            {
                name = json["name"].ToString(),
                type = json["types"][0]["type"]["name"].ToString(),
                imagen = json["sprites"]["front_default"].ToString(),
                movimiento = json["moves"].Select(m => m["move"]["name"].ToString()).ToList()
            };

            return pokemon;
        }
    }
}

//