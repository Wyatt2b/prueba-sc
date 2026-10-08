using ReforaTec.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ReforaTec.Services
{
    public class AuthMessageHandler : DelegatingHandler
    {
        private readonly TokenService _tokenService;
        private readonly ILogger<AuthMessageHandler> _logger;
        private const string BaseUrl = "https://reforatec-api.onrender.com";

        public AuthMessageHandler(TokenService tokenService, ILogger<AuthMessageHandler> logger)
        {
            _tokenService = tokenService;
            _logger = logger;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // 1. Adjuntar el token actual
            var token = await _tokenService.GetAccessTokenAsync();
            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            // 2. Enviar la solicitud
            var response = await base.SendAsync(request, cancellationToken);

            // 3. Si es 401, intentar refrescar
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var refreshToken = await _tokenService.GetRefreshTokenAsync();
                if (string.IsNullOrEmpty(refreshToken))
                {
                    _logger.LogWarning("Sin refresh token, no se puede refrescar");
                    return response;
                }

                try
                {
                    // Cliente independiente para evitar recursión
                    using var refreshClient = new HttpClient { BaseAddress = new Uri(BaseUrl) };
                    var refreshResponse = await refreshClient.PostAsJsonAsync(
                        "/api/v1/sessions/refresh",
                        new AuthRefreshSessionRequest
                        {
                            RefreshToken = refreshToken,
                            Audience = "refortec-web"
                        });

                    if (refreshResponse.IsSuccessStatusCode)
                    {
                        var newTokens = await refreshResponse.Content
                            .ReadFromJsonAsync<AuthRefreshSessionResponse>();

                        await _tokenService.SaveTokensAsync(
                            newTokens.AccessToken,
                            newTokens.RefreshToken);

                        // Reintentar la solicitud original
                        using var retryRequest = await CloneRequestAsync(request);
                        retryRequest.Headers.Authorization =
                            new AuthenticationHeaderValue("Bearer", newTokens.AccessToken);
                        return await base.SendAsync(retryRequest, cancellationToken);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al refrescar token");
                }
            }

            return response;
        }

        private static async Task<HttpRequestMessage> CloneRequestAsync(HttpRequestMessage request)
        {
            var clone = new HttpRequestMessage(request.Method, request.RequestUri);

            if (request.Content != null)
            {
                var content = await request.Content.ReadAsByteArrayAsync();
                clone.Content = new ByteArrayContent(content);

                foreach (var header in request.Content.Headers)
                    clone.Content.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            foreach (var header in request.Headers)
                clone.Headers.TryAddWithoutValidation(header.Key, header.Value);

            return clone;
        }
    }
}