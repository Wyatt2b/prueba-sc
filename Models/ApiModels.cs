using System;
using System.Collections.Generic;

namespace ReforaTec.Models
{
    // ==========================================
    // AUTENTICACIÓN
    // ==========================================
    public class AuthRequestOtpRequest
    {
        public string Email { get; set; }
    }

    public class AuthVerifyOtpRequest
    {
        public string Email { get; set; }
        public string OtpCode { get; set; }
        public string Audience { get; set; }
    }

    public class AuthVerifyOtpResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string TokenType { get; set; }
        public int ExpiresInSeconds { get; set; }
    }

    public class AuthRefreshSessionRequest
    {
        public string RefreshToken { get; set; }
        public string Audience { get; set; }
    }

    public class AuthRefreshSessionResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }

    public class AuthRevokeSessionRequest
    {
        public string RefreshToken { get; set; }
    }

    public class AuthRegisterUserRequest
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string? SecondLastName { get; set; }
        public string ControlNumber { get; set; }
        public string? PhoneNumber { get; set; }
    }

    public class AuthRegisterUserResponse
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string? SecondLastName { get; set; }
        public string? ControlNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    // ==========================================
    // ÁRBOLES (TREES)
    // ==========================================
    public class UsersGetMyTreesResponse
    {
        public int Id { get; set; }
        public int SpeciesId { get; set; }
        public string CommonName { get; set; }
        public string ScientificName { get; set; }
        public string ValueName { get; set; }
        public string? CurrentCampaignName { get; set; }
        public string? CurrentCampaignFolio { get; set; }
        public string HealthState { get; set; }
        public DateOnly? PlantingDate { get; set; }
        public decimal? CurrentHeightCentimeters { get; set; }
        public decimal? CurrentDiameterCentimeters { get; set; }
        public string? SpeciesImageUrl { get; set; }
        public string? LatestPhotoUrl { get; set; }
    }

    public class TreesGetTreeByIdLocationDto
    {
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string StreetNumber { get; set; }
    }

    public class TreesGetTreeByIdAssignedStudentDto
    {
        public int Id { get; set; }
        public string? ControlNumber { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string? SecondLastName { get; set; }
    }

    public class TreesGetTreeByIdResponse
    {
        public int Id { get; set; }
        public string? CurrentCampaignFolio { get; set; }
        public string HealthState { get; set; }
        public DateOnly? PlantingDate { get; set; }
        public string? Observations { get; set; }
        public string Value { get; set; }
        public string Species { get; set; }
        public string SpeciesScientificName { get; set; }
        public string? SpeciesImageUrl { get; set; }
        public decimal? CurrentHeightCentimeters { get; set; }
        public decimal? CurrentDiameterCentimeters { get; set; }
        public string? LatestPhotoUrl { get; set; }
        public TreesGetTreeByIdLocationDto? Location { get; set; }
        public List<TreesGetTreeByIdAssignedStudentDto> CurrentAssignedStudents { get; set; }
    }

    public class TreesGetTreeServicesResponse
    {
        public int Id { get; set; }
        public int TreeId { get; set; }
        public int ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; }
        public int StudentId { get; set; }
        public int? CampaignId { get; set; }
        public DateTime DeviceCapturedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Comment { get; set; }
    }

    // ==========================================
    // CAMPAÑAS
    // ==========================================
    public class CommonDtosLocationDto
    {
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string StreetNumber { get; set; }
    }

    public class CommonDtosPeriodDto
    {
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
    }

    public class CampaignsCreateCampaignRequest
    {
        public string CampaignName { get; set; }
        public CommonDtosLocationDto Location { get; set; }
        public CommonDtosPeriodDto Period { get; set; }
    }

    public class CampaignsCreateCampaignResponse
    {
        public int Id { get; set; }
        public string CampaignName { get; set; }
        public string NormalizedCampaignName { get; set; }
        public CommonDtosLocationDto Location { get; set; }
        public CommonDtosPeriodDto Period { get; set; }
    }

    public class CampaignsGetCampaignByIdResponse
    {
        public int Id { get; set; }
        public string CampaignName { get; set; }
        public string NormalizedCampaignName { get; set; }
        public CommonDtosPeriodDto Period { get; set; }
        public CommonDtosLocationDto Location { get; set; }
    }

    // ==========================================
    // SUBIDA DE ARCHIVOS
    // ==========================================
    public class UploadFileResponse
    {
        public string FileUrl { get; set; }
        public string FileIdentifier { get; set; }
        public long SizeBytes { get; set; }
    }
}