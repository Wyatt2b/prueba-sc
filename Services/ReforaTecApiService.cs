using System.Net.Http;
using System.Net.Http.Json;
using ReforaTec.Models;

namespace ReforaTec.Services
{
    public class ReforaTecApiService : IReforaTecApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ReforaTecApiService> _logger;

        public ReforaTecApiService(HttpClient httpClient, ILogger<ReforaTecApiService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        // ============ TREES ============
        public async Task<List<Tree>> GetTreesAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Tree>>("/api/v1/trees") 
                       ?? new List<Tree>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error al obtener los árboles");
                return new List<Tree>();
            }
        }

        public async Task<Tree> GetTreeByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Tree>($"/api/v1/trees/{id}");
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, $"Error al obtener el árbol con ID {id}");
                throw; // Re-lanza para que la página maneje el error
            }
        }

        public async Task<Tree> CreateTreeAsync(Tree newTree)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/v1/trees", newTree);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<Tree>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error al crear un nuevo árbol");
                throw;
            }
        }

        // ============ SPECIES ============
        public async Task<List<Species>> GetSpeciesAsync()
        {
            try
            {
                // Asumiendo que existe el endpoint; si no, ajusta la ruta
                return await _httpClient.GetFromJsonAsync<List<Species>>("/api/v1/species") 
                       ?? new List<Species>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error al obtener las especies");
                return new List<Species>();
            }
        }

        public async Task<Species> GetSpeciesByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Species>($"/api/v1/species/{id}");
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, $"Error al obtener la especie con ID {id}");
                throw;
            }
        }

        public async Task<Species> CreateSpeciesAsync(Species newSpecies)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/v1/species", newSpecies);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<Species>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error al crear una nueva especie");
                throw;
            }
        }

        // ============ VALUES ============
        public async Task<List<Value>> GetValuesAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Value>>("/api/v1/values") 
                       ?? new List<Value>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error al obtener los valores");
                return new List<Value>();
            }
        }

        public async Task<Value> GetValueByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Value>($"/api/v1/values/{id}");
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, $"Error al obtener el valor con ID {id}");
                throw;
            }
        }

        public async Task<Value> CreateValueAsync(Value newValue)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/v1/values", newValue);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<Value>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error al crear un nuevo valor");
                throw;
            }
        }
    }
}