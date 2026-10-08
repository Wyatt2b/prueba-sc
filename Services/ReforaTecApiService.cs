using ReforaTec.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace ReforaTec.Services
{
    public class ReforaTecApiService : IReforaTecApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ReforaTecApiService> _logger;

        // ✅ Constructor modificado para usar IHttpClientFactory
        public ReforaTecApiService(IHttpClientFactory httpClientFactory, ILogger<ReforaTecApiService> logger)
        {
            _httpClient = httpClientFactory.CreateClient("ReforaTecApi");
            _logger = logger;
        }

        // ============ AUTENTICACIÓN ============

        public async Task RequestOtpAsync(AuthRequestOtpRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/v1/otp-codes", request);
            response.EnsureSuccessStatusCode();
        }

        public async Task<AuthVerifyOtpResponse> VerifyOtpAsync(AuthVerifyOtpRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/v1/sessions", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<AuthVerifyOtpResponse>();
        }

        public async Task<AuthRefreshSessionResponse> RefreshSessionAsync(AuthRefreshSessionRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/v1/sessions/refresh", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<AuthRefreshSessionResponse>();
        }

        public async Task RevokeSessionAsync(AuthRevokeSessionRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/v1/sessions/revoke", request);
            response.EnsureSuccessStatusCode();
        }

        public async Task<AuthRegisterUserResponse> RegisterUserAsync(AuthRegisterUserRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/v1/users", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<AuthRegisterUserResponse>();
        }

        // ============ ÁRBOLES ============

        public async Task<List<UsersGetMyTreesResponse>> GetMyAssignedTreesAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<UsersGetMyTreesResponse>>("/api/v1/users/me/trees")
                       ?? new List<UsersGetMyTreesResponse>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error al obtener árboles asignados");
                return new List<UsersGetMyTreesResponse>();
            }
        }

        public async Task<TreesGetTreeByIdResponse> GetTreeByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<TreesGetTreeByIdResponse>($"/api/v1/trees/{id}");
        }

        public async Task<List<TreesGetTreeServicesResponse>> GetTreeServicesAsync(int treeId)
        {
            return await _httpClient.GetFromJsonAsync<List<TreesGetTreeServicesResponse>>($"/api/v1/trees/{treeId}/services")
                   ?? new List<TreesGetTreeServicesResponse>();
        }

        public async Task<UploadFileResponse> UploadTreeMeasurementPhotoAsync(int treeId, Stream fileStream, string fileName)
        {
            using var content = new MultipartFormDataContent();
            var streamContent = new StreamContent(fileStream);
            streamContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            content.Add(streamContent, "treePhoto", fileName);

            var response = await _httpClient.PostAsync($"/api/v1/trees/{treeId}/measurements/photo", content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UploadFileResponse>();
        }

        // ============ CAMPAÑAS ============

        public async Task<CampaignsGetCampaignByIdResponse> GetCampaignByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<CampaignsGetCampaignByIdResponse>($"/api/v1/campaigns/{id}");
        }

        public async Task<CampaignsCreateCampaignResponse> CreateCampaignAsync(CampaignsCreateCampaignRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/v1/campaigns", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CampaignsCreateCampaignResponse>();
        }

        // ============ CATÁLOGOS (SUBIDA DE ARCHIVOS) ============

        public async Task<UploadFileResponse> UploadSpeciesImageAsync(Stream fileStream, string fileName)
        {
            using var content = new MultipartFormDataContent();
            var streamContent = new StreamContent(fileStream);
            streamContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            content.Add(streamContent, "speciesImage", fileName);

            var response = await _httpClient.PostAsync("/api/v1/species/images", content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UploadFileResponse>();
        }

        public async Task<UploadFileResponse> UploadServiceTypeIconAsync(Stream fileStream, string fileName)
        {
            using var content = new MultipartFormDataContent();
            var streamContent = new StreamContent(fileStream);
            streamContent.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            content.Add(streamContent, "iconFile", fileName);

            var response = await _httpClient.PostAsync("/api/v1/service-types/icons", content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UploadFileResponse>();
        }
    }
}