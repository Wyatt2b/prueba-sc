namespace ReforaTec.Models;

// ============================================================================
//  MODELO: Inquilino  (tenant / institución)
// ----------------------------------------------------------------------------
//  Cada escuela u organización es un "inquilino". Todo lo demás (campañas,
//  usuarios, árboles) pertenece a un inquilino y queda AISLADO de los demás.
//  Esto es lo que da de alta el Administrador del Sistema.
// ============================================================================
public class Inquilino
{
    public int Id { get; set; }

    // Identificador único legible del inquilino (ej. "ITCM").
    public string TenantId { get; set; } = string.Empty;

    public string Nombre { get; set; } = string.Empty;

    public string Ubicacion { get; set; } = string.Empty;

    public EstadoInquilino Estatus { get; set; } = EstadoInquilino.Activo;

    public string EstatusTexto => Estatus == EstadoInquilino.Activo ? "Activo" : "Inactivo";
}
