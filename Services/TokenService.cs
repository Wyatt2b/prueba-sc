using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace ReforaTec.Services
{
    public class TokenService
    {
        private readonly IJSRuntime _js;
        private const string AccessTokenKey = "access_token";
        private const string RefreshTokenKey = "refresh_token";

        public TokenService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task<string?> GetAccessTokenAsync()
        {
            try
            {
                return await _js.InvokeAsync<string?>("localStorageHelper.getItem", AccessTokenKey);
            }
            catch
            {
                return null;
            }
        }

        public async Task<string?> GetRefreshTokenAsync()
        {
            try
            {
                return await _js.InvokeAsync<string?>("localStorageHelper.getItem", RefreshTokenKey);
            }
            catch
            {
                return null;
            }
        }

        public async Task SaveTokensAsync(string accessToken, string refreshToken)
        {
            await _js.InvokeVoidAsync("localStorageHelper.setItem", AccessTokenKey, accessToken);
            await _js.InvokeVoidAsync("localStorageHelper.setItem", RefreshTokenKey, refreshToken);
        }

        public async Task ClearTokensAsync()
        {
            await _js.InvokeVoidAsync("localStorageHelper.removeItem", AccessTokenKey);
            await _js.InvokeVoidAsync("localStorageHelper.removeItem", RefreshTokenKey);
        }
    }
}