using ReforaTec.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

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

        // ============ ÁRBOLES (Trees) ============
        public async Task<List<ApiTree>> GetTreesAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<ApiTree>>("/api/v1/trees") 
                       ?? new List<ApiTree>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error al obtener los árboles");
                return new List<ApiTree>();
            }
        }

        public async Task<ApiTree> GetTreeByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ApiTree>($"/api/v1/trees/{id}");
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, $"Error al obtener el árbol con ID {id}");
                throw;
            }
        }

        public async Task<ApiTree> CreateTreeAsync(ApiTree newTree)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/v1/trees", newTree);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<ApiTree>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error al crear un nuevo árbol");
                throw;
            }
        }

        // ============ ESPECIES (Species) ============
        public async Task<List<ApiSpecies>> GetSpeciesAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<ApiSpecies>>("/api/v1/species") 
                       ?? new List<ApiSpecies>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error al obtener las especies");
                return new List<ApiSpecies>();
            }
        }

        public async Task<ApiSpecies> GetSpeciesByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ApiSpecies>($"/api/v1/species/{id}");
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, $"Error al obtener la especie con ID {id}");
                throw;
            }
        }

        public async Task<ApiSpecies> CreateSpeciesAsync(ApiSpecies newSpecies)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/v1/species", newSpecies);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<ApiSpecies>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error al crear una nueva especie");
                throw;
            }
        }

        // ============ VALORES (Values) ============
        public async Task<List<ApiValue>> GetValuesAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<ApiValue>>("/api/v1/values") 
                       ?? new List<ApiValue>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error al obtener los valores");
                return new List<ApiValue>();
            }
        }

        public async Task<ApiValue> GetValueByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ApiValue>($"/api/v1/values/{id}");
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, $"Error al obtener el valor con ID {id}");
                throw;
            }
        }

        public async Task<ApiValue> CreateValueAsync(ApiValue newValue)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/v1/values", newValue);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<ApiValue>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error al crear un nuevo valor");
                throw;
            }
        }
    }
}