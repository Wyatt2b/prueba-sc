using ReforaTec.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ReforaTec.Services
{
    public interface IReforaTecApiService
    {
        // Autenticación
        Task<AuthVerifyOtpResponse> VerifyOtpAsync(AuthVerifyOtpRequest request);
        Task<AuthRefreshSessionResponse> RefreshSessionAsync(AuthRefreshSessionRequest request);
        Task RevokeSessionAsync(AuthRevokeSessionRequest request);
        Task<AuthRegisterUserResponse> RegisterUserAsync(AuthRegisterUserRequest request);
        Task RequestOtpAsync(AuthRequestOtpRequest request);

        // Árboles
        Task<List<UsersGetMyTreesResponse>> GetMyAssignedTreesAsync();
        Task<TreesGetTreeByIdResponse> GetTreeByIdAsync(int id);
        Task<List<TreesGetTreeServicesResponse>> GetTreeServicesAsync(int treeId);
        Task<UploadFileResponse> UploadTreeMeasurementPhotoAsync(int treeId, Stream fileStream, string fileName);

        // Campañas
        Task<CampaignsGetCampaignByIdResponse> GetCampaignByIdAsync(int id);
        Task<CampaignsCreateCampaignResponse> CreateCampaignAsync(CampaignsCreateCampaignRequest request);

        // Catálogos (subida de archivos)
        Task<UploadFileResponse> UploadSpeciesImageAsync(Stream fileStream, string fileName);
        Task<UploadFileResponse> UploadServiceTypeIconAsync(Stream fileStream, string fileName);
    }
}